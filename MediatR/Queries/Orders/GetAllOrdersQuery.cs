using MediatR.API.Dtos;
using System.Collections.Generic;

namespace MediatR.API.Queries.Orders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderReadDto>>
    {

    }
}
