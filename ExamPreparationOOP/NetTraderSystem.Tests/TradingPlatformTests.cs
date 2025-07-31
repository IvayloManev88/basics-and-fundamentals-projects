using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;
using System.Xml.Linq;

namespace NetTraderSystem.Tests
{
    public class TradingPlatformTests
    {

        private Product product;
        private TradingPlatform platform;

        [SetUp]
        public void Setup()
        {
            product = new Product("TestProduct", "TestCategory", 20);
            platform = new TradingPlatform(3);
        }

        [Test]
        public void ProductValuesShouldSetCorrectly()
        {
            Assert.AreEqual(product.Name, "TestProduct");
            Assert.AreEqual(product.Category, "TestCategory");
            Assert.AreEqual(product.Price, 20);
            Assert.AreEqual(product.ToString(), $"Name: TestProduct, Category: TestCategory - ${20:F2}");

        }

        [Test]
        public void AddProductShouldWorkCorrectly()
        {
            string result =platform.AddProduct(product);
            Assert.AreEqual(1, platform.Products.Count);
            Assert.AreEqual("Product TestProduct added successfully", result);
        }

        [Test]
        public void AddProductWithFullInventory()
        {
            TradingPlatform fullPlatform = new TradingPlatform(1);
            fullPlatform.AddProduct(product);
            string result = fullPlatform.AddProduct(product);
            Assert.AreEqual(1, fullPlatform.Products.Count);
            Assert.AreEqual("Inventory is full", result);
        }
        [Test]
        public void RemoveProductShouldWorkCorrectly()
        {
            platform.AddProduct(product);
            bool removedProduct = platform.RemoveProduct(product);
            Assert.AreEqual(0, platform.Products.Count);
            Assert.AreEqual(removedProduct,true);
        }
        [Test]
        public void RemoveNotExistingProduct()
        {
            platform.AddProduct(product);
            bool removedProduct = platform.RemoveProduct(new Product("new","cat",100));
            Assert.AreEqual(1, platform.Products.Count);
            Assert.AreEqual(removedProduct, false);
        }


        [Test]
        public void SellProductShouldWorkCorrectly()
        {
            platform.AddProduct(product);
            Product removedProduct = platform.SellProduct(product);
            Assert.AreEqual(0, platform.Products.Count);
            Assert.AreEqual(removedProduct, product);
        }
        [Test]
        public void SellNotExistingProduct()
        {
            platform.AddProduct(product);
            Product removedProduct = platform.SellProduct(new Product("new", "cat", 100));
            Assert.AreEqual(1, platform.Products.Count);
            Assert.AreEqual(removedProduct, null);
        }

        [Test]
        public void InventoryReportShouldWork()
        {
            platform.AddProduct(product);
            platform.AddProduct(new Product("", "", 100));
            string report = platform.InventoryReport();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inventory Report:");
            sb.AppendLine("Available Products: 2");
            sb.AppendLine("Name: TestProduct, Category: TestCategory - $20.00");
            sb.AppendLine("Name: , Category:  - $100.00");
            Assert.AreEqual(sb.ToString().TrimEnd(), report);
        }
    }
}