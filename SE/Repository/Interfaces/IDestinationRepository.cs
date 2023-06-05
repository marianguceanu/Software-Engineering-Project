using SE.Models;

namespace SE.Repository.Interfaces
{
    public interface IDestinationRepository : IGenericRepository<Destination>
    {
        Task<Destination?> GetDestinationById(int id);
        Task<Destination?> GetDestinationByTitle(string title);
        Task<List<UserDestination>> GetUserDestinations(int userId);
    }
}