using Microsoft.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Reflection;

namespace MiniORM
{
    public class DbContext
    {
        // TODO: Create your DbContext class here.

        internal static readonly Type[] AllowedSqlTypes =
        {
            typeof(string),
            typeof(DateTime),
            typeof(int),
            typeof(long),
            typeof(ulong),
            typeof(uint),
            typeof(float),
            typeof(decimal),
            typeof(bool),
            typeof(short),
            typeof(Guid),
            typeof(ushort)
        };

        private readonly DatabaseConnection dbConnection;
        private readonly IDictionary<Type, PropertyInfo> dbSetProperties;

        protected DbContext(string connectionString)
        {
            this.dbConnection = new DatabaseConnection(connectionString);
            this.dbSetProperties = this.DiscoverDbSets();
            using (new ConnectionManager (this.dbConnection))
            {
                this.InitializeDbSets();
            }
            this.MapAllRelations();
        }

        public void SaveChanges()
        {
            IEnumerable<object?> dbSetObjects= this.dbSetProperties.Select(edb => edb.Value.GetValue(this)).ToArray();
            foreach (IEnumerable<object> dbSet in dbSetObjects)
            {
                IEnumerable<object> invalidEntities = dbSet.Where(e => !IsObjectValid(e)).ToArray();
                if (invalidEntities.Any()) throw new InvalidOperationException(String.Format(ErrorMessages.InvalidEntitiesInDbSetMessage,invalidEntities.Count(),dbSet.GetType().Name));

               
            }
            using (new ConnectionManager(this.dbConnection))
            {
                using SqlTransaction transaction = this.dbConnection.StartTransaction();
                foreach (IEnumerable dbSet in dbSetObjects)
                {
                    MethodInfo persistMethod = typeof(DbContext).GetMethod("Persist", BindingFlags.NonPublic | BindingFlags.Instance).MakeGenericMethod(dbSet.GetType());
                    try
                    {
                        try
                        {
                            persistMethod.Invoke(this, new object[] { dbSet });
                        }
                        catch (TargetInvocationException tie ) when (tie.InnerException != null) 
                        {

                            throw tie.InnerException;
                        }
                    }
                    catch 
                    {
                        Console.WriteLine("Performing Rollback due to Exception!!!");
                        transaction.Rollback();
                        throw;
                    }
                }
                transaction.Commit();
            }


        }

        private void Persist<TEntity> (DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            string tableName = this.GetTableName(typeof(TEntity));
            IEnumerable<string> columnNames= this.dbConnection.FetchColumnNames(tableName);

            if (dbSet.ChangeTracker.Added.Any())
            {
                this.dbConnection.InsertEntities(dbSet.ChangeTracker.Added,tableName,columnNames.ToArray());
            }

            IEnumerable<TEntity>  modifiedEntities=dbSet.ChangeTracker.GetModifiedEntities(dbSet);
            if (modifiedEntities.Any())
            {
                this.dbConnection.UpdateEntities(modifiedEntities,tableName,columnNames.ToArray());
            }

            if (dbSet.ChangeTracker.Removed.Any())
            {
                this.dbConnection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columnNames.ToArray());
            }
        }

        private static bool IsObjectValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            ICollection<ValidationResult> validationErrors = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, validationContext, validationErrors,true);
        }

        private string GetTableName(Type tableType)
        {
            Attribute? tableNameAttribute = Attribute.GetCustomAttribute(tableType, typeof(TableAttribute));
            if (tableNameAttribute == null) return this.dbSetProperties[tableType].Name;

            if (tableNameAttribute is TableAttribute tableAttribConfirmed)
            {
                return tableAttribConfirmed.Name;
            }

            throw new ArgumentException(String.Format(ErrorMessages.NoTableNameFound, this.dbSetProperties[tableType].Name));
        }

        private IDictionary<Type, PropertyInfo> DiscoverDbSets()
        {
            return this.GetType().GetProperties().Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)).ToDictionary(pi=>pi.PropertyType.GetGenericArguments().First(),pi=>pi);
        }

        private void InitializeDbSets()
        {
            foreach (KeyValuePair<Type,PropertyInfo> dbSetKvp in dbSetProperties)
            {
                Type dbSetType = dbSetKvp.Key;
                PropertyInfo dbSetProperty = dbSetKvp.Value;
                MethodInfo populateDbSetMethodInfo = typeof(DbContext).GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)!.MakeGenericMethod(dbSetType);
                populateDbSetMethodInfo.Invoke(this, new object[] { dbSetProperty });
            }
        }

        private void MapAllRelations()
        {
            foreach (KeyValuePair<Type, PropertyInfo> dbSetKvp in dbSetProperties)
            {
                Type dbSetEntityType = dbSetKvp.Key;
                PropertyInfo dbSetPropertyInfo = dbSetKvp.Value;
                MethodInfo mapRelationsGenericMethodInfo = typeof(DbContext).GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(dbSetEntityType);
                object? dbSetInstance = dbSetPropertyInfo.GetValue(this);
                if (dbSetInstance == null)
                {
                    throw new ArgumentNullException(dbSetPropertyInfo.Name, String.Format(ErrorMessages.NullDbSetMessage));
                }
                mapRelationsGenericMethodInfo.Invoke(this, new object[] { dbSetInstance });
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSetPropertyInfo)
            where TEntity : class, new()
        {
            IEnumerable<TEntity> dbSetEntities = this.LoadTableEntities<TEntity>();
            DbSet<TEntity> dbSetInstance = new DbSet<TEntity>(dbSetEntities);
            ReflectionHelper.ReplaceBackingField(this,dbSetPropertyInfo.Name,dbSetInstance);


        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>()
            where TEntity : class
        {
            Type tableType = typeof(TEntity);
            IEnumerable <string> columnNames = this.GetEntityColumnNames(tableType);
            string tableName = this.GetTableName(tableType);

            return this.dbConnection.FetchResultSet<TEntity>(tableName, columnNames.ToArray());

        }

        private IEnumerable<string> GetEntityColumnNames(Type entityType)
        {
            string tableName = this.GetTableName(entityType);
            IEnumerable<string> columnNames= this.dbConnection.FetchColumnNames(tableName);
            IEnumerable<string> entityColumnNames = entityType.GetProperties().Where(pi=> columnNames.Contains(pi.Name)&& !pi.HasAttribute<NotMappedAttribute>() && AllowedSqlTypes.Contains(pi.PropertyType))
                .Select(pi=>pi.Name).ToArray();

            return entityColumnNames;


        }

        private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            Type entityType = typeof(TEntity);
            this.MapNavigationProperties(dbSet);
            IEnumerable<PropertyInfo> entityCollections = entityType.GetProperties().Where(pi => pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>));
            foreach (PropertyInfo entityCollectionPropInfo in entityCollections)
            {
                Type collectionEntityType=entityCollectionPropInfo.PropertyType.GenericTypeArguments.First();
                MethodInfo mapCollectionGenMethodInfo =  typeof(DbContext).GetMethod("MapCollection",BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(collectionEntityType);
                mapCollectionGenMethodInfo.Invoke(this, new object?[] { dbSet,entityCollectionPropInfo});

            }

        }


        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            Type entityType = typeof(TEntity);
            IEnumerable<PropertyInfo> foreignKeys = entityType.GetProperties().Where(pi => pi.HasAttribute<ForeignKeyAttribute>());
            foreach(PropertyInfo fkProperty in foreignKeys)
            {
                string navigationProperty = fkProperty.GetCustomAttribute<ForeignKeyAttribute>()!.Name;
                PropertyInfo? navigationPropertyInfo = entityType.GetProperty(navigationProperty);
                if (navigationPropertyInfo == null)
                {
                    throw new ArgumentException(String.Format(ErrorMessages.InvalidNavigationPropertyName, fkProperty.Name, navigationProperty));
                }
                object? navDbSetInstance = this.dbSetProperties[navigationPropertyInfo.PropertyType].GetValue(this);
                if (navDbSetInstance == null)
                    throw new ArgumentException(String.Format(ErrorMessages.NavPropertyWithoutDbSetMessage, navigationProperty, navigationPropertyInfo.PropertyType));

                PropertyInfo navEntityPkPropertyInfo = navigationPropertyInfo.PropertyType.GetProperties().First(pi=>pi.HasAttribute<KeyAttribute>());

                foreach (TEntity entity in dbSet)
                {
                    object? fkValue = fkProperty.GetValue(entity);
                    if (fkValue == null)
                    {
                        navigationPropertyInfo.SetValue(entity, null);
                        continue;
                    }
                    object? navPropValue = ((IEnumerable<object>)navDbSetInstance).First(currNavProp=> navEntityPkPropertyInfo.GetValue(currNavProp).Equals(fkValue));
                    navigationPropertyInfo.SetValue(entity, navPropValue);
                }


            }
        }

        private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet,PropertyInfo collectionPropInfo)
            where TDbSet : class, new()
            where TCollection : class, new()
        {
            Type entityType = typeof(TDbSet);
            Type collectionType = typeof(TCollection);
            IEnumerable<PropertyInfo> collectionPrimaryKeys = collectionType.GetProperties().Where(pi =>pi.HasAttribute<KeyAttribute>());
            PropertyInfo primaryKey = collectionPrimaryKeys.First();
            PropertyInfo foreignKey = entityType.GetProperties().First(pi => pi.HasAttribute<KeyAttribute>());
            if (collectionPrimaryKeys.Count()>=2)
            {
                //Many to many realtion
                primaryKey = collectionType.GetProperties().First(pi => collectionType.GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>()!.Name)!.PropertyType == entityType);
            }

            DbSet<TCollection> navDbSet = (DbSet<TCollection>)this.dbSetProperties[collectionType].GetValue(this)!;

            foreach (TDbSet dbSetEntity in dbSet)
            {
                object pkValue = foreignKey.GetValue(dbSetEntity)!;
                IEnumerable<TCollection> navCollectionEntities = navDbSet.Where(navEntity => primaryKey.GetValue(navEntity)!.Equals(pkValue));
                ReflectionHelper.ReplaceBackingField(dbSetEntity,collectionPropInfo.Name, navCollectionEntities);
            }
        }
    }
}
