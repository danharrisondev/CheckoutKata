﻿namespace CheckoutKata;

public class Checkout : ICheckout
{
    private int _total = 0;
    private int _countOfA = 0;
    private int _countOfB = 0;
    private int _itemCount = 0;
    private readonly Dictionary<string, int> _priceList = new()
    {
        { "A", 50 },
        { "B", 30 },
        { "C", 20 },
        { "D", 15 }
    };

    public int GetTotalPrice()
    {
        var discountA = _countOfA / 3 * 20;
        var discountB = _countOfB / 2 * 15;
        var bagFee = CalculateBagFee();
        return _total - discountA - discountB + bagFee;
    }

    private int CalculateBagFee()
    {
        return (int)Math.Ceiling(_itemCount / 5.0) * 5;
    }

    public void Scan(string item)
    {
        _itemCount++;
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