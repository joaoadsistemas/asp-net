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

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        
        [HttpGet]
        // utlizando queryparams, se eu nao passsar nada, o nome vai ser uma string vazia, se nao vai ser o valor que passei
        public async Task<ActionResult<List<ProductDTO>>> FindAll([FromQuery] string name = "")
        {
            return Ok(_productRepository.FindAllProducts(name));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> FindById(long id)
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
        public async Task<ActionResult<ProductDTO>> InsertProduct([FromBody] ProductInsertDTO dto)
        {
            ProductDTO result = await _productRepository.InsertProduct(dto);
            return CreatedAtAction(nameof(FindById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<dynamic>> UpdateProduct([FromBody] ProductInsertDTO dto, long id)
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
        public async Task<ActionResult<dynamic>> DeleteProduct(long id)
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
