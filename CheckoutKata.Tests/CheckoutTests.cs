using System.Collections.Generic;
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
    public void Can_calculate_price_for_single_D(string items, int expectedPrice)
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
    private int _countOfB = 0;
    private readonly Dictionary<string, int> _priceList = new Dictionary<string, int>
    {
        { "A", 50 },
        { "B", 30 },
        { "C", 20 },
        { "D", 15 }
    };

    public int GetTotalPrice()
    {
        var discountA = (_countOfA / 3) * 20;
        var discountB = (_countOfB / 2) * 15;
        return _total - discountA - discountB;
    }

    public void Scan(string item)
    {
        _total += _priceList[item];
        
        if (item == "A")
        {
            _countOfA += 1;
        }
        
        if (item == "B")
        {
            _countOfB += 1;
        }
    }
}