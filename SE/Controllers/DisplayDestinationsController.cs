using Microsoft.AspNetCore.Mvc;
using SE.Exceptions;
using SE.Models;
using SE.Repository.Interfaces;

namespace SE.Controllers
{
    // TODO: Add DTO's for returning the users/destinations
    [ApiController]
    [Route("api/[controller]")]
    public class DisplayDestinationsController : ControllerBase
    {
        private IDestinationRepository _destinationRepository;
        private IUserRepository _userRepository;
        private IUserDestinationRepository _userDestinationRepository;
        private User _currentUser = default!;

        public DisplayDestinationsController(IDestinationRepository destinationRepository, IUserRepository userRepository, IUserDestinationRepository userDestinationRepository)
        {
            _userDestinationRepository = userDestinationRepository;
            _userRepository = userRepository;
            _destinationRepository = destinationRepository;
        }

        [HttpGet("get/public/{username}")]
        public async Task<List<Destination>> GetPublicDestinations([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                throw new AuthenticationException();
            }
            _currentUser = user;
            if (_currentUser.Type != "admin")
            {
                throw new AuthorizationException();
            }

            var publicUD = await _userDestinationRepository.GetUserDestinationsByUserId(_currentUser.Id);
            var publicDestinations = new List<Destination>();
            if (publicUD == null)
            {
                throw new DataValidationException();
            }

            foreach (var ud in publicUD)
            {
                var destination = await _destinationRepository.GetById(ud.DestinationId);
                if (destination == null)
                {
                    throw new DataValidationException();
                }
                publicDestinations.Add(destination);
            }

            return publicDestinations;
        }

        [HttpGet("get/private/{username}")]
        public async Task<List<Destination>> GetPrivateDestinations([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                throw new AuthenticationException();
            }
            _currentUser = user;
            if (_currentUser.Type != "normal")
            {
                throw new AuthorizationException();
            }

            var privateUD = await _userDestinationRepository.GetUserDestinationsByUserId(_currentUser.Id);
            var privateDestinations = new List<Destination>();
            if (privateUD == null)
            {
                throw new DataValidationException();
            }

            foreach (var ud in privateUD)
            {
                var destination = await _destinationRepository.GetById(ud.DestinationId);
                if (destination == null)
                {
                    throw new DataValidationException();
                }
                privateDestinations.Add(destination);
            }

            return privateDestinations;
        }
    }
}