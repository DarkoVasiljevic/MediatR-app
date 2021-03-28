using MediatR.API.Database;
using MediatR.API.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MediatR.API.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly DBContext _db;

        public OrderRepo(DBContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _db.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _db.Orders.FirstAsync(o => o.OrderId == id);
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            if (order == null)
                return null;

            await _db.Orders.AddAsync(order);
            await SaveChangesAsync();

            return order;
        }

        public async Task<Order> DeleteOrderAsync(int id)
        {
            var order = await _db.Orders.SingleOrDefaultAsync(o => o.OrderId == id);
            if (order == null)
                return null;

            _db.Orders.Remove(order);
            await SaveChangesAsync();

            return order;
        }

        public async Task<Order> UpdateOrderAsync(int id, Order order)
        {
            var oldOrder = await _db.Orders.SingleOrDefaultAsync(o => o.OrderId == id);
            if (oldOrder == null)
                return null;

            oldOrder = UpdateObjectProperties(oldOrder, order);

            await SaveChangesAsync();

            return oldOrder;
        }

        private Order UpdateObjectProperties(Order dest, Order src)
        {
            PropertyInfo[] properties = src.GetType().GetProperties();

            var notNullProperties = properties.ToList().FindAll(p => p.GetValue(src) != null);

            List<string> propertyNames = (from p in notNullProperties select p.Name).Skip(1).ToList();

            propertyNames.ToList().ForEach(p => Debug.WriteLine($"property: {p}" + "\n"));

            properties.Where(p => propertyNames.Contains(p.Name)).ToList()
                .ForEach(p => p.SetValue(dest, p.GetValue(src, null)));

            return dest;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
