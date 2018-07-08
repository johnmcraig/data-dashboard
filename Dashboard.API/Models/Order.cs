using System;

namespace Dashboard.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public decimal Total { get; set; }
        public DateTime Placed { get; set; }
        public DateTime? Completed { get; set; }
    }
}