using Core.Models;
using Data.DTOs;
using Data.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Users
{
    public interface IUsersService
    {
        Task CreateAsync(User user, string password);
        Task<User> GetByIdAsync(string id);
        List<UserDTO> GetAll();
        Task UpdateAsync(User user);
        Task DeleteAsync(string id);
        //Task Login(User user, string password);
        Task<LoginModel> Login(string email, string password);
    }
}
