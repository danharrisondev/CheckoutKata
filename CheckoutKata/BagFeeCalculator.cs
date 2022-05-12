namespace CheckoutKata;

public class BagFeeCalculator : IBagFeeCalculator
{
    public int GetBagFee(int itemCount)
    {
        return (int)Math.Ceiling(itemCount / 5.0) * 5;
    }
}