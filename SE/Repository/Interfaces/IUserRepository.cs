using SE.Models;

namespace SE.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetUserByUsername(string username);
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByUsernameAndPassword(string username, string password);
        Task<List<UserDestination>> GetUserDestinations(int userId);
    }
}