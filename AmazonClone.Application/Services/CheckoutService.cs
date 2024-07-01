using AmazonClone.Application.Services.Interfaces;
using AmazonClone.Application.Utils;
using AmazonClone.Domain.Entities;
using AmazonClone.Domain.ViewModels.Customer;

namespace AmazonClone.Application.Services
{
    public class CheckoutService : ICheckoutService
    {
        public Checkout CalculateCheckout(IEnumerable<CartItem> userCartItems, double? discountPercentage = null)
        {
            return Checkout.Instance.CalculateCheckout(userCartItems, discountPercentage);
        }

        public double GetCartTotalAmount()
        {
            return Checkout.Instance.Total;
        }

        public CustomerCartCheckoutViewModel GetCheckoutSection(Checkout checkoutData)
        {
            return new()
            {
                SubTotal = checkoutData.SubTotal,
                Delivery = checkoutData.Delivery,
                TaxRate = checkoutData.TaxRate,
                SubTotalTax = checkoutData.SubTotalTax,
                Total = checkoutData.Total,
            };
        }
    }
}
