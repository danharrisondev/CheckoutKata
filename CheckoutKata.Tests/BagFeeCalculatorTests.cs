using NUnit.Framework;

namespace CheckoutKata.Tests
{
    public class BagFeeCalculatorTests
    {
        [TestCase("A", 5)]
        [TestCase("AA", 5)]
        [TestCase("AAA", 5)]
        [TestCase("AAAA", 5)]
        [TestCase("AAAAA", 5)]
        [TestCase("AAAAAA", 10)]
        [TestCase("AAAAAAAAAAA", 15)]
        [TestCase("AAAAAAAAAAAAAAAA", 20)]
        [TestCase("AAA", 5)]
        [TestCase("AAABC", 5)]
        public void Can_calculate_bag_fee(string items, int expectedPrice)
        {
            var calculator = new BagFeeCalculator();
            Assert.That(calculator.GetBagFee(items.Length), Is.EqualTo(expectedPrice));
        }
    }
}
