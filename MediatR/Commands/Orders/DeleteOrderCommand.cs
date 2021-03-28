using MediatR.API.Dtos;

namespace MediatR.API.Commands.Orders
{
    public class DeleteOrderCommand : IRequest<OrderReadDto>
    {
        public int OrderId { get; }

        public DeleteOrderCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}
