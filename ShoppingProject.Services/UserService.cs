using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Core.Interfaces;
using ShoppingProject.Core.Model;
using ShoppingProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        // You may need additional dependencies like password hashing service here.

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> AddUserAsync(string username, string password)
        {
            // Perform password hashing and validation if needed.
            var user = new User
            {
                Username = username,
                Password = password
            };

            return await _userRepository.AddUserAsync(user);
        }

        public async Task<bool> CheckUserPasswordAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null)
                return false;

            // Perform password hashing and validation here.
            return user.Password == password;
        }
    }
}
