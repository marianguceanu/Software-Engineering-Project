using SE.Models;

namespace SE.Repository.Interfaces
{
    public interface IDestinationRepository : IGenericRepository<Destination>
    {
        Task<List<Destination>> GetPublicDestinations();
        Task<Destination?> GetDestinationById(int id);
        Task<Destination?> GetPrivateDestinationByTitle(string title);
        Task<Destination?> GetPublicDestinationByTitle(string title);
        Task<List<UserDestination>> GetUserDestinations(int userId);
    }
}