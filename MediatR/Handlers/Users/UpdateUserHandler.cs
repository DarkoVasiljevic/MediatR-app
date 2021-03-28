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
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserReadDto>
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<UserReadDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.UserDto);

            var result = await _userRepo.UpdateUserAsync(request.UserId, user);
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            return _mapper.Map<UserReadDto>(result);
        }
    }
}
