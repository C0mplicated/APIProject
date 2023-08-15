using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> AddUserAsync(string username, string password);
        Task<bool> CheckUserPasswordAsync(string username, string password);
    }
}
