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
    [TestCase("BB", 60)]
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
    public void Can_calculate_price_for_single_D(string items, int expectedPrice)
    {
        var checkout = new Checkout();
        foreach (var item in items)
            checkout.Scan(item.ToString());
        Assert.That(checkout.GetTotalPrice(), Is.EqualTo(expectedPrice));
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
    private int _countOfA = 0;

    public int GetTotalPrice()
    {
        return _total;
    }

    public void Scan(string item)
    {
        if (item == "A")
        {
            _total += 50;
            _countOfA += 1;
            if (_countOfA == 3)
            {
                _total -= 20;
                _countOfA = 0;
            }
        }
        if (item == "B")
            _total += 30;
        if (item == "C")
            _total += 20;
        if (item == "D")
            _total += 15;
    }
}