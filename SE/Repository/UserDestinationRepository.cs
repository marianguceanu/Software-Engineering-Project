using Microsoft.EntityFrameworkCore;
using SE.Data;
using SE.Models;
using SE.Repository.Interfaces;

namespace SE.Repository
{
    public class UserDestinationRepository : GenericRepository<UserDestination>, IUserDestinationRepository
    {
        private readonly DataContext _context;
        public UserDestinationRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Task<UserDestination?> GetUserDestinationById(int userId, int destinationId)
        {
            return _context.UserDestinations.FirstOrDefaultAsync(ud => ud.UserId.Equals(userId) && ud.DestinationId.Equals(destinationId));
        }


        public Task<List<UserDestination>> GetUserDestinations()
        {
            return _context.UserDestinations.ToListAsync();
        }

        public Task<List<UserDestination>> GetUserDestinationsByUserId(int userId)
        {
            return _context.UserDestinations.Where(ud => ud.UserId.Equals(userId)).ToListAsync();
        }

        public Task<List<UserDestination>> GetUserDestinationsByDestinationId(int destinationId)
        {
            return _context.UserDestinations.Where(ud => ud.DestinationId.Equals(destinationId)).ToListAsync();
        }
    }
}