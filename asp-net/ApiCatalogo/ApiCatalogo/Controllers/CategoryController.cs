using ApiCatalogo.Dtos;
using ApiCatalogo.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogo.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> FindAllCategories()
        {
            return Ok(await _unitOfWork.CategoryRepository.FindAllCategoriesAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> FindCategoryById(long id) 
        {
            try
            {
                CategoryDTO result =await  _unitOfWork.CategoryRepository.FindCategoryByIdAsync(id);
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
            CategoryDTO result = _unitOfWork.CategoryRepository.InsertCategory(dto);
            await _unitOfWork.CommitAsync();
            return CreatedAtAction(nameof(FindCategoryById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<dynamic>> UpdateCategory([FromBody] CategoryInsertDTO dto, int id)
        {
            try
            {
                _unitOfWork.CategoryRepository.UpdateCategory(dto, id);
                await _unitOfWork.CommitAsync();
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
                _unitOfWork.CategoryRepository.DeleteCategory(id);
                await _unitOfWork.CommitAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }
    }
}
