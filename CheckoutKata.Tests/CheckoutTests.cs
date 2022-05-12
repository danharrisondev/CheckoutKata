using NUnit.Framework;

namespace CheckoutKata.Tests;

public class CheckoutTests
{
    [Test]
    public void Can_calculate_price_for_A()
    {
        var checkout = new Checkout();
        checkout.Scan("A");
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(50));
    }

    [Test]
    public void Can_calculate_price_for_multiple_A()
    {
        var checkout = new Checkout();
        checkout.Scan("A");
        checkout.Scan("A");
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(100));
    }

    [Test]
    public void Can_calculate_price_for_B()
    {
        var checkout = new Checkout();
        checkout.Scan("B");
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
    private int _items = 0;

    public int GetTotalPrice()
    {
        return _items * 50;
    }

    public void Scan(string item)
    {
        _items++;
    }
}