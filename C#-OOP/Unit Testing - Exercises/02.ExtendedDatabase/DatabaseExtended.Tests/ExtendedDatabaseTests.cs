namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person[] people16;
        private Person[] people3;
        private Person[] people0;
        private Person[] people17;
        private Person[] people19;

        [SetUp]
        public void Setup()
        {
            people16 = new Person[]
            { new Person(0,"Pesho"),
              new Person (1,"Misho"),
              new Person (2,"Gosho"),
              new Person (3,"Mimi"),
              new Person (4,"Rosana"),
              new Person(5,"Peshito"),
              new Person (6,"Mishto"),
              new Person (7,"Goshko"),
              new Person (8,"Mimito"),
              new Person (9, "Roxana"),
              new Person(10,"Pepi"),
              new Person (11,"Mishko"),
              new Person (12,"Gosheto"),
              new Person (13,"Mitko"),
              new Person (14, "Roximira"),
              new Person (15, "Nikolina"),
            };

            people3 = new Person[]
            { new Person(0,"Pesho"),
              new Person (1,"Misho"),
              new Person (2,"Gosho")
            };

            people0 = new Person[] { };

            people17 = new Person[]
            { new Person(0,"Pesho"),
              new Person (1,"Misho"),
              new Person (2,"Gosho"),
              new Person (3,"Mimi"),
              new Person (4,"Rosana"),
              new Person(5,"Peshito"),
              new Person (6,"Mishto"),
              new Person (7,"Goshko"),
              new Person (8,"Mimito"),
              new Person (9, "Roxana"),
              new Person(10,"Pepi"),
              new Person (11,"Mishko"),
              new Person (12,"Gosheto"),
              new Person (13,"Mitko"),
              new Person (14, "Roximira"),
              new Person (15, "Nikolina"),
              new Person (16, "Nikol"),
            };

            people19 = new Person[]
            { new Person(0,"Pesho"),
              new Person (1,"Misho"),
              new Person (2,"Gosho"),
              new Person (3,"Mimi"),
              new Person (4,"Rosana"),
              new Person(5,"Peshito"),
              new Person (6,"Mishto"),
              new Person (7,"Goshko"),
              new Person (8,"Mimito"),
              new Person (9, "Roxana"),
              new Person(10,"Pepi"),
              new Person (11,"Mishko"),
              new Person (12,"Gosheto"),
              new Person (13,"Mitko"),
              new Person (14, "Roximira"),
              new Person (15, "Nikolina"),
              new Person (16, "Nikol"),
              new Person (17, "Nikola"),
              new Person (18, "Nikolin"),
            };

        }

        [Test]
        public void ConstructorShouldAdd16PeopleToArray()
        {
            var db = new Database(people16);

            var expectedData = new Person[16];
            for (int i = 0; i < db.Count; i++)
            {
                expectedData[i] = people16[i];
            }
            var type = db.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var field = fields.First(f => f.Name == "persons");
            Person[] actualData = (Person[])field.GetValue(db);

            CollectionAssert.AreEqual(expectedData, actualData);
        }
        [Test]
        public void ConstructorShouldAdd3PeopleToArray()
        {
            var db = new Database(people3);

            var expectedData = new Person[16];
            for (int i = 0; i < db.Count; i++)
            {
                expectedData[i] = people3[i];
            }
            var type = db.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var field = fields.First(f => f.Name == "persons");
            Person[] actualData = (Person[])field.GetValue(db);

            CollectionAssert.AreEqual(expectedData, actualData);
        }
        [Test]
        public void ConstructorShouldAdd0PeopleToArray()
        {
            var db = new Database(people0);

            var expectedData = new Person[16];
            for (int i = 0; i < db.Count; i++)
            {
                expectedData[i] = people0[i];
            }
            var type = db.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var field = fields.First(f => f.Name == "persons");
            Person[] actualData = (Person[])field.GetValue(db);

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [Test]
        public void ConstructorShouldThrowInvalidOperationExceptionWith17People()
        {
            Assert.Throws<ArgumentException>(
                () => new Database(people17));
        }
        [Test]
        public void ConstructorShouldThrowInvalidOperationExceptionWith19People()
        {
            Assert.Throws<ArgumentException>(
                () => new Database(people19));
        }

        [TestCase(null)]
        public void ConstructorShouldThrowNullReferenceException(Person[] elements)
        {
            Assert.Throws<NullReferenceException>(
                () => new Database(elements));
        }

        [Test]
        public void RemoveShouldRemoveLastElementWith3People()
        {
            var actDb = new Database(people3);
            actDb.Remove();

            Person[] exDb = new Person[16];
            for (int i = 0; i < people3.Length - 1; i++)
            {
                exDb[i] = people3[i];
            }

            var expectedData = exDb;
            var type = actDb.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var field = fields.First(f => f.Name == "persons");
            Person[] actualData = (Person[])field.GetValue(actDb);

            CollectionAssert.AreEqual(expectedData, actualData);

        }
        [Test]
        public void RemoveShouldRemoveLastElementWith16People()
        {
            var actDb = new Database(people16);
            actDb.Remove();

            Person[] exDb = new Person[16];
            for (int i = 0; i < people16.Length - 1; i++)
            {
                exDb[i] = people16[i];
            }

            var expectedData = exDb;
            var type = actDb.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var field = fields.First(f => f.Name == "persons");
            Person[] actualData = (Person[])field.GetValue(actDb);

            CollectionAssert.AreEqual(expectedData, actualData);

        }


        [Test]
        public void RemoveShouldThrowsInvalidOperationExceptionWithZeroPeople()
        {
            var actDb = new Database(people0);

            Assert.Throws<InvalidOperationException>(
                () => actDb.Remove());
        }

        [Test]
        public void AddShouldThrowsInvalidOperationExceptionWhenTryToAdd17Person()
        {
            var db = new Database(people16);

            Assert.Throws<InvalidOperationException>(
                () => db.Add(new Person(123, "nasko")));
        }
        [Test]
        public void AddShouldThrowsInvalidOperationExceptionWhenDublicatePersonsNames()
        {
            var db = new Database(people3);

            Assert.Throws<InvalidOperationException>(
                () => db.Add(new Person(123, "Pesho")));
        }[Test]
        public void AddShouldThrowsInvalidOperationExceptionWhenDublicatePersonsID()
        {
            var db = new Database(people3);

            Assert.Throws<InvalidOperationException>(
                () => db.Add(new Person(1, "nasko")));
        }


        [Test]
        public void FindByUsernameShouldFindCorrectPersonByUsername()
        {
            var db = new Database(people3);

            var expectedPerson = new Person(0, "Pesho");
            var actualPerson = db.FindByUsername("Pesho");

            Assert.AreEqual(expectedPerson.Id, actualPerson.Id);
            Assert.AreEqual(expectedPerson.UserName, actualPerson.UserName);
        }

        [Test]
        public void FindByUsernameShouldThrowArgumentNullExceptionWithEmptyName()
        {
            var db = new Database(people3);

            Assert.Throws<ArgumentNullException>(
                () => db.FindByUsername(""));
        }
        [Test]
        public void FindByUsernameShouldThrowInvalidOperationExceptionWithInvalidName()
        {
            var db = new Database(people3);

            Assert.Throws<InvalidOperationException>(
                () => db.FindByUsername("NAsko"));
        }


        [Test]
        public void FindByUsernameShouldFindCorrectPersonByUserID()
        {
            var db = new Database(people3);

            var expectedPerson = new Person(0, "Pesho");
            var actualPerson = db.FindById(0);

            Assert.AreEqual(expectedPerson.Id, actualPerson.Id);
            Assert.AreEqual(expectedPerson.UserName, actualPerson.UserName);
        }

        [Test]
        public void FindByUsernameShouldThrowArgumentOutOfRangeExceptionWithNegativeID()
        {
            var db = new Database(people3);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => db.FindById(-1));
        }
        [Test]
        public void FindByUsernameShouldThrowInvalidOperationExceptionWithInvalid()
        {
            var db = new Database(people3);

            Assert.Throws<InvalidOperationException>(
                () => db.FindById(123));
        }
    }
    }