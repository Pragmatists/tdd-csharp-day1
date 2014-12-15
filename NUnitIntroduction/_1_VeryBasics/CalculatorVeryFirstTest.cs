using NUnit.Framework;

namespace NUnitIntroduction._1_VeryBasics
{
    [TestFixture]
    public class CalculatorVeryFirstTest
    {
        [Test]
        public void ShouldAddTwoNumbers()
        {
            // given
            var calculator = new Calculator();
 
            // when
            var result = calculator.Add(2, 3);

            // then
            Assert.AreEqual(5, result);
        }
    }
}