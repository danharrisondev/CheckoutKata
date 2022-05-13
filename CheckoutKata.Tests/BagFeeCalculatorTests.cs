using NUnit.Framework;

namespace CheckoutKata.Tests
{
    public class BagFeeCalculatorTests
    {
        [TestCase(1, 5)]
        [TestCase(2, 5)]
        [TestCase(3, 5)]
        [TestCase(4, 5)]
        [TestCase(5, 5)]
        [TestCase(6, 10)]
        [TestCase(11, 15)]
        [TestCase(16, 20)]
        public void Can_calculate_bag_fee(int itemCount, int expectedPrice)
        {
            var calculator = new BagFeeCalculator();
            Assert.That(calculator.GetBagFee(itemCount), Is.EqualTo(expectedPrice));
        }
    }
}
