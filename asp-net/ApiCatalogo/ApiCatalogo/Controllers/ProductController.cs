using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogo.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        [HttpGet]
        // utlizando queryparams, para passar dados de paginação e busca por nome
        public async Task<ActionResult<IEnumerable<ProductDTO>>> FindAll([FromQuery] PageQueryParams pageQueryParams)
        {
            return Ok(await _unitOfWork.ProductRepository.FindAllProductsAsync(pageQueryParams));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> FindById(long id)
        {
            try
            {
                ProductDTO result = await _unitOfWork.ProductRepository.FindProductByIdAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }

        [Authorize(Policy = "UserOnly")]
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> InsertProduct([FromBody] ProductInsertDTO dto)
        {
            ProductDTO result = _unitOfWork.ProductRepository.InsertProduct(dto);
            await _unitOfWork.CommitAsync();

            return CreatedAtAction(nameof(FindById), new { id = result.Id }, result);
        }

        [Authorize(Policy = "UserOnly")]
        [HttpPut("{id}")]
        public async Task<ActionResult<dynamic>> UpdateProduct([FromBody] ProductInsertDTO dto, long id)
        {
            try
            {
                _unitOfWork.ProductRepository.UpdateProduct(dto, id);
                await _unitOfWork.CommitAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }


        [Authorize(Policy = "UserOnly")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<dynamic>> DeleteProduct(long id)
        {
            try
            {
                _unitOfWork.ProductRepository.DeleteProduct(id);
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
