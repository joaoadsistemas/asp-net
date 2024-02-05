using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories;
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
            return Ok(_unitOfWork.ProductRepository.FindAllProducts(pageQueryParams));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> FindById(long id)
        {
            try
            {
                ProductDTO result = _unitOfWork.ProductRepository.FindProductById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> InsertProduct([FromBody] ProductInsertDTO dto)
        {
            ProductDTO result = _unitOfWork.ProductRepository.InsertProduct(dto);
            _unitOfWork.Commit();

            return CreatedAtAction(nameof(FindById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<dynamic>> UpdateProduct([FromBody] ProductInsertDTO dto, long id)
        {
            try
            {
                _unitOfWork.ProductRepository.UpdateProduct(dto, id);
                _unitOfWork.Commit();
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<dynamic>> DeleteProduct(long id)
        {
            try
            {
                _unitOfWork.ProductRepository.DeleteProduct(id);
                _unitOfWork.Commit();
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }

    }
}
