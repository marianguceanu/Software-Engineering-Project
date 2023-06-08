using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SE.DTO.Destination;
using SE.DTO.User;
using SE.Exceptions;
using SE.Models;
using SE.Repository.Interfaces;

namespace SE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationControllerAdmin : ControllerBase
    {
        private IDestinationRepository _destinationRepository;
        private IUserRepository _userRepository;
        private IUserDestinationRepository _userDestinationRepository;
        private IMapper _mapper;
        private User _currentUser = default!;

        public DestinationControllerAdmin(IDestinationRepository destinationRepository, IUserRepository userRepository, IUserDestinationRepository userDestinationRepository, IMapper mapper)
        {
            _destinationRepository = destinationRepository;
            _userDestinationRepository = userDestinationRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("admin/add/{username}")]
        public async void AddDestination([FromBody] AdminDestinationDTO destination, [FromRoute] string username)
        {
            // Validating the user

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

            var Destination = _mapper.Map<Destination>(destination);
            Destination.isPrivate = false;
            await _destinationRepository.Add(Destination);
            await _userDestinationRepository.Add(new UserDestination { UserId = _currentUser.Id, DestinationId = Destination.Id });
        }


        [HttpDelete("admin/remove/{username}")]
        public async void RemoveDestination([FromBody] int destinationId, [FromRoute] string username)
        {
            // Validating the user

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


            var res = await _destinationRepository.GetDestinationById(destinationId);
            if (res == null)
            {
                throw new DataValidationException();
            }
            await _destinationRepository.Delete(res);
            var userDestinations = await _userDestinationRepository.GetUserDestinationsByDestinationId(destinationId);
            foreach (var userDestination in userDestinations)
            {
                await _userDestinationRepository.Delete(userDestination);
            }
        }


        [HttpPut("admin/modify/{username}/{destinationId:int}")]
        public async void ModifyDestination([FromBody] AdminDestinationDTO destination, [FromRoute] int destinationId, [FromRoute] string username)
        {
            // Validating the user
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

            var Destination = _mapper.Map<Destination>(destination);
            // Validating the destination
            if (destinationId != Destination.Id)
            {
                throw new DataValidationException();
            }
            var res = await _destinationRepository.Update(Destination);
            if (!res)
            {
                throw new DataValidationException();
            }
        }
    }
}