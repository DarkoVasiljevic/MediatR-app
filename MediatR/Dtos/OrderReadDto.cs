using System;

namespace MediatR.API.Dtos
{
    public class OrderReadDto
    {
        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public string Address { get; set; }

        public DateTime Date { get; set; }

        public float Price { get; set; }
    }
}
