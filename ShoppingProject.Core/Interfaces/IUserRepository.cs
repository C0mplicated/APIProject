using ShoppingProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<int> AddUserAsync(User user);

        Task<User> GetUserByUsernameAsync(string username);
    }
}
