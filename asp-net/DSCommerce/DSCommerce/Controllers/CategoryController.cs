using DSCommerce.Dto;
using DSCommerce.Entities;
using DSCommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSCommerce.Controllers
{
    [Route("/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly CategoryRepository _categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>Collection of categories</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryDTO>>> FindAllUsers()
        {
            return Ok(_categoryRepository.FindAll());
        }


        /// <summary>
        /// Get a category
        /// </summary>
        /// <param name="id">Category identifier</param>
        /// <returns>Category data</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDTO>> FindUserById(long id)
        {
            try
            {
                var category = _categoryRepository.FindById(id);
                return Ok(category);
            }
            catch (Exception e)
            {
                return NotFound("Resource Not Found");
            }
        }


        /// <summary>
        /// Register a category
        /// </summary>
        /// <remarks>
        /// {"name": "clothes"}
        /// </remarks>
        /// <param name="dto">Category data</param>
        /// <returns>Status Code Created</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CategoryInsertDTO>> InsertUser([FromBody] CategoryInsertDTO dto)
        {
            dto = await _categoryRepository.Insert(dto);
            return Created();
        }


        /// <summary>
        /// Update category
        /// </summary>
        /// <remarks>
        /// {"name": "clothes"}
        /// </remarks>
        /// <param name="id">Category identifier</param>
        /// <param name="dto">Category data</param>
        /// <returns>User</returns>
        /// <response code="204">Success</response>
        /// <response code="404">Not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDTO>> UpdateUser(long id, [FromBody] CategoryInsertDTO dto)
        {
            try
            {
                var category = _categoryRepository.Update(dto, id);
                return Ok(category);
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }


        /// <summary>
        /// Delete a Category
        /// </summary>
        /// <param name="id">Category identifier</param>
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
                await _categoryRepository.DeleteById(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }
    }
}
