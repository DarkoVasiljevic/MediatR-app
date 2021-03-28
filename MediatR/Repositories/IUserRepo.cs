using MediatR.API.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatR.API.Repositories
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<User> DeleteUserAsync(int id);
        Task<User> UpdateUserAsync(int id, User User);
        Task<int> SaveChangesAsync();
    }
}
