namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection.Metadata;

    [TestFixture]
    public class DatabaseTests
    {
        private const int Limit = 16;

        [Test]
        public void TestCreateArray()
        {
            Database database = new Database();
            Assert.AreEqual(0, database.Count);
        }
        [Test]
        public void TestAddingElements()
        {
            Database database = new Database();
            int[] array = new int[Limit];
            for (int i = 0; i<Limit; i++)
            {
                array[i] = i+1;
                database.Add(array[i]);
            }
            Assert.AreEqual(array, database.Fetch());
        }

        [Test]
        public void TestTryToAddElementAfter16thElement()
        {
            Database database = new Database();
            
            for (int i = 0; i < Limit; i++)
            {
                
                database.Add(i+1);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(5), "Array's capacity must be exactly 16 integers!");
        }

        [Test]

        public void TestRemovingItems()
        {
            Database database = new Database();
            int[] array = new int[Limit];
            for (int i = 0; i < Limit; i++)
            {
                array[i] = i + 1;
                database.Add(array[i]);
            }
            for (int i = database.Count - 1; i >= 5; i--)
            {
                database.Remove();
            }
            Assert.AreEqual(array[..5], database.Fetch());
            Assert.AreEqual(database.Count, 5);
        }

        [Test]
        public void TestThrowExceptionFromEmtpyDatabawse()
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove(), "The collection is empty!");
        }

    }
}
