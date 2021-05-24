using System;
using System.Collections.Generic;
using OrderServices.Models.Database;
using OrderServices.Models.FinancialSystem;
using OrderServices.Services;
using PerfectUnitTests.OrderServiceTests.TestDoubles;
using Shouldly;
using Xunit;

namespace PerfectUnitTests.OrderServiceTests
{
    public class PostOrderServiceTests
    {

        #region Infrastructure

        public TestFinancialSystem FinancialSystem { get; }
        public OrderService OrderService { get; }

        public PostOrderServiceTests()
        {
            FinancialSystem = new TestFinancialSystem();
            OrderService = new OrderService(FinancialSystem);
        }


        #region Arrange

        private static Order CreateTypicalOrder()
        {
            return new Order
            {
                Id = Guid.NewGuid()
            };
        }

        #endregion

        #region Act

        private void PostOrder(Order order)
        {
            OrderService.PostOrder(order);
        }

        #endregion

        #region Assert

        private IEnumerable<Invoice> GetPostedInvoices()
        {
            return FinancialSystem.Invoices;
        }

        #endregion
        
        #endregion
        
        [Fact]
        public void HappyPath()
        {
            //Arrange
            var order = CreateTypicalOrder();
            
            //Act
            PostOrder(order);
            
            //Assert
            GetPostedInvoices().ShouldNotBeEmpty();
        }
    }
}
