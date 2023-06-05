using Microsoft.EntityFrameworkCore;
using SE.Data;
using SE.Models;
using SE.Repository.Interfaces;

namespace SE.Repository
{
    public class DestinationRepository : GenericRepository<Destination>, IDestinationRepository
    {
        private readonly DataContext _context;
        public DestinationRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Task<Destination?> GetDestinationById(int id)
        {
            return _context.Destinations.FirstOrDefaultAsync(d => d.Id.Equals(id));
        }

        public Task<Destination?> GetDestinationByTitle(string title)
        {
            return _context.Destinations.FirstOrDefaultAsync(d => d.Title.Equals(title));
        }

        public Task<List<UserDestination>> GetUserDestinations(int userId)
        {
            return _context.UserDestinations.Where(ud => ud.UserId.Equals(userId)).ToListAsync();
        }
    }
}