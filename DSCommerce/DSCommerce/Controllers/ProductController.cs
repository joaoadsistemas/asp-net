using DSCommerce.Dto;
using DSCommerce.Entities;
using DSCommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSCommerce.Controllers
{
    [Route("/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> FindAllUsers()
        {
            return Ok(_productRepository.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> FindUserById(long id)
        {
            return Ok(_productRepository.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> InsertUser([FromBody] ProductDTO dto)
        {
            dto = await _productRepository.Insert(dto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateUser(long id, [FromBody] ProductDTO dto)
        {
            return Ok(_productRepository.Update(dto, id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUserById(long id)
        {
            await _productRepository.DeleteById(id);
            return NoContent();
        }
    }
}
