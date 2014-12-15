using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assertions;
using NUnit.Framework;
using NUnitIntroduction.Common;

namespace NUnitIntroduction._3_Assertions
{
    class PersonTest
    {
        [Test]
        public void PersonHasAge()
        {
            var person = new Person(52);

            Assert.AreEqual(52, person.Age);
            Assert.IsNullOrEmpty(person.Surname);
            // TODO: Napisz asercję, która sprawdzi, że wiek jest większy niż 18
        }

        [Test]
        public void PersonHasSurname()
        {
            var person = new Person("Kowalski");

            Assert.AreEqual("Kowalski", person.Surname);
            Assert.IsNotEmpty(person.Surname);
            Assert.AreEqual(0, person.Age);
            StringAssert.AreEqualIgnoringCase("kowalski", person.Surname);
            // TODO: Napisz asercję, która sprawdzi, że nazwisko zawiera "ski"
        }

        [Test]
        public void PersonIsAdult()
        {
            var child = new Person(10);
            var adult = new Person(23);

            // TODO: Sprawdź, że osoba "child" nie jest dorosła
            // TODO: Sprawdź, że osoba "adult" jest dorosła
        }

        [Test]
        public void PersonHasFingers()
        {
            var person = new Person(10);

            // TODO: Dodaj parametr z komunikatem, aby było wiadomo, która asercja nie przechodzi.
            // TODO: Popraw implementację, aby test przeszedł
            Assert.AreEqual(10, person.Age);
            Assert.AreEqual(10, person.Fingers);
        }
    }
}
