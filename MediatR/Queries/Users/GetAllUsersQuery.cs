using MediatR.API.Dtos;
using System.Collections.Generic;

namespace MediatR.API.Queries.Users
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserReadDto>>
    {

    }
}
