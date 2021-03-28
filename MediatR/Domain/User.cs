using System.Collections.Generic;

namespace MediatR.API.Domain
{
    public class User
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
