using DSCommerce.Dto;
using DSCommerce.Entities;
using DSCommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<List<PaymentDTO>>> FindAllUsers()
        {
            return Ok(_paymentRepository.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDTO>> FindUserById(long id)
        {
            return Ok(_paymentRepository.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDTO>> InsertUser([FromBody] PaymentDTO dto)
        {
            dto = await _paymentRepository.Insert(dto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentDTO>> UpdateUser(long id, [FromBody] PaymentDTO dto)
        {
            return Ok(_paymentRepository.Update(dto, id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUserById(long id)
        {
            await _paymentRepository.DeleteById(id);
            return NoContent();
        }
    }
}
