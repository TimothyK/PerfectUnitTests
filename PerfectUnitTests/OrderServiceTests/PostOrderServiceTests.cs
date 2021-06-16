using System;
using System.Collections.Generic;
using OrderServices.Models.Database;
using OrderServices.Models.Database.Enums;
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
                Id = Guid.NewGuid(),
                Status = Status.Shipped,
            };
            //Add any other requirements for Order creation here.  
            //Do orders require a Customer record? Order Line Items? Products?...
        }

        #endregion

        #region Act

        private void PostOrder(Order order)
        {
            //This may close out the Arrange section of the test by doing any necessary steps,
            //like writing or committing to a database.
            
            //Act
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
        
        [Fact]
        public void IdIsCopied()
        {
            //Arrange
            var id = Guid.NewGuid();
            var order = CreateTypicalOrder();
            order.Id = id;
            
            //Act
            PostOrder(order);
            
            //Assert
            GetPostedInvoices().ShouldContain(x => x.Id == id);
        }

        [Fact]
        public void Void_NotPosted()
        {
            //Arrange
            var order = CreateTypicalOrder();
            order.Status = Status.Void;

            //Act
            PostOrder(order);

            //Assert
            GetPostedInvoices().ShouldBeEmpty();
        }

    }
}
