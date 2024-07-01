using AmazonClone.Domain.Entities;
using AmazonClone.Domain.ViewModels.Customer;

namespace AmazonClone.Application.Services.Interfaces
{
    public interface ICheckoutService
    {
        public Checkout CalculateCheckout(IEnumerable<CartItem> userCartItems, double? discountPercentage = null);
        public CustomerCartCheckoutViewModel GetCheckoutSection(Checkout checkoutData);


        double GetCartTotalAmount();

    }
}
