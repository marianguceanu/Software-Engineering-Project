using SE.Models;

namespace SE.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User?> GetUserByUsername(string username);
        public Task<User?> GetUserById(int id);
        public Task<User?> GetUserByUsernameAndPassword(string username, string password);
        public Task<List<UserDestination>> GetUserDestinations(int userId);
    }
}