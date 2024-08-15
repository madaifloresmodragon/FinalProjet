using Authentication.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> RegisterUser(User user);
        Task<User> Login(User user);
        Task<bool> ChangePassword(User user);
        Task<IdentityUser> FindIndentityUserByEmail(string email);
        Task<IdentityUser> FindIndentityUserByUserName(string username);
        Task<bool> UpdateUser(User user);
        Task<IList<string>> GetRoles(IdentityUser user);
        IQueryable<User> List { get; }
        User FindUserName(string username);
    }
}
