using UserService.Models;

namespace UserService.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> GetUser(string username, string password);
    }
}