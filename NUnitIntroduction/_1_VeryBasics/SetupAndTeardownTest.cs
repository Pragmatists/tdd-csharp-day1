using System;
using NUnit.Framework;

namespace NUnitIntroduction._1_VeryBasics
{
    [TestFixture]
    internal class SetupAndTeardownTest
    {
        /*
         * Uruchom ten test i przyjrzyj sie tekstom na konsoli.
         * -- Jaka jest kolejnosc wywolan metod z atrybutami
         *    TestFixtureSetUp, SetUp, TestFixtureTearDown, TearDown?
         * -- Dlaczego metody [SetUp] i [TearDown] sa wywolywane dwa razy,
         *    a [TestFixtureSetUp], [TestFixtureTearDown] po razie?
         * -- Nie doytkające metod testowych Test1 i Test2, zmień test tak,
         *    aby w obu testach wypisywała się wartość "counter = 42"
         */
        private int counter = 42;
        private static int globalCounter;

        [TestFixtureSetUp]
        public static void SetUpContext()
        {
            Console.Out.WriteLine("setting up fixture...");
            globalCounter = 100;
        }

        [TestFixtureTearDown]
        public static void DestroyContext()
        {
            Console.Out.WriteLine("tearing down fixture...");
        }

        [SetUp]
        public void EachTestSetUp()
        {
            Console.Out.WriteLine("setting up for test...");
        }

        [TearDown]
        public void EachTestTeraDown()
        {
            Console.Out.WriteLine("tearing down after test...");
        }

        [Test]
        public void Test1()
        {
            Console.Out.WriteLine("counter in Test 1 = {0}", counter++);
            Console.Out.WriteLine("globalCounter in Test 1 = {0}", globalCounter++);
        }

        [Test]
        public void Test2()
        {
            Console.Out.WriteLine("counter in Test 2 = {0}", counter++);
            Console.Out.WriteLine("globalCounter in Test 2 = {0}", globalCounter++);
        }
    }
}