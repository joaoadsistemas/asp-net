using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories;
using DSLearn.Controllers.Utils;
using DSLearn.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSLearn.Controllers
{
    [Route("topics")]
    [ApiController]
    public class TopicController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public TopicController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicDTO>>> FindAll([FromQuery] PageQueryParams pageQueryParams)
        {
            return Ok(await _unitOfWork.TopicRepository.FindAllAsync(pageQueryParams));

        }

        [HttpGet("id")]
        public async Task<ActionResult<dynamic>> FindById(int id)
        {
            try
            {
                TopicDTO result = await _unitOfWork.TopicRepository.FindByIdAsync(id);
                return Ok(result);
            }
            catch (ArgumentException ex) { return ErrorMessages.ErrorMessage(id); }
        }


        [HttpPost]
        //[Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<dynamic>> Insert([FromBody] TopicInsertDTO dto)
        {
            TopicDTO result = _unitOfWork.TopicRepository.Insert(dto);
            await _unitOfWork.CommitAsync();

            return CreatedAtAction(nameof(FindById), new { Id = result.Id }, result);
        }

        [HttpPut("{id}")]
       //[Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<dynamic>> Update([FromBody] TopicInsertDTO dto, int id)
        {
            try
            {
                TopicDTO result = _unitOfWork.TopicRepository.Update(dto, id);
                await _unitOfWork.CommitAsync();
                return Ok(result);
            }
            catch (ArgumentException ex) { return ErrorMessages.ErrorMessage(id); }
        }

        [HttpDelete("{id}")]
        //[Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<dynamic>> Delete(int id)
        {
            try
            {
                _unitOfWork.TopicRepository.Delete(id);
                await _unitOfWork.CommitAsync();
                return NoContent();

            }
            catch (ArgumentException ex)
            {
                return ErrorMessages.ErrorMessage(id);
            }
        }

    }
}

