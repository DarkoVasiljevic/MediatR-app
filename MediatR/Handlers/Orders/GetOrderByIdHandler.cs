using AutoMapper;
using MediatR.API.Dtos;
using MediatR.API.Queries.Orders;
using MediatR.API.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.API.Handlers.Orders
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderReadDto>
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler(IOrderRepo orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        public async Task<OrderReadDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _orderRepo.GetOrderByIdAsync(request.Id);
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return _mapper.Map<OrderReadDto>(user);
        }
    }
}
