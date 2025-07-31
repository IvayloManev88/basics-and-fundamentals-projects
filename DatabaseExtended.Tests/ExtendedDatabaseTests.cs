namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {

        private const int Limit = 16;

        [TestCase(0), TestCase(1), TestCase(Limit/2), TestCase(Limit)]
        public void DataBaseShouldBeInitializedCorrectly(int n)
        {
            Person[] array = InitializeTestArray(n);
            Database database = new Database(array);
            Assert.AreEqual(n, database.Count);
            AssertContent(database, array);
            
        }

        [Test]
        public void DataBaseShouldThrowAnExceptionIfTooManyItemsAreProvided()
        {
            Person[] array =InitializeTestArray(Limit+1);
            Assert.Throws<ArgumentException>(()=> new Database(array));
        }


        [TestCase(0), TestCase(1), TestCase(Limit / 2), TestCase(Limit)]
        public void AddShouldWorkCorrectly(int n)
        {
            Person[] array = InitializeTestArray(n);
            Database database = new Database();

            for (int i = 0; i<n; i++)
            {
                database.Add(array[i]);

                Assert.AreEqual(i+1, database.Count);
                AssertContent(database, array.Take(i+1));
            }


        }


        [Test]
        public void AddShouldThrowExceptionIfUsernameIsNotUnique()
        {
            Database database = new Database();
            Person person1 = new Person(18, "Test");
            Person person2 = new Person(20, "Test");
            database.Add(person1);
            Assert.Throws<InvalidOperationException>(() => database.Add(person2), "There is already user with this username!");
        }

        [Test]
        public void AddShouldThrowExceptionIfIDIsNotUnique()
        {
            Database database = new Database();
            Person person1 = new Person(20, "George");
            Person person2 = new Person(20, "Test");
            database.Add(person1);
            Assert.Throws<InvalidOperationException>(() => database.Add(person2), "There is already user with this Id!");
        }

        [Test]
        public void AddSHouldThrowAnExceptionIfCapacityExceeded()
        {
            Person[] array = InitializeTestArray(Limit);
            Database database = new Database(array);
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(0, "Invalid")));

            Assert.AreEqual(Limit, database.Count);
            AssertContent(database, array);

        }

        [Test]
        public void RemoveSHouldThrowAnException()
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }


        [Test]
        public void RemoveSHouldWorkCorrectly()
        {
            Person[] array = InitializeTestArray(Limit);
            Database database = new Database(array);
            for (int i = Limit-1; i>= 0; i--)
            {
                database.Remove();
                Assert.That(database.Count, Is.EqualTo(i));
                AssertContent(database, array.Take(i));
                

            }
        }

        [Test]
        public void FindByUserNameShouldThrowExceptionIfThereAreNoSuchElements()
        {
           
            Database database = new Database();
            Person p1 = new Person(1, "first");
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("second"), "No user is present by this username!");


        }



        [Test]
        public void FindByIDNameShouldThrowExceptionIfThereAreNoSuchElements()
        {

            Database database = new Database();
            Person p1 = new Person(1, "first");
            Assert.Throws<InvalidOperationException>(() => database.FindById(2), "No user is present by this ID!");


        }



        [TestCase (-1), TestCase(-2), TestCase(-5)]
        public void FindByIDShouldThrowExceptionIfThereAreInvalidArguments(int invalidArg)
        {
            Person[] array = InitializeTestArray(Limit); 
            Database database = new Database(array);
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(invalidArg));
            

        }


        [TestCase (""), TestCase(null)]
        public void FindByNameShouldThrowExceptionIfThereAreInvalidArguments(string invalidArg)
        {
            Person[] array = InitializeTestArray(Limit);
            Database database = new Database(array);
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(invalidArg));
        }

        private Person[] InitializeTestArray(int n)
        {
            Person[] array = new Person[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Person(i + 1, $"Person No{i + 1}");
            }
            return array;
        }

        private void AssertContent(Database database, IEnumerable<Person> expected)
        {
            Assert.That(database,Is.Not.Null);
            Assert.That(expected, Is.Not.Null);

            foreach (Person person in expected)
            {
                Assert.That(person, Is.SameAs(database.FindByUsername(person.UserName)));
                Assert.That(person, Is.SameAs(database.FindById(person.Id)));
            }
        }
    }

}