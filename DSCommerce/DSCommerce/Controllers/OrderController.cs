using DSCommerce.Dto;
using DSCommerce.Entities;
using DSCommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> FindAllUsers()
        {
            return Ok(_orderRepository.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> FindUserById(long id)
        {
            return Ok(_orderRepository.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> InsertUser([FromBody] OrderSimpleDTO dto)
        {
            await _orderRepository.Insert(dto);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDTO>> UpdateUser(long id, [FromBody] OrderSimpleDTO dto)
        {
            return Ok(_orderRepository.Update(dto, id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUserById(long id)
        {
            await _orderRepository.DeleteById(id);
            return NoContent();
        }
    }
}
