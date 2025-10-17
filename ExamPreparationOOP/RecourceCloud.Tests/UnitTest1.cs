using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RecourceCloud.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ConstructorShouldWork()
        {
            DepartmentCloud dept = new DepartmentCloud();
            Assert.That(dept.Tasks, Is.Empty);
            Assert.That(dept.Resources, Is.Empty);
            Assert.AreEqual(dept.Tasks.Count, 0);
            Assert.AreEqual(dept.Resources.Count, 0);
        }

        [TestCase(0), TestCase(1), TestCase(2), TestCase(4)]
        public void LogTaskWithoutAllArguments(int n)
        {
            DepartmentCloud dept = new DepartmentCloud();
            string[] args = new string[n];
            Assert.Throws<ArgumentException>(() => dept.LogTask(args), "All arguments are required.");
        }

        [Test]
        public void LogTaskWithNull()
        {
            DepartmentCloud dept = new DepartmentCloud();

            string[] args = new string[3];
            args[0] = null;
            for (int i = 1; i < 3; i++)
            {
                args[i] = $"argument {i}";
            }
            Assert.Throws<ArgumentException>(() => dept.LogTask(args), "Arguments values cannot be null.");
        }

        [Test]
        public void LogWorksCorrectly()
        {
            DepartmentCloud dept = new DepartmentCloud();

            string[] args = new string[3];
            args[0] = "1";
            for (int i = 1; i < 3; i++)
            {
                args[i] = $"argument {i}";
            }
            string result = dept.LogTask(args);


            Assert.AreEqual(result, "Task logged successfully.");
            Assert.AreEqual(dept.Tasks.Count, 1);
            Assert.AreEqual(dept.Resources.Count, 0);

        }

        [Test]
        public void LogWorkDuplicateTask()
        {
            DepartmentCloud dept = new DepartmentCloud();

            string[] args = new string[3];
            args[0] = "1";
            for (int i = 1; i < 3; i++)
            {
                args[i] = $"argument {i}";
            }
            dept.LogTask(args);
            string result = dept.LogTask(args);


            Assert.AreEqual(result, "argument 2 is already logged.");


        }

        [Test]
        public void CreateResourceWithEmptyTask()
        {
            DepartmentCloud dept = new DepartmentCloud();

            bool result = dept.CreateResource();
            Assert.IsFalse(result);


        }

        [Test]
        public void CreateResourceShouldWork()
        {
            DepartmentCloud dept = new DepartmentCloud();
            string[] args = new string[3];
            args[0] = "1";
            for (int i = 1; i < 3; i++)
            {
                args[i] = $"argument {i}";
            }
            dept.LogTask(args);

            bool result = dept.CreateResource();
            Assert.IsTrue(result);
            Assert.AreEqual(dept.Resources.Count, 1);
            Assert.AreEqual(dept.Tasks.Count, 0);


        }

        [Test]
        public void TestResourseWIthNullResource()
        {
            DepartmentCloud dept = new DepartmentCloud();

            Resource? result = dept.TestResource("ala");
            Assert.That(result, Is.Null);


        }

        [Test]
        public void TestResourseWorking()
        {
            DepartmentCloud dept = new DepartmentCloud();
            string[] args = new string[3];
            args[0] = "1";
            for (int i = 1; i < 3; i++)
            {
                args[i] = $"argument {i}";
            }
            dept.LogTask(args);

            dept.CreateResource();
            Resource currentResult = dept.Resources.First();
            Resource result = dept.TestResource("argument 2");
            Assert.AreEqual(result, currentResult);
            Assert.That(result.IsTested, Is.True);
        }
    }
}