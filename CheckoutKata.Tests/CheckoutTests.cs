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
}

public interface ICheckout
{
    void Scan(string item);
    int GetTotalPrice();
}

public class Checkout : ICheckout
{
    public int GetTotalPrice()
    {
        return 50;
    }

    public void Scan(string item)
    {
        
    }
}