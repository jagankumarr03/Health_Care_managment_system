using UserService.DTOs;

namespace UserService.Services
{
    public interface IUserService
    {
        Task<UserDto> Register(RegisterDto registerDto);

        Task<string> Login(LoginDto loginDto);
    }
}