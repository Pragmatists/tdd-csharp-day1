using Assertions;

namespace NUnitIntroduction.Common
{
    public class Person
    {
        public int Age { get; set; }
        public string Surname { get; set; }
        public int Fingers { get { return 12; } }
        public bool IsAdult
        {
            get
            {
                if (Age > 1000)
                    throw new PersonTooOldException();
                return Age >= 18;
            }
        }

        public Person(int age)
        {
            Age = age;
        }

        public Person(string surname)
        {
            Surname = surname;
        }
    }
}