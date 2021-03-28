using MediatR.API.Dtos;

namespace MediatR.API.Commands.Orders
{
    public class CreateOrderCommand : IRequest<OrderReadDto>
    {
        public OrderCreateDto OrderDto { get; }

        public CreateOrderCommand(OrderCreateDto orderDto)
        {
            OrderDto = orderDto;
        }

    }
}
