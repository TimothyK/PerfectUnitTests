using OrderServices.Models.FinancialSystem;

namespace OrderServices.Services.Abstractions
{
    public interface IFinancialSystem
    {
        void SubmitInvoice(Invoice invoice);
    }
}
