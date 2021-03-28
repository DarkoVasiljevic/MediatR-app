using MediatR.API.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatR.API.Repositories
{
    public interface IOrderRepo
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> DeleteOrderAsync(int id);
        Task<Order> UpdateOrderAsync(int id, Order order);
        Task<int> SaveChangesAsync();
    }
}
