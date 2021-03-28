using AutoMapper;
using MediatR.API.Database;
using MediatR.API.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MediatR.API.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly DBContext _db;

        public UserRepo(DBContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _db.Users
                .Select(s => new User 
                {
                    UserId = s.UserId,
                    Email = s.Email,
                    Name = s.Name,
                    Address = s.Address,
                    Orders = s.Orders
                })
                .ToListAsync();

            /*
            return await (from u in _db.Users
                            select new User
                            {
                                UserId = u.UserId,
                                Email = u.Email,
                                Name = u.Name,
                                Address = u.Address,
                                Orders = u.Orders
                            })
                            .ToListAsync();
            */
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _db.Users
                .Where(u => u.UserId == id)
                .Select(s => new User 
                {
                    UserId = s.UserId,
                    Email = s.Email,
                    Name = s.Name,
                    Address = s.Address,
                    Orders = s.Orders
                })
                .FirstAsync();

            /*
            return await (from u in _db.Users
                          where u.UserId == id
                          select new User
                          {
                              UserId = u.UserId,
                              Email = u.Email,
                              Name = u.Name,
                              Address = u.Address,
                              Orders = u.Orders
                          })
                          .FirstAsync();
            */
        }

        public async Task<User> CreateUserAsync(User user)
        {
            if (user == null)
                return null;

            await _db.Users.AddAsync(user);
            await SaveChangesAsync();

            return user;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(u => u.UserId == id);
            if (user == null)
                return null;

            _db.Users.Remove(user);
            await SaveChangesAsync();
            
            return user;
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            var oldUser = await _db.Users.SingleOrDefaultAsync(u => u.UserId == id);
            if (oldUser == null)
                return null;

            oldUser = UpdateObjectProperties(oldUser, user);

            await SaveChangesAsync();

            return oldUser;
        }

        private User UpdateObjectProperties(User dest, User src)
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
