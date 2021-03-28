using System;

namespace MediatR.API.Dtos
{
    public class OrderCreateDto
    {
        public string ProductName { get; set; }

        public string Address { get; set; }

        public DateTime Date { get; set; }

        public float Price { get; set; }

        public float Discount { get; set; }

        public int UserId { get; set; }
    }
}
