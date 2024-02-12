using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories;
using DSLearn.Controllers.Utils;
using DSLearn.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DSLearn.Controllers
{
    [Route("notifications")]
    [ApiController]
    public class NotificationController : ControllerBase
    {


        private readonly IUnitOfWork _unitOfWork;

        public NotificationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationDTO>>> FindAll([FromQuery] PageQueryParams pageQueryParams)
        {
            return Ok(await _unitOfWork.NotificationRepository.FindAllAsync(pageQueryParams));

        }

        [HttpGet("id")]
        public async Task<ActionResult<dynamic>> FindById(int id)
        {
            try
            {
                NotificationDTO result = await _unitOfWork.NotificationRepository.FindByIdAsync(id);
                return Ok(result);
            } catch (ArgumentException ex) { return ErrorMessages.ErrorMessage(id); }


        }


        [HttpPost]
        public async Task<ActionResult<dynamic>> Insert([FromBody] NotificationInsertDTO dto)
        {
            NotificationDTO result = _unitOfWork.NotificationRepository.Insert(dto);
            await _unitOfWork.CommitAsync();

            return CreatedAtAction(nameof(FindById), new { Id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<dynamic>> Update([FromBody] NotificationInsertDTO dto, int id)
        {
            try
            {
                NotificationDTO result = _unitOfWork.NotificationRepository.Update(dto, id);
                await _unitOfWork.CommitAsync();
                return Ok(result);
            } catch (ArgumentException ex) { return ErrorMessages.ErrorMessage(id); }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<dynamic>> Delete(int id)
        {
            try
            {
                _unitOfWork.NotificationRepository.Delete(id);
                await _unitOfWork.CommitAsync();
                return NoContent();

            } catch (ArgumentException ex)
            {
                return ErrorMessages.ErrorMessage(id);
            }
        }

    }


  
    
}

