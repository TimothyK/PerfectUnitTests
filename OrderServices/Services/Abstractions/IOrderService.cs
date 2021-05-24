using OrderServices.Models.Database;

namespace OrderServices.Services.Abstractions
{
    public interface IOrderService
    {
        void PostOrder(Order order);
    }
}
