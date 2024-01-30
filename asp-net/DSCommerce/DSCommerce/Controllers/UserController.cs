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


        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>Collection of users</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserDTO>>> FindAllUsers()
        {
            return Ok(_userRepository.FindAll());
        }


        /// <summary>
        /// Get a user
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns>User data</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDTO>> FindUserById(long id)
        {
            try
            {
                var user = await _userRepository.FindById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound("Resource not Found");
            }
        }

        /// <summary>
        /// Register a user
        /// </summary>
        /// <remarks>
        /// {"name": "Luan", "email": "luan@gmail.com", "password": "123456", "phone": "21991431254", "birthDate":"2024-01-28T16:22:16.479Z"}
        /// </remarks>
        /// <param name="dto">User data</param>
        /// <returns>Status Code Created</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<UserDTO>> InsertUser([FromBody] UserInsertDTO dto)
        {
            dto = await _userRepository.Insert(dto);
            return Created();
        }


        /// <summary>
        /// Update user
        /// </summary>
        /// <remarks>
        /// {"name": "Luan", "email": "luan@gmail.com", "password": "123456", "phone": "21991431254", "birthDate":"2024-01-28T16:22:16.479Z"}
        /// </remarks>
        /// <param name="id">User identifier</param>
        /// <param name="dto">User data</param>
        /// <returns>User</returns>
        /// <response code="204">Success</response>
        /// <response code="404">Not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDTO>> UpdateUser(long id, [FromBody] UserInsertDTO dto)
        {
            try
            {
                var user = _userRepository.Update(dto, id);
                return Ok(user);
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }

        /// <summary>
        /// Delete a User
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns>Nothing</returns>
        /// <response code="204">Success</response>
        /// <response code="404">Not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteUserById(long id)
        {
            try
            {
                await _userRepository.DeleteById(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }
    }
}
