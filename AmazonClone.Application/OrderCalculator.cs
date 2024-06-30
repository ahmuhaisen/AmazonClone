using AmazonClone.Domain.Entities;

namespace AmazonClone.Application
{
    public class OrderCalculator
    {
        public readonly double subTotal;
        public readonly double? discountPercentage;

        public OrderCalculator(IEnumerable<CartItem> cartItems, double? discountPercentage = null)
        {
            subTotal = CalculateSubTotal(cartItems);
            if (discountPercentage is null) 
                this.discountPercentage = discountPercentage;
        }

        private double CalculateSubTotal(IEnumerable<CartItem> cartItems)
        {
            double subTotal = 0;
            foreach (var item in cartItems)
            {
                subTotal += (item.Product.ActualPrice * item.Quantity);
            }
            return subTotal;
        }

        public double CalculateDeliveryFee()
        {
            return OrderConsts.DeliveryFee;
        }

        public double CalculateTaxRate()
        {
            return OrderConsts.StandaredTax;
        }

        public double CalculateSubTotalTax()
        {
            return subTotal * (CalculateTaxRate() / 100);
        }

        public double CalculateSubTotalDiscount()
        {
            return discountPercentage is not null ? subTotal * ((double)discountPercentage / 100) : 0;
        }

        public double GetTotal()
        {
            return subTotal + CalculateDeliveryFee() + CalculateSubTotalTax() - CalculateSubTotalDiscount();
        }
    }
}
