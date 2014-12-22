using System.Collections.Generic;
using Assertions;
using NUnit.Framework;
using NUnitIntroduction.Common;

namespace NUnitIntroduction._4_Parameters
{
    public class Parameters
    {
        [TestCase(1, false)]
        [TestCase(0, false)]
        [TestCase(17, false)]
        [TestCase(18, true)]
        [TestCase(20, true)]
        [TestCase(117, true)]
        public void AdultsAreMoreThan18YearsOld(int age, bool isAdult)
        {
            Assert.AreEqual(isAdult, new Person(age).IsAdult);
        }

        [TestCase(1, Result = false)]
        [TestCase(0, Result = false)]
        [TestCase(17, Result = false)]
        [TestCase(18, Result = true)]
        [TestCase(20, Result = true)]
        [TestCase(117, Result = true)]
        [TestCase(117, Ignore = true, Reason = "to be implemented")]
        public bool AdultsAreMoreThan18YearsOldWithResult(int age)
        {
            return new Person(age).IsAdult;
        }

        [TestCaseSource("IsPersonAdultTestCases")]
        public void AdultsAreMoreThan18YearsOldWithDataSource(int age, object isAdult)
        {
            Assert.AreEqual(isAdult, new Person(age).IsAdult);
        }

        [TestCaseSource(typeof (AdultPersonTestCasesFactory), "TestCases")]
        public bool AdultsAreMoreThan18YearsOldWithFactoryDataSource(int age)
        {
            return new Person(age).IsAdult;
        }

        public static object[] IsPersonAdultTestCases()
        {
            return new object[]
            {
                new object[] {1, false},
                new object[] {18, true}
            };
        }

        public class AdultPersonTestCasesFactory
        {
            public static IEnumerable<TestCaseData> TestCases
            {
                get
                {
                    yield return new TestCaseData(1).Returns(false);
                    yield return new TestCaseData(18).Returns(true);
                    yield return new TestCaseData(117).Returns(true);
                    yield return new TestCaseData(1200).Throws(typeof(PersonTooOldException));
                }
            }
        }

    }
}