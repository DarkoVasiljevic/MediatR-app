using MediatR.API.Dtos;

namespace MediatR.API.Commands.Orders
{
    public class UpdateOrderCommand : IRequest<OrderReadDto>
    {
        public int OrderId { get; }
        public OrderCreateDto OrderDto { get; }

        public UpdateOrderCommand(int orderId, OrderCreateDto orderDto)
        {
            OrderId = orderId;
            OrderDto = orderDto;
        }
    }
}
