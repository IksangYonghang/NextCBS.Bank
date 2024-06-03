using Meeting.Module.Services;
using Microsoft.AspNetCore.Mvc;
using NextCBS.Bank.Contracts.Models.Identity; 
using NextCBS.Bank.Module.IRepositories;
using NextCBS.Bank.Module.Models;

namespace NextCBS.Bank.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserService _userService;

        public UserController(IUserRepository userRepository, UserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsersAsync()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> UpsertUserAsync(UserModel userModel)
        {
            
                var user = await _userService.UpsertUserAsync(userModel);
                return Ok(user);
        
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<IdentityUserModel>> GetUserAsync(string guid)
        {
            var user = await _userService.GetUserAsync(guid);
            return Ok(user);
        }
    }
}
