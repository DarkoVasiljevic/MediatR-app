using MediatR.API.Dtos;

namespace MediatR.API.Commands.Users
{
    public class UpdateUserCommand : IRequest<UserReadDto>
    {
        public int UserId { get; }
        public UserCreateDto UserDto { get; }

        public UpdateUserCommand(int userId, UserCreateDto userDto)
        {
            UserId = userId;
            UserDto = userDto;
        }
    }
}
