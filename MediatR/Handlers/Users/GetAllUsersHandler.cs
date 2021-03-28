using AutoMapper;
using MediatR.API.Dtos;
using MediatR.API.Queries.Users;
using MediatR.API.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.API.Handlers.Users
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserReadDto>>
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserReadDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepo.GetAllUsersAsync();

            return _mapper.Map<IEnumerable<UserReadDto>>(users);
        }
    }
}
