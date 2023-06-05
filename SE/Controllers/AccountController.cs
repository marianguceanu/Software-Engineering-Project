using Microsoft.AspNetCore.Mvc;
using SE.DTO;
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

        public AccountController(IUserRepository userRepository, IUserDestinationRepository userDestinationRepository)
        {
            UserRepository = userRepository;
            UserDestinationRepository = userDestinationRepository;
        }

        [HttpPost("register")]
        public async void CreateAccount([FromBody] AddLoginDTO dto)
        {
            var result = await UserRepository.Add(new User { Username = dto.Username, Password = dto.Password });
            if (!result)
            {
                throw new DataValidationException();
            }
        }

        [HttpDelete("remove")]
        public async void RemoveAccount([FromBody] string username)
        {
            if (CurrentUser.Username != username)
            {
                throw new AuthorizationException();
            }
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

        [HttpPost("")]
        public async void Login([FromBody] AddLoginDTO dto)
        {
            var user = await UserRepository.GetUserByUsernameAndPassword(dto.Username, dto.Password);
            if (user == null)
            {
                throw new AuthenticationException();
            }
            CurrentUser = user;
        }

        [HttpPost("logout")]
        public void Logout()
        {
            CurrentUser = null!;
        }
    }
}