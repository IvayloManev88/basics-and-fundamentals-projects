using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public |BindingFlags.Static|BindingFlags.NonPublic | BindingFlags.Instance);
            
            Object classInstance = Activator.CreateInstance(classType, new object[] {});
            sb.AppendLine($"Class under investigation: {classType.FullName}");
            foreach ( FieldInfo field in classFields.Where( f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type type = Type.GetType(className);
            var fields = type.GetFields();
            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (PropertyInfo property in properties)
            {
                var getMethod = property.GetGetMethod(true);
                var setMethod = property.GetSetMethod();
                if (getMethod != null  && !getMethod.IsPublic) sb.AppendLine($"{getMethod.Name} have to be public!");
                
                if (setMethod != null && !setMethod.IsPrivate) sb.AppendLine($"{setMethod.Name} have to be private!");
            }


            return sb.ToString().Trim();
        }
    }
}
