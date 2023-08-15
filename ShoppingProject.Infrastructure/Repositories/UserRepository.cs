using Microsoft.EntityFrameworkCore;
using ShoppingProject.Core.Interfaces;
using ShoppingProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShoppingDbContext _dbContext;

        public UserRepository(ShoppingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
