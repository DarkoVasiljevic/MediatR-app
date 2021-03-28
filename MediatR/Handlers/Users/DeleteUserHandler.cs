using AutoMapper;
using MediatR.API.Commands.Users;
using MediatR.API.Dtos;
using MediatR.API.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.API.Handlers.Users
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, UserReadDto>
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public DeleteUserHandler(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<UserReadDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepo.DeleteUserAsync(request.UserId);
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            return _mapper.Map<UserReadDto>(result);
        }
    }
}
