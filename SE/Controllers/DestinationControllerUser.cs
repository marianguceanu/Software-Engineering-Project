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
    public class DestinationControllerUser : ControllerBase
    {
        private IDestinationRepository _destinationRepository;
        private IUserRepository _userRepository;
        private IUserDestinationRepository _userDestinationRepository;
        private IMapper _mapper;
        private User _currentUser = default!;
        public DestinationControllerUser(IDestinationRepository destinationRepository, IUserDestinationRepository userDestinationRepository, IUserRepository userRepository, IMapper mapper)
        {
            _destinationRepository = destinationRepository;
            _userDestinationRepository = userDestinationRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("normal/add/public/{username}")]
        public async void AddPublicDestination([FromRoute] string username, [FromBody] int PublicDestId)
        {
            // Validating the user

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

            var destination = await _destinationRepository.GetById(PublicDestId);
            if (destination == null)
            {
                throw new DataValidationException();
            }
            destination.Id = 0;

            var destToAdd = _mapper.Map<Destination>(destination);
            destToAdd.isPrivate = true;
            await _destinationRepository.Add(destToAdd);
            await _userDestinationRepository.Add(new UserDestination { UserId = _currentUser.Id, DestinationId = destToAdd.Id });
        }


        [HttpPost("normal/add/private/{username}")]
        public async void AddPrivateDestination([FromRoute] string username, [FromBody] DestinationDTO destination)
        {
            // Validating the user

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

            var Destination = _mapper.Map<Destination>(destination);
            Destination.isPrivate = true;
            await _destinationRepository.Add(Destination);
            await _userDestinationRepository.Add(new UserDestination { UserId = _currentUser.Id, DestinationId = Destination.Id });
        }


        [HttpDelete("normal/remove/{username}")]
        public async void RemoveDestination([FromRoute] string username, [FromBody] int DestId)
        {
            // Validating the user

            var user = await _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                throw new AuthenticationException();
            }
            _currentUser = user;

            var destination = await _destinationRepository.GetById(DestId);
            if (destination == null || !destination.isPrivate)
            {
                throw new DataValidationException();
            }
            await _userDestinationRepository.Delete(new UserDestination { UserId = _currentUser.Id, DestinationId = destination.Id });
        }


        [HttpPut("normal/modify/{username}")]
        public async void ModifyDestination([FromRoute] string username, [FromBody] DestinationDTO destination)
        {
            // Validating the user

            var user = await _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                throw new AuthenticationException();
            }
            _currentUser = user;

            var Destination = _mapper.Map<Destination>(destination);

            var userDestination = await _userDestinationRepository.GetUserDestinationById(_currentUser.Id, Destination.Id);
            if (userDestination == null || !Destination.isPrivate)
            {
                throw new AuthorizationException();
            }
            await _destinationRepository.Update(Destination);
        }
    }
}