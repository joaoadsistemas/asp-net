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

        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> FindAllUsers()
        {
            return Ok(_categoryRepository.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> FindUserById(long id)
        {
            return Ok(_categoryRepository.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<CategoryInsertDTO>> InsertUser([FromBody] CategoryInsertDTO dto)
        {
            dto = await _categoryRepository.Insert(dto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO>> UpdateUser(long id, [FromBody] CategoryInsertDTO dto)
        {
            return Ok(_categoryRepository.Update(dto, id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUserById(long id)
        {
            await _categoryRepository.DeleteById(id);
            return NoContent();
        }
    }
}
