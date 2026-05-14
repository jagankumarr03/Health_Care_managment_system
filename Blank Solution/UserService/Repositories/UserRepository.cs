using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Models;

namespace UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;

        }
        public async Task<User> GetUser(string username, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x =>
                    x.Username == username &&
                    x.Password == password);
        }
    }
}