namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections;

    [TestFixture]
    public class DatabaseTests
    {

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldAddElementsToArray(int[] elements)
        {
            var testDb = new Database(elements);

            var expectedData = elements;
            var actualData = testDb.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        public void ConstructorShouldThrowInvalidOperationException(int[] elements)
        {
            Assert.Throws<InvalidOperationException>(
                () => new Database(elements));
        }
        [TestCase(null)]
        public void ConstructorShouldThrowNullReferenceException(int[] elements)
        {
            Assert.Throws<NullReferenceException>(
                () => new Database(elements));
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void RemoveShouldRemoveLastElement(int[] elements)
        {
            var actDb = new Database(elements);
            actDb.Remove();

            int[] exDb = new int[elements.Length-1];
            for (int i = 0; i < elements.Length-1; i++)
            {
                exDb[i] = elements[i];
            }

            var expectedData = exDb;
            var actualData = actDb.Fetch();

            var expectedCount = exDb.Length;
            var actualCount = actDb.Count;

            Assert.AreEqual(expectedCount, actualCount);

            CollectionAssert.AreEqual(expectedData, actualData);

        }
        [TestCase(new int[] { })]
        public void RemoveShouldThrowsInvalidOperationException(int[] elements)
        {
            var actDb = new Database(elements);

            Assert.Throws<InvalidOperationException>(
                () => actDb.Remove());
        }






    }
}
