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
    class PersonConstraintsTest
    {
        [Test]
        public void PersonHasAge()
        {
            var person = new Person(52);

            Assert.That(person.Age, Is.EqualTo(52));
            Assert.That(person.Surname, Is.Null.Or.Empty);
            // TODO: Napisz asercję, która sprawdzi, że wiek jest większy niż 18
        }

        [Test]
        public void PersonHasSurname()
        {
            var person = new Person("Kowalski");

            Assert.That(person.Surname, Is.EqualTo("Kowalski"));
            Assert.That(person.Surname, Is.Not.Empty);
            Assert.That(person.Age, Is.EqualTo(0));
            Assert.That(person.Surname, Is.EqualTo("kowalski").IgnoreCase);
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
            Assert.That(person.Age, Is.EqualTo(10), "age");
            Assert.That(person.Fingers, Is.EqualTo(10), "fingers");
        }

        [Test]
        public void PersonCannotBeToOld()
        {
            // TODO: Ustaw wiek powyżej 1000 lat, aby asercja została spełniona
            var person = new Person(1);
            Assert.That(() => { var irrelevant = person.IsAdult; }, Throws.TypeOf<PersonTooOldException>());
        }
    }
}
