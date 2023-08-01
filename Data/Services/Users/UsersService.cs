using Core.Models;
using Data.DTOs;
using Data.Services.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Users
{
    public class UsersService : IUsersService
    {

        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public UsersService(ApplicationDbContext dbContext, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<LoginModel> Login(string email, string password)


        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is null)
                return new LoginModel { Token = "", IsLogin = false };

            var result = await signInManager.PasswordSignInAsync(email, password, false, false);
            if (!result.Succeeded)
                return new LoginModel { Token = "", IsLogin = false };

            var token = GenerateJwtToken(user.Id, user.UserName, "your_secret_key_here");
            return new LoginModel
            {
                Token = token,
                IsLogin = true,
                User = new UserDTO
                { Email = user.Email, Gender = user.Gender, Location = user.Location, Message = user.Message, PhoneNumber = user.PhoneNumber , Id=user.Id }
            };

        }

        public async Task CreateAsync(User user, string password)
        {

          var result=  await userManager.CreateAsync(user, password);
        }

        public async Task DeleteAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
                await userManager.DeleteAsync(user);
        }

        public List<UserDTO> GetAll()
        {
            return dbContext.Users.Select(t => new UserDTO
            {
                Email = t.Email,
                Gender = t.Gender,
                Location = t.Location,
                Id = t.Id,
                PhoneNumber = t.PhoneNumber,
                Message = t.Message
            }
            ).ToList();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await userManager.FindByIdAsync(id);
        }


        public async Task UpdateAsync(User user)
        {
            await userManager.UpdateAsync(user);
        }


        private string GenerateJwtToken(string userId, string userName, string secretKey, int tokenExpirationMinutes = 60)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Name, userName)
        }),
                Expires = DateTime.UtcNow.AddMinutes(tokenExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
