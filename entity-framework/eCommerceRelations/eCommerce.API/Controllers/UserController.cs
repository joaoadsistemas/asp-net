using eCommerce.API.Dtos;
using eCommerce.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        
        public UserController(IUserRepository userRepository)
        {
            _userRepository = _userRepository;
        }

        [HttpGet]
        public Task<ActionResult<List<UserDTO>>> GetAll()
        {
            return null;
        }
        
    }
}
