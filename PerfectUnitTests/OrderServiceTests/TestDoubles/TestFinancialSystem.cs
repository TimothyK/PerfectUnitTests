using System.Collections.Generic;
using OrderServices.Models.FinancialSystem;
using OrderServices.Services.Abstractions;

namespace PerfectUnitTests.OrderServiceTests.TestDoubles
{
    public class TestFinancialSystem : IFinancialSystem
    {
        internal List<Invoice> Invoices { get; } = new List<Invoice>();

        public void SubmitInvoice(Invoice invoice)
        {
            Invoices.Add(invoice);
        }
    }
}
