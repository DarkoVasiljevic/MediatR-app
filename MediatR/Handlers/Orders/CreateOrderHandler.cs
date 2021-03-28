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
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderReadDto>
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IOrderRepo orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        public async Task<OrderReadDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newOrder = _mapper.Map<Order>(request.OrderDto);

            var result = await _orderRepo.CreateOrderAsync(newOrder);
            if (result == null)
                throw new ArgumentNullException(nameof(newOrder));

            return _mapper.Map<OrderReadDto>(newOrder);
        }
    }
}
