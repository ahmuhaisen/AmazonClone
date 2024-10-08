﻿using AmazonClone.Application.Services.Interfaces;
using AmazonClone.Domain.Entities;
using AmazonClone.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace AmazonClone.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderItemService _orderItemService;
        private readonly ICartService _cartService;
        private readonly ICheckoutService _checkoutService;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderService(IUnitOfWork unitOfWork, IOrderItemService orderItemService, ICartService cartService, ICheckoutService checkoutService, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _orderItemService = orderItemService;
            _cartService = cartService;
            _checkoutService = checkoutService;
            _userManager = userManager;
        }

        public void Create(Order order)
        {
            _unitOfWork.Order.Create(order);
            _unitOfWork.Save();
        }



        public Order Get(int Id)
        {
            return _unitOfWork.Order.Get(x => x.Id == Id);
        }

        public IEnumerable<Order> GetAllBy(Expression<Func<Order, bool>> filter)
        {
            return _unitOfWork.Order.GetAllBy(filter);
        }

        public int GetNoOfOrders()
        {
            return _unitOfWork.Order.Count();
        }

        public int GetSalesVolume()
        {
            return _unitOfWork.Order.GetSalesVolume();
        }



        public void PlaceOrder(int shipmentId, int paymentId, string userId)
        {

            Order order = new()
            {
                CreatedAt = DateTime.Now,
                PaymentId = paymentId,
                ShipmentId = shipmentId,
                UserId = userId,
                TotalPrice = _checkoutService.GetCartTotalAmount()
            };

            Create(order);

            //Transfer Cart Items to Order Items
            IEnumerable<CartItem> cartItems = _cartService.GetCustomerCartItems(userId);
            IEnumerable<OrderItem> orderItems = cartItems.Select(c => new OrderItem()
            {
                Price = c.Product.Price,
                Quantity = c.Quantity,
                ProductId = c.ProductId,
                OrderId = order.Id,
            });

            _cartService.RemoveRange(cartItems);
            _orderItemService.AddRange(orderItems);
            _checkoutService.ResetCheckout();
        }
    }
}
