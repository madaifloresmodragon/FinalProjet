using Authentication.DataAccess.Interfaces;
using Authentication.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;  
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        private readonly IConfiguration _configuration;
        public UserRepository(
            IdentityDbContext context, 
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration,
            IPasswordHasher<IdentityUser> passwordHasher
            )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }
        public IQueryable<User> List 
        {
            get
            {
                return _context.Set<User>();
            }
        }

        public async Task<bool> ChangePassword(User user)
        {
            var identityUser = await _userManager.FindByNameAsync( user.UserName );

            if (identityUser != null)
            {
                if (_passwordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, user.OldPossword) != PasswordVerificationResult.Failed)
                {
                    var result = await _userManager.ChangePasswordAsync(identityUser, user.OldPossword, user.Password);

                    if (!result.Succeeded)
                    {
                        throw new ApplicationException("La contraseña debe contener al menos una letra mayuscula, minuscula y numero");
                    }
                    else
                    {
                        return result.Succeeded;
                    }
                }
                else
                {
                    throw new ApplicationException("La contraseña anterior es incorrecta.");
                }
            }
            else
            {
                throw new ApplicationException("Usuario no encontrado");
            }
        }

        public async Task<IdentityUser> FindIndentityUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityUser> FindIndentityUserByUserName(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public User FindUserName(string username)
        {
            return _context.Set<User>().SingleOrDefault(u => u.UserName == username);
        }

        public async Task<IList<string>> GetRoles(IdentityUser user)
        {
            var roles = _userManager.GetRolesAsync(user);

            return await roles;
        }

        public async Task<User> Login(User user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);
            var identityUser = await FindIndentityUserByUserName(user.UserName);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.UserName == user.UserName);
                var userToClaim = FindUserName(user.UserName);
                user.Token = await GenerateJwtToken(userToClaim, appUser);

                await _userManager.ResetAccessFailedCountAsync(identityUser);

                return user;
            }
            else 
            {
                if (_userManager.IsLockedOutAsync(identityUser).Result)
                {
                    var lockoutEnDateOffset = await _userManager.GetLockoutEnabledAsync(identityUser);
                    DateTime lockoutEndDate = Convert.ToDateTime(lockoutEnDateOffset.ToString());
                    DateTime currentDate = DateTime.Now;
                    TimeSpan lockoutEndTime = DateTime.Now - lockoutEndDate;

                    throw new ApplicationException("La cuenta a sido bloqueada temporalmente, intente nuevamente en: " + ((int)lockoutEndTime.TotalMinutes + 1) + "minutos");
                }
                else 
                {
                    await _userManager.AccessFailedAsync(identityUser);

                    throw new ApplicationException("Nombre de usuario o contraseña estan inconrrectos");
                }
            }
        }

        public async Task<bool> RegisterUser(User user)
        {
            var newUser = new IdentityUser 
            {
                UserName = user.UserName,
                Email = user.Email,
            };

            var result =  await _userManager.CreateAsync(newUser, user.Password);

            if (result.Succeeded) 
            {
                _context.Set<User>().Add(user);
                _context.SaveChanges();

                if (user.Roles != null) 
                {
                    foreach (var role in user.Roles)
                    {
                        await _userManager.AddToRoleAsync(newUser, role.Name);
                    }
                }
            }

            return result.Succeeded;
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        private async Task<string> GenerateJwtToken(User user, IdentityUser identityUser)
        {
            var claims = new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, identityUser.Id),
                new Claim("user_id", user.Id.ToString()),
                new Claim("user_email", user.Email)
            };

            var roles = GetRoles(identityUser);

            foreach (var role in roles.Result) 
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtExpireMinutes"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"], 
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
