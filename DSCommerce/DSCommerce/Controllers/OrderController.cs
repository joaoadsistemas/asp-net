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
    [Route("/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns>Collection of orders</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<OrderDTO>>> FindAllOrders()
        {
            try
            {
                return Ok(_orderRepository.FindAll());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        /// <summary>
        /// Get an order
        /// </summary>
        /// <param name="id">Order identifier</param>
        /// <returns>Order data</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDTO>> FindOrderById(long id)
        {
            try
            {
                var order = _orderRepository.FindById(id);
                return Ok(order);
            }
            catch (Exception e)
            {
                return NotFound("Resource Not Found");
            }
        }

        /// <summary>
        /// Register an order
        /// </summary>
        /// <remarks>
        /// {"userId": 1, "items": [{"productId": 1, "quantity": 1}]}
        /// </remarks>
        /// <param name="dto">Order data</param>
        /// <returns>Status Code Created</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<OrderDTO>> InsertOrder([FromBody] OrderInsertDTO dto)
        {
            try
            {
                await _orderRepository.Insert(dto);
                return Created();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        /// <summary>
        /// Update order
        /// </summary>
        /// <remarks>
        /// {"userId": 1, "items": [{"productId": 1, "quantity": 1}]}
        /// </remarks>
        /// <param name="id">Order identifier</param>
        /// <param name="dto">Order data</param>
        /// <returns>Order</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDTO>> UpdateOrder(long id, [FromBody] OrderInsertDTO dto)
        {
            try
            {
                var order = _orderRepository.Update(dto, id);
                return Ok(order);
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }

        /// <summary>
        /// Delete an Order
        /// </summary>
        /// <param name="id">Order identifier</param>
        /// <returns>Nothing</returns>
        /// <response code="204">Success</response>
        /// <response code="404">Not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteOrderById(long id)
        {
            try
            {
                await _orderRepository.DeleteById(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }
    }
}
