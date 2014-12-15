using System;

namespace NUnitIntroduction._1_VeryBasics
{
    class Calculator
    {
        public int Add(int left, int right)
        {
            return left + right;
        }

        public void CleanupResources()
        {
            Console.WriteLine("Resources Cleaned");
        }

        public int Divide(int left, int right)
        {
            throw new ArgumentException("Can't divide by 0");
        }
    }
}