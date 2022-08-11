namespace INStock.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class ProductStockTests
    {
        private ProductStock productStock;
        private Product product1;
        private Product product2;
        private Product product3;
        [SetUp]
        public void SetUp()
        {
            productStock = new ProductStock();
            product1 = new Product("product1", 18, 20);
            product2 = new Product("product2", 18, 21);
            product3 = new Product("product3", 18, 20);
        }

        [Test]
        public void ConstructorShouldCreateEmptyICollection()
        {
            ICollection<Product> expectedData = new List<Product>();

            var type = typeof(ProductStock);
            FieldInfo fild = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(f => f.Name == "products");
            ICollection<Product> actualData = (List<Product>)fild.GetValue(productStock);

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [TestCase(1)]
        public void IndexerShouldGetElementOfIndex(int index)
        {
            productStock.Add(product1);
            productStock.Add(product2);
            productStock.Add(product3);

            var expectedData = product2;
            var actualData = productStock[index];

            Assert.AreEqual(expectedData, actualData);

        }

        [Test]
        public void CountShouldReturnTheCountOfProductsInCollection()
        {

            productStock.Add(product1);
            productStock.Add(product2);
            productStock.Add(product3);

            var expectedCount = 3;
            var actualCount = productStock.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void ContainsShouldReturnTrueWhenCollectionContainsProduct()
        {
            productStock.Add(product1);
            Assert.True(productStock.Contains(product1));
        }
        [Test]
        public void ContainsShouldReturnFalseWhenCollectionDoNotContainsProduct()
        {
            Assert.False(productStock.Contains(product1));
        }

        [Test]
        public void AddShouldAddUniqueProductToCollection()
        {
            productStock.Add(product1);
        }
        [Test]
        public void AddShouldThrowInvalidOperationExeptionWhenCollectionContainsProductThatYouWhantToAdd()
        {

            productStock.Add(product1);
            Assert.Throws<InvalidOperationException>(
                () => productStock.Add(product1));
        }

        [Test]
        public void RemoveShouldRemoveElementFromCollection()
        {
            productStock.Add(product1);
            productStock.Add(product2);

            Assert.True(productStock.Remove(product1));
            Assert.False(productStock.Remove(product3));
        }


        //    IProduct Find(int index);

        [Test]
        public void FintShouldReturnProductAtIndex()
        {
            productStock.Add(product1);
            productStock.Add(product2);

            int index = 1;

            var expectedData = product2;
            var actualData = productStock.Find(index);

            Assert.AreEqual(expectedData, actualData);
        }
        [Test]
        public void FintShouldThrowInvalidOperationExceptionWhenIndexDoNotExist()
        {
            int index = 3;

            Assert.Throws<InvalidOperationException>(
                ()=>productStock.Find(index));
        }

        //    IProduct FindByLabel(string label);

        [Test]
        public void FintShouldReturnProductByLabel()
        {
            productStock.Add(product1);
            productStock.Add(product2);

            string label = "product2";

            var expectedData = product2;
            var actualData = productStock.FindByLabel(label);

            Assert.AreEqual(expectedData, actualData);
        }
        [Test]
        public void FintShouldThrowInvalidOperationExceptionWhenLabelDoNotExist()
        {
            string label = "product1";

            Assert.Throws<InvalidOperationException>(
                () => productStock.FindByLabel(label));
        }

        //    IProduct FindMostExpensiveProduct();

        [Test]
        public void FintShouldReturnMostExpensiveProduct()
        {
            productStock.Add(product1);
            productStock.Add(product2);

            var expectedData = product2;
            var actualData = productStock.FindMostExpensiveProduct();

            Assert.AreEqual(expectedData, actualData);
        }

        //    IEnumerable<IProduct> FindAllInRange(double lo, double hi);

        [Test]
        public void FindAllInPriceRangeShouldReturnAllProductInPriceRange()
        {
            productStock.Add(product1);
            productStock.Add(product2);

            var expectedData = productStock;
            var actualData = productStock.FindAllInPriceRange(0, 100).ToList();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        //    IEnumerable<IProduct> FindAllByPrice(double price);

        //    IEnumerable<IProduct> FindAllByQuantity(int quantity);
    }
}
