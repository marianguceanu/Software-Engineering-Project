using Microsoft.EntityFrameworkCore;
using SE.Data;
using SE.Models;
using SE.Repository.Interfaces;

namespace SE.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Task<User?> GetUserById(int id)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        public Task<User?> GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Username.Equals(username));
        }

        public Task<User?> GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Username.Equals(username) && u.Password.Equals(password));
        }

        public Task<List<UserDestination>> GetUserDestinations(int userId)
        {
            return _context.UserDestinations.Where(ud => ud.UserId.Equals(userId)).ToListAsync();
        }
    }
}