using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories;
using DSLearn.Dtos;
using DSLearn.Entities;
using DSLearn.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSLearn.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> FindAll([FromQuery] PageQueryParams pageQueryParams)
        {
            return Ok(await _unitOfWork.UserRepository.FindAllAsync(pageQueryParams));

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> FindById(string id)
        {
            try
            {
                UserDTO result = await _unitOfWork.UserRepository.FindByIdAsync(id);
                return Ok(result);

            } catch (ArgumentException ex) 
            {
                return BadRequest($"Id {id} does not exists");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<dynamic>> Insert([FromBody] RegisterUserDTO registerUserDTO, string id)
        {
            try
            {

                await _unitOfWork.UserRepository.UpdateAsync(registerUserDTO, id);
                await _unitOfWork.CommitAsync();
                return NoContent();

            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Id {id} does not exists");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<dynamic>> Delete(string id)
        {
            try
            {

                await _unitOfWork.UserRepository.DeleteAsync(id);
                await _unitOfWork.CommitAsync();
                return NoContent();

            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Id {id} does not exists");
            }
        }

    }
}
