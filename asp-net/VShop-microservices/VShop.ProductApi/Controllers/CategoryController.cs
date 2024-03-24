using BackEndASP.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs.CategoryDTOs;

namespace VShop.ProductApi.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public CategoryController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> FindAll()
        {
            return Ok(await _unitOfWorkRepository.CategoryRepository.FindAll());
        }

        [HttpGet("/products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> FindAllCategoriesWithProducts()
        {
            return Ok(await _unitOfWorkRepository.CategoryRepository.FindAllCategoriesWithProducts());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> FindById(int id)
        {
            try
            {
                return Ok(await _unitOfWorkRepository.CategoryRepository.FindById(id));
            } catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Insert([FromBody] CategoryInsertDTO categoryInsertDTO)
        {
            CategoryDTO categoryDTO = await _unitOfWorkRepository.CategoryRepository.Insert(categoryInsertDTO);
            await _unitOfWorkRepository.CommitAsync();

            return CreatedAtAction(nameof(FindById), new { id = categoryDTO.Id }, categoryDTO);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO>> Update([FromBody] CategoryInsertDTO categoryInsertDTO, int id)
        {
           try
            {
                CategoryDTO categoryDTO = await _unitOfWorkRepository.CategoryRepository.Update(categoryInsertDTO, id);
                await _unitOfWorkRepository.CommitAsync();
                return Ok(categoryDTO);
                
            } catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDTO>> DeleteById(int id)
        {
            try
            {
                CategoryDTO categoryDTO = await _unitOfWorkRepository.CategoryRepository.DeleteById(id);
                await _unitOfWorkRepository.CommitAsync();
                return NoContent();
            } catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
