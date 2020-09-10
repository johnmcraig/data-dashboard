using System;

namespace DataDashboard.Client.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public CustomerModel Customer { get; set; }
        public decimal Total { get; set; }
        public DateTime Placed { get; set; }
        public DateTime? Completed { get; set; }
    }
}