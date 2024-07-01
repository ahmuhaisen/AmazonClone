
using AmazonClone.Domain.Entities;

namespace AmazonClone.Application.Services.Interfaces
{
    public interface IPaymentService
    {
        void Create(Payment payment);
    }
}
