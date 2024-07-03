using AmazonClone.Domain.Entities;

namespace AmazonClone.Application.Utils;

public class Checkout
{
    public double SubTotal { get; private set; }
    public double Delivery { get; private set; }
    public double TaxRate { get; private set; }
    public double SubTotalTax { get; private set; }
    public double Total { get; private set; }

    private static Checkout? _instance;

    public static Checkout Instance
    {
        get
        {
            return _instance ?? (_instance = new());
        }
    }

    public Checkout CalculateCheckout(IEnumerable<CartItem> cartItems, double? discountPercentage = null)
    {
        OrderCalculator calculator = new(cartItems);

        _instance.SubTotal = calculator.subTotal;
        _instance.Delivery = calculator.CalculateDeliveryFee();
        _instance.TaxRate = calculator.CalculateTaxRate();
        _instance.SubTotalTax = calculator.CalculateSubTotalTax();
        _instance.Total = calculator.GetTotal();

        return _instance;
    }

    public static void Reset()
    {
        _instance = null;
    }

}