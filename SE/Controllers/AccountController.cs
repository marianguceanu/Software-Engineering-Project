using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SE.DTO.User;
using SE.Exceptions;
using SE.Models;
using SE.Repository.Interfaces;

namespace SE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private User CurrentUser { get; set; } = default!;
        private IUserRepository UserRepository { get; set; } = default!;
        private IUserDestinationRepository UserDestinationRepository { get; set; } = default!;
        private readonly IMapper _mapper;

        public AccountController(IUserRepository userRepository, IUserDestinationRepository userDestinationRepository, IMapper mapper)
        {
            _mapper = mapper;
            UserRepository = userRepository;
            UserDestinationRepository = userDestinationRepository;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await UserRepository.GetAll();
        }

        [HttpPost("register")]
        public async void CreateAccount([FromBody] AddLoginDTO dto)
        {
            var result = await UserRepository.Add(_mapper.Map<User>(dto));
            if (!result)
            {
                throw new DataValidationException();
            }
        }

        [HttpDelete("remove/{username}")]
        public async void RemoveAccount([FromRoute] string username, [FromBody] string password)
        {
            var user = await UserRepository.GetUserByUsernameAndPassword(username, password);
            await UserRepository.Delete(CurrentUser);
        }

        [HttpPut("modify")]
        public async void ModifyAccount([FromBody] ModifyAccountDTO dto)
        {
            if (CurrentUser.Username != dto.Username)
            {
                throw new AuthorizationException();
            }
            CurrentUser.Password = dto.NewPassword;
            await UserRepository.Update(CurrentUser);
        }

        [HttpPost("login")]
        public async Task<User?> Login([FromBody] AddLoginDTO dto)
        {
            var user = await UserRepository.GetUserByUsernameAndPassword(dto.Username, dto.Password);
            if (user == null)
            {
                throw new AuthenticationException();
            }
            return user;
        }

        [HttpPost("logout")]
        public void Logout()
        {
            CurrentUser = null!;
        }
    }
}