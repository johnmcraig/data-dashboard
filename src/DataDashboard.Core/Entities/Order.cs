using System;

namespace DataDashboard.Core.Entities
{
    public class Order : BaseEntity
    {
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public DateTime Placed { get; set; }
        public DateTime? Completed { get; set; }
    }
}