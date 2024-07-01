﻿using AmazonClone.Application.Services.Interfaces;
using AmazonClone.Domain.Entities;
using AmazonClone.Infrastructure.Repositories.Interfaces;

namespace AmazonClone.Application.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddRange(IEnumerable<OrderItem> orderItems)
        {
            _unitOfWork.OrderItem.AddRange(orderItems);
            _unitOfWork.Save();
        }
    }
}
