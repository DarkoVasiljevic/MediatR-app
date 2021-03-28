using AutoMapper;
using MediatR.API.Dtos;
using MediatR.API.Queries.Orders;
using MediatR.API.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.API.Handlers.Orders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderReadDto>>
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;

        public GetAllOrdersHandler(IOrderRepo orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderReadDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepo.GetAllOrdersAsync();

            return _mapper.Map<IEnumerable<OrderReadDto>>(orders);
        }
    }
}
