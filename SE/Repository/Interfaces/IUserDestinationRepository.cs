using SE.Models;

namespace SE.Repository.Interfaces
{
    public interface IUserDestinationRepository : IGenericRepository<UserDestination>
    {
        Task<UserDestination?> GetUserDestinationById(int userId, int destinationId);
        Task<List<UserDestination>> GetUserDestinations();
        Task<List<UserDestination>> GetUserDestinationsByUserId(int userId);
        Task<List<UserDestination>> GetUserDestinationsByDestinationId(int destinationId);
    }
}