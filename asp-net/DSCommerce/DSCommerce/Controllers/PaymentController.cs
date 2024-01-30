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
    [Route("/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly PaymentRepository _paymentRepository;

        public PaymentController(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        /// <summary>
        /// Get all payments
        /// </summary>
        /// <returns>Collection of payments</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PaymentDTO>>> FindAllPayments()
        {
            try
            {
                var payment = _paymentRepository.FindAll();
                return Ok(payment);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {e.Message}");
            }
        }

        /// <summary>
        /// Get a payment
        /// </summary>
        /// <param name="id">Payment identifier</param>
        /// <returns>Payment data</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentDTO>> FindPaymentById(long id)
        {
            try
            {
                var payment = _paymentRepository.FindById(id);
                return Ok(payment);
            }
            catch (Exception e)
            {
                return NotFound("Resource Not Found");
            }
        }

        /// <summary>
        /// Register a payment
        /// </summary>
        /// <remarks>
        /// { "moment": "2024-01-28T16:59:32.848Z","orderId": 1}
        /// </remarks>
        /// <param name="dto">Payment data</param>
        /// <returns>Status Code Created</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<PaymentInsertDTO>> InsertPayment([FromBody] PaymentInsertDTO dto)
        {
            try
            {
                dto = await _paymentRepository.Insert(dto);
                return Created();
            }
            catch (Exception e)
            {
                return NotFound("Resource Not Found");
            }
        }

        /// <summary>
        /// Update payment
        /// </summary>
        /// <remarks>
        /// { "moment": "2024-01-28T16:59:32.848Z","orderId": 1}
        /// </remarks>
        /// <param name="id">Payment identifier</param>
        /// <param name="dto">Payment data</param>
        /// <returns>Payment</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentDTO>> UpdatePayment(long id, [FromBody] PaymentInsertDTO dto)
        {
            try
            {
                var payment = _paymentRepository.Update(dto, id);
                return Ok(payment);
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }

        /// <summary>
        /// Delete a Payment
        /// </summary>
        /// <param name="id">Payment identifier</param>
        /// <returns>Nothing</returns>
        /// <response code="204">Success</response>
        /// <response code="404">Not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeletePaymentById(long id)
        {
            try
            {
                await _paymentRepository.DeleteById(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Resource not found");
            }
        }
    }
}
