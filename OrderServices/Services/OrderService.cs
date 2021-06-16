using OrderServices.Models.Database;
using OrderServices.Models.Database.Enums;
using OrderServices.Models.FinancialSystem;
using OrderServices.Services.Abstractions;

namespace OrderServices.Services
{
    public class OrderService : IOrderService
    {
        public IFinancialSystem FinancialSystem { get; }

        public OrderService(IFinancialSystem financialSystem)
        {
            FinancialSystem = financialSystem;
        }
        
        public void PostOrder(Order order)
        {
            if (order.Status == Status.Void)
            {
                return;
            }
            
            var invoice = MapToInvoice(order);
            FinancialSystem.SubmitInvoice(invoice);
        }

        private static Invoice MapToInvoice(Order order)
        {
            return new Invoice
            {
                Id = order.Id,
            };
        }
    }
}
