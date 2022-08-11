namespace INStock.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {
        private Product product;
        [SetUp]
        public void SetUp()
        {
            product = new Product("label", 12, 3.4m);
        }

        [TestCase("label",12,3.4)]
        [TestCase("label",1,0.1)]
        [TestCase("label",0,0.1)]
        public void ConstructorShouldCreateProduct(string label, int quantity, decimal price)
        {
            product = new Product(label, quantity, price);

            var expectedLabel = label;
            var expectedQuantity = quantity;
            var expectedPrice = price;

            var actualLabel = product.Label;
            var actualQuantity = product.Quantity;
            var actualPrice = product.Price;

            Assert.AreEqual(expectedLabel, actualLabel);
            Assert.AreEqual(expectedQuantity, actualQuantity);
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestCase(null, 12, 3.4)]
        [TestCase("", 12, 3.4)]
        [TestCase("label", -1, 0)]
        [TestCase("label", -12, -4)]
        [TestCase("label", 12, -4)]
        public void ConstructorShouldThrowArgumentExeptionForInvalidData(string label, int quantity, decimal price)
        {
            Assert.Throws<ArgumentException>(
                () => new Product(label, quantity, price));
        }


        [TestCase("this", 12, 3.4,"other",11,3.3)]
        [TestCase("this", 12, 3.4,"other",12,3.4)]
        [TestCase("this", 12, 3.4,"other",13,3.5)]
        public void CompareToShouldCompareTwoProducts(string thisName,int thisQuantity, decimal thisPrice, string otherName, int otherQuantity, decimal otherPrice)
        {
            var thisProduct = new Product(thisName, thisQuantity, thisPrice);
            var otherProduct = new Product(otherName, otherQuantity, otherPrice);

            var result = 0;
            if (thisPrice>otherPrice)
            {
                result =1;
            }
            else if (thisPrice<otherPrice)
            {
                result=-1;
            }
            Assert.True(thisProduct.CompareTo(otherProduct) == result);
        }

        //public int CompareTo([AllowNull] IProduct other)
        //{
        //    if (this.Price == other.Price)
        //    {
        //        return 0;
        //    }
        //    else if (this.Price < other.Price)
        //    {
        //        return -1;
        //    }
        //    return 1;
        //}
    }
}