using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories;
using DSLearn.Controllers.Utils;
using DSLearn.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSLearn.Controllers
{
    [Route("contents")]
    [ApiController]
    public class ContentController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ContentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentDTO>>> FindAll([FromQuery] PageQueryParams pageQueryParams)
        {
            return Ok(await _unitOfWork.ContentRepository.FindAllAsync(pageQueryParams));

        }

        [HttpGet("id")]
        public async Task<ActionResult<dynamic>> FindById(int id)
        {
            try
            {
                ContentDTO result = await _unitOfWork.ContentRepository.FindByIdAsync(id);
                return Ok(result);
            }
            catch (ArgumentException ex) { return ErrorMessages.ErrorMessage(id); }
        }


        [HttpPost]
        //[Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<dynamic>> Insert([FromBody] ContentInsertDTO dto)
        {
            ContentDTO result = _unitOfWork.ContentRepository.Insert(dto);
            await _unitOfWork.CommitAsync();

            return CreatedAtAction(nameof(FindById), new { Id = result.Id }, result);
        }

        [HttpPut("{id}")]
       // [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<dynamic>> Update([FromBody] ContentInsertDTO dto, int id)
        {
            try
            {
                ContentDTO result = _unitOfWork.ContentRepository.Update(dto, id);
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
                _unitOfWork.ContentRepository.Delete(id);
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

