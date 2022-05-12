using NUnit.Framework;

namespace CheckoutKata.Tests;

public class CheckoutTests
{
    [TestCase("A", 50)]
    [TestCase("AA", 100)]
    public void Can_calculate_price_for_A(string items, int expectedPrice)
    {
        var checkout = new Checkout();
        foreach (var item in items)
            checkout.Scan(item.ToString());
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(expectedPrice));
    }

    [TestCase("B", 30)]
    [TestCase("BB", 60)]
    public void Can_calculate_price_for_B(string items, int expectedPrice)
    {
        var checkout = new Checkout();
        foreach (var item in items)
            checkout.Scan(item.ToString());
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(expectedPrice));
    }

    [Test]
    public void Can_calculate_price_for_single_C()
    {
        var checkout = new Checkout();
        checkout.Scan("C");
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(20));
    }

    [Test]
    public void Can_calculate_price_for_multiple_C()
    {
        var checkout = new Checkout();
        checkout.Scan("C");
        checkout.Scan("C");
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(40));
    }

    [Test]
    public void Can_calculate_price_for_single_D()
    {
        var checkout = new Checkout();
        checkout.Scan("D");
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(15));
    }

    [Test]
    public void Can_calculate_price_for_multiple_D()
    {
        var checkout = new Checkout();
        checkout.Scan("D");
        checkout.Scan("D");
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(30));
    }
}

public interface ICheckout
{
    void Scan(string item);
    int GetTotalPrice();
}

public class Checkout : ICheckout
{
    private int _total = 0;

    public int GetTotalPrice()
    {
        return _total;
    }

    public void Scan(string item)
    {
        if (item == "A")
            _total += 50;
        if (item == "B")
            _total += 30;
        if (item == "C")
            _total += 20;
        if (item == "D")
            _total += 15;
    }
}