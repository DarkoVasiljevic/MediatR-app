using AutoMapper;
using MediatR.API.Dtos;
using MediatR.API.Queries.Users;
using MediatR.API.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.API.Handlers.Users
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserReadDto>
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<UserReadDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetUserByIdAsync(request.Id);
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return _mapper.Map<UserReadDto>(user);
        }
    }
}
