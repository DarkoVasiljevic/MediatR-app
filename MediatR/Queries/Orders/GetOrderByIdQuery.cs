using MediatR.API.Dtos;

namespace MediatR.API.Queries.Orders
{
    public class GetOrderByIdQuery : IRequest<OrderReadDto>
    {
        public int Id { get; set; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
