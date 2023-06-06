using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SE.DTO.Destination;
using SE.Exceptions;
using SE.Models;
using SE.Repository.Interfaces;

namespace SE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisplayDestinationsController : ControllerBase
    {
        private IDestinationRepository _destinationRepository;
        private IUserRepository _userRepository;
        private IUserDestinationRepository _userDestinationRepository;
        private readonly IMapper _mapper;
        private User _currentUser = default!;

        public DisplayDestinationsController(IMapper mapper, IDestinationRepository destinationRepository, IUserRepository userRepository, IUserDestinationRepository userDestinationRepository)
        {
            _userDestinationRepository = userDestinationRepository;
            _userRepository = userRepository;
            _destinationRepository = destinationRepository;
            _mapper = mapper;
        }

        [HttpGet("get/public/")]
        public async Task<List<DestinationDTO>> GetPublicDestinations()
        {
            var destinations = await _destinationRepository.GetPublicDestinations();
            return _mapper.Map<List<DestinationDTO>>(destinations);
        }

        [HttpGet("get/private/{username}")]
        public async Task<List<DestinationDTO>> GetPrivateDestinations([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                throw new AuthenticationException();
            }
            _currentUser = user;

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

            return _mapper.Map<List<DestinationDTO>>(privateDestinations);
        }
    }
}