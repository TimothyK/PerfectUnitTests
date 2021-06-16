using System;
using OrderServices.Models.Database.Enums;

namespace OrderServices.Models.Database
{
    public class Order
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
    }
}