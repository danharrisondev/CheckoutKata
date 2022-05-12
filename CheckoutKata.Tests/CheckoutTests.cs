using NUnit.Framework;

namespace CheckoutKata.Tests;

public class CheckoutTests
{
    [TestCase("A", 50)]
    [TestCase("AA", 100)]
    [TestCase("AAA", 130)]
    [TestCase("AAAA", 180)]
    [TestCase("AAAAA", 230)]
    [TestCase("AAAAAA", 260)]
    public void Can_calculate_price_for_A(string items, int expectedPrice)
    {
        var checkout = new Checkout();
        foreach (var item in items)
            checkout.Scan(item.ToString());
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(expectedPrice));
    }

    [TestCase("B", 30)]
    [TestCase("BB", 45)]
    [TestCase("BBB", 75)]
    [TestCase("BBBB", 90)]
    public void Can_calculate_price_for_B(string items, int expectedPrice)
    {
        var checkout = new Checkout();
        foreach (var item in items)
            checkout.Scan(item.ToString());
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(expectedPrice));
    }

    [TestCase("C", 20)]
    [TestCase("CC", 40)]
    public void Can_calculate_price_for_C(string items, int expectedPrice)
    {
        var checkout = new Checkout();
        foreach (var item in items)
            checkout.Scan(item.ToString());
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(expectedPrice));
    }

    [TestCase("D", 15)]
    [TestCase("DD", 30)]
    public void Can_calculate_price_for_D(string items, int expectedPrice)
    {
        var checkout = new Checkout();
        foreach (var item in items)
            checkout.Scan(item.ToString());
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(expectedPrice));
    }

    [TestCase("AABCCDD", 200)]
    [TestCase("DABCACD", 200)]
    [TestCase("AAABBCCDD", 245)]
    [TestCase("BAABCADDC", 245)]
    [TestCase("AAAAABBCCDD", 345)]
    [TestCase("AABAACABCDD", 345)]
    [TestCase("AAAAAABBCCDD", 375)]
    [TestCase("BAAAAAABCCDD", 375)]
    [TestCase("AAAAAABBBBCCDD", 420)]
    [TestCase("AAAABBBBCCDDAA", 420)]
    public void Can_calculate_price_for_multiple_items_in_any_order(string items, int expectedPrice)
    {
        var checkout = new Checkout();
        foreach (var item in items)
            checkout.Scan(item.ToString());
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(expectedPrice));
    }

    [TestCase("A", 55)]
    [TestCase("AA", 105)]
    [TestCase("AAA", 135)]
    [TestCase("AAAA", 185)]
    [TestCase("AAAAA", 235)]
    public void Can_calculate_single_bag_fee(string items, int expectedPrice)
    {
        var checkout = new Checkout();
        foreach (var item in items)
            checkout.Scan(item.ToString());
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(expectedPrice));
    }

    [TestCase("AAAAAA", 270)]
    [TestCase("AAAAAAAAAAA", 505)]
    public void Can_calculate_multiple_bag_fee(string items, int expectedPrice)
    {
        var checkout = new Checkout();
        foreach (var item in items)
            checkout.Scan(item.ToString());
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(expectedPrice));
    }
}
