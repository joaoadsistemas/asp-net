using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogo.Controllers
{

    // controle de versão
    [Route("v{version:apiVersion}/products")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        // utlizando queryparams, para passar dados de paginação e busca por nome
        public async Task<ActionResult<IEnumerable<ProductDTO>>> FindAll([FromQuery] PageQueryParams pageQueryParams)
        {
            try
            {
                return Ok(await _unitOfWork.ProductRepository.FindAllProductsAsync(pageQueryParams));
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ProductDTO>> InsertProduct([FromBody] ProductInsertDTO dto)
        {
            try
            {
                ProductDTO result = _unitOfWork.ProductRepository.InsertProduct(dto);
                await _unitOfWork.CommitAsync();

                return CreatedAtAction(nameof(FindById), new { id = result.Id }, result);
            } catch (Exception e)
            {
                return BadRequest("Not a possible created");
            }
        }

        [Authorize(Policy = "UserOnly")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
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
