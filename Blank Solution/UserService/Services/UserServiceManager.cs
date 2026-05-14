using UserService.DTOs;
using UserService.Models;
using UserService.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserService.Services
{
    public class UserServiceManager : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;

        public UserServiceManager(
            IUserRepository repository,
            IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        // REGISTER
        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            var user = new User
            {
                Username = registerDto.Username,
                Password = registerDto.Password,
                Role = registerDto.Role
            };

            var result = await _repository.AddUser(user);

            return new UserDto
            {
                Username = result.Username,
                Role = result.Role
            };
        }

        // LOGIN + JWT TOKEN
        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _repository.GetUser(
                loginDto.Username,
                loginDto.Password);

            if (user == null)
            {
                return "Invalid Username or Password";
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]));

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}