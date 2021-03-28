using AutoMapper;
using MediatR.API.Commands.Orders;
using MediatR.API.Dtos;
using MediatR.API.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.API.Handlers.Orders
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, OrderReadDto>
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;

        public DeleteOrderHandler(IOrderRepo orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        public async Task<OrderReadDto> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await _orderRepo.DeleteOrderAsync(request.OrderId);
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            return _mapper.Map<OrderReadDto>(result);
        }
    }
}
