using System.Collections.Generic;

namespace MediatR.API.Dtos
{
    public class UserReadDto
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public ICollection<OrderReadDto> Orders { get; set; }
    }
}
