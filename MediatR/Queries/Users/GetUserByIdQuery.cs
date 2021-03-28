using MediatR.API.Dtos;

namespace MediatR.API.Queries.Users
{
    public class GetUserByIdQuery : IRequest<UserReadDto>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
