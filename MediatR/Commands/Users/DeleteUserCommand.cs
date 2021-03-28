using MediatR.API.Dtos;

namespace MediatR.API.Commands.Users
{
    public class DeleteUserCommand : IRequest<UserReadDto>
    {
        public int UserId { get; }

        public DeleteUserCommand(int userId)
        {
            UserId = userId;
        }
    }
}
