using AutoMapper;
using MediatR.API.Commands.Users;
using MediatR.API.Domain;
using MediatR.API.Dtos;
using MediatR.API.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.API.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserReadDto>
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<UserReadDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = _mapper.Map<User>(request.UserDto);

            var result = await _userRepo.CreateUserAsync(newUser);
            if (result == null)
                throw new ArgumentNullException(nameof(newUser));

            return _mapper.Map<UserReadDto>(newUser);
        }
    }
}
