using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using one_to_many.Dto;
using one_to_many.Repositories;

namespace one_to_many.Controllers
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
        public async Task<ActionResult<List<UserDTO>>> FindAll()
        {
            return Ok(_userRepository.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> FindById(int id)
        {
            return Ok(_userRepository.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> InsertUser([FromBody] UserDTO dto)
        {
            dto = await _userRepository.Insert(dto);
            return CreatedAtAction(nameof(FindById), new { id = dto.Id }, dto); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUser([FromBody] UserDTO dto, int id)
        {
            return Ok(_userRepository.Update(dto, id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUserById(int id)
        {
            await _userRepository.DeleteById(id);
            return NoContent();
        }

    }
}
