using eCommerce.API.Dtos;
using eCommerce.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAll()
        {
                return Ok(await _userRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> FindById(int id)
        {
            try
            {
                UserDTO result = await _userRepository.GetById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }


        [HttpPost]
        public async Task<ActionResult<dynamic>> PostUser([FromBody] UserInsertDTO dto)
        {
            _userRepository.Insert(dto);
            return NoContent();
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<dynamic>> UpdateUser([FromBody] UserInsertDTO dto, int id)
        {
            try
            {
                _userRepository.Update(dto, id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<dynamic>> DeleteUser(int id)
        {
            try
            {
                _userRepository.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }
    }
}

