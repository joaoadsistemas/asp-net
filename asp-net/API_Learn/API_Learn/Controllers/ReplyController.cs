using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories;
using DSLearn.Controllers.Utils;
using DSLearn.Dtos;
using DSLearn.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DSLearn.Controllers
{
    [Route("replies")]
    [ApiController]
    public class ReplyController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ReplyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReplyDTO>>> FindAll([FromQuery] PageQueryParams pageQueryParams)
        {
            return Ok(await _unitOfWork.ReplyRepository.FindAllAsync(pageQueryParams));

        }

        [HttpGet("id")]
        public async Task<ActionResult<dynamic>> FindById(int id)
        {
            try
            {
                ReplyDTO result = await _unitOfWork.ReplyRepository.FindByIdAsync(id);
                return Ok(result);
            }
            catch (ArgumentException ex) { return ErrorMessages.ErrorMessage(id); }
        }


        [HttpPost]
        //[Authorize(Policy = "StudentOnly")]
        public async Task<ActionResult<dynamic>> Insert([FromBody] ReplyInsertDTO dto)
        {

            ReplyDTO result = _unitOfWork.ReplyRepository.Insert(dto);
            await _unitOfWork.CommitAsync();

            return CreatedAtAction(nameof(FindById), new { Id = result.Id }, result);
        }

        [HttpPut("{id}")]
       //[Authorize(Policy = "StudentOnly")]
        public async Task<ActionResult<dynamic>> Update([FromBody] ReplyInsertDTO dto, int id)
        {
            try
            {
                ReplyDTO result = _unitOfWork.ReplyRepository.Update(dto, id);
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

