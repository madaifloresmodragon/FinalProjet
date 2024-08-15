using Authentication.DataAccess.Interfaces;
using Authentication.Entities;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration) 
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public Task<bool> ChangePassword(User user)
        {
            return _userRepository.ChangePassword(user);
        }

        public Task<IdentityUser> FindIdentityUserByName(string username)
        {
            return _userRepository.FindIndentityUserByUserName(username);
        }

        public ICollection<User> ListUsers()
        {
            var users = _userRepository.List;
            var userList = new List<User>();

            foreach (var user in users) 
            {
                var identityUser = _userRepository.FindIndentityUserByUserName(user.UserName).Result;
                var roles = _userRepository.GetRoles(identityUser).Result;
                user.Roles = roles.Select(r => new Role { Name = r}).ToList();
                userList.Add(user);
            }

            return userList;
        }

        public Task<User> Login(User user)
        {
            var registeredUser = _userRepository.FindUserName(user.UserName);

            if (registeredUser != null)
            {
                if (registeredUser.IsEnabled)
                {
                    return _userRepository.Login(user);
                }
                else
                {
                    throw new ApplicationException("Cuanta inhabilitada");
                }
            }
            else 
            {
                throw new ApplicationException("Nombre de usuario o contraseña incorrectos");
            }
        }

        public Task<bool> RegisterUser(User user)
        {
            user.IsEnabled = true;

            if (FindIdentityUserByName(user.UserName).Result != null)
            {
                throw new ApplicationException("Ne se puede retrar este usuario, el nombre de usuario ya existe");
            }
            else 
            {
                var userCreated = _userRepository.RegisterUser(user);
                return userCreated;
            }
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
