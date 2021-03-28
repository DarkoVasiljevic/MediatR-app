using MediatR.API.Dtos;

namespace MediatR.API.Commands.Users
{
    public class CreateUserCommand : IRequest<UserReadDto>
    {
        public UserCreateDto UserDto { get; }

        public CreateUserCommand(UserCreateDto userDto)
        {
            UserDto = userDto;
        }

    }
}
