using AutoMapper;
using MediatR.API.Commands.Orders;
using MediatR.API.Domain;
using MediatR.API.Dtos;
using MediatR.API.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.API.Handlers.Orders
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, OrderReadDto>
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;

        public UpdateOrderHandler(IOrderRepo orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        public async Task<OrderReadDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request.OrderDto);

            var result = await _orderRepo.UpdateOrderAsync(request.OrderId, order);
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            return _mapper.Map<OrderReadDto>(result);
        }
    }
}
