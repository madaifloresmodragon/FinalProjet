using Authentication.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUser(User user);
        Task<bool> ChangePassword(User user);
        Task<User> Login(User user);
        Task<IdentityUser> FindIdentityUserByName(string username);
        ICollection<User> ListUsers();
        Task<bool> UpdateUser(User user);
    }
}
