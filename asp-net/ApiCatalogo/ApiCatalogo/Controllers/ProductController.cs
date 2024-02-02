using ApiCatalogo.Dtos;
using ApiCatalogo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogo.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> FindAll()
        {
            return Ok(_productRepository.FindAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> FindById(int id)
        {
            try
            {
                ProductDTO result = await _productRepository.FindProductById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> InsertProduct([FromBody] ProductInsertDTO dto)
        {
            _productRepository.InsertProduct(dto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<dynamic>> UpdateProduct([FromBody] ProductInsertDTO dto, int id)
        {
            try
            {
                _productRepository.UpdateProduct(dto, id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<dynamic>> DeleteProduct(int id)
        {
            try
            {
                _productRepository.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }

    }
}
