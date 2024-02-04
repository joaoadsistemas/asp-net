using ApiCatalogo.Dtos;
using ApiCatalogo.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogo.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> FindAllCategories()
        {
            return Ok(_categoryRepository.FindAllCategories());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> FindCategoryById(long id) 
        {
            try
            {
                CategoryDTO result = _categoryRepository.FindCategoryById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> InsertCategory([FromBody] CategoryInsertDTO dto)
        {
            CategoryDTO result = _categoryRepository.InsertCategory(dto);
            return CreatedAtAction(nameof(FindCategoryById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<dynamic>> UpdateCategory([FromBody] CategoryInsertDTO dto, int id)
        {
            try
            {
                _categoryRepository.UpdateCategory(dto, id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<dynamic>> DeleteById(int id)
        {
            try
            {
                _categoryRepository.DeleteCategory(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }
    }
}
