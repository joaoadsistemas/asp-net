using DSCommerce.Dto;
using DSCommerce.Entities;
using DSCommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSCommerce.Controllers
{
    [Route("/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> FindAllUsers()
        {
            return Ok( _userRepository.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> FindUserById(long id)
        {
            return Ok(_userRepository.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> InsertUser([FromBody] UserInsertDTO dto)
        {
            dto = await _userRepository.Insert(dto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUser(long id, [FromBody] UserInsertDTO dto)
        {
            return Ok(_userRepository.Update(dto, id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUserById(long id)
        {
            await _userRepository.DeleteById(id);
            return NoContent();
        }
    }
}
