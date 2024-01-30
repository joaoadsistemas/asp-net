using DSCommerce.Dto;
using DSCommerce.Entities;
using DSCommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>Collection of products</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductDTO>>> FindAllProducts()
        {
            return Ok(_productRepository.FindAll());
        }

        /// <summary>
        /// Get a product by ID
        /// </summary>
        /// <param name="id">Product identifier</param>
        /// <returns>Product data</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> FindProductById(long id)
        {
            try
            {
                var product = await _productRepository.FindById(id);
                return Ok(product);
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }

        /// <summary>
        /// Insert a new product
        /// </summary>
        /// <remarks>
        ///{"name": "Kindle","description": "Kindle Book","price": 200.0,"imgUrl": "https://img.com","categoriesIds": [ 1,2] }
        /// </remarks>
        /// <param name="dto">Product data</param>
        /// <returns>Status Code Created</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ProductInsertDTO>> InsertProduct([FromBody] ProductInsertDTO dto)
        {
            dto = await _productRepository.Insert(dto);
            return Created();
        }

        /// <summary>
        /// Update a product by ID
        /// </summary>
        /// <remarks>
        ///{"name": "Kindle","description": "Kindle Book","price": 200.0,"imgUrl": "https://img.com","categoriesIds": [ 1,2] }
        /// </remarks>
        /// <param name="id">Product identifier</param>
        /// <param name="dto">Product data</param>
        /// <returns>Updated product</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(long id, [FromBody] ProductInsertDTO dto)
        {
            try
            {
                var product = _productRepository.Update(dto, id);
                return Ok(product);
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }

        /// <summary>
        /// Delete a product by ID
        /// </summary>
        /// <param name="id">Product identifier</param>
        /// <returns>Nothing</returns>
        /// <response code="204">Success</response>
        /// <response code="404">Not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteProductById(long id)
        {
            try
            {
                await _productRepository.DeleteById(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }
    }
}
