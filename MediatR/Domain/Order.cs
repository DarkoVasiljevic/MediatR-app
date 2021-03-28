using System;

namespace MediatR.API.Domain
{
    public class Order
    {
        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public string Address { get; set; }
        
        public DateTime Date { get; set; }

        public float Price { get; set; }

        public float Discount { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
