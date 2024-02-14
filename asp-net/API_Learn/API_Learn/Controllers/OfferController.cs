using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories;
using DSLearn.Controllers.Utils;
using DSLearn.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSLearn.Controllers
{
    [Route("offers")]
    [ApiController]
    public class OfferController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public OfferController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferDTO>>> FindAll([FromQuery] PageQueryParams pageQueryParams)
        {
            return Ok(await _unitOfWork.OfferRepository.FindAllAsync(pageQueryParams));

        }

        [HttpGet("id")]
        public async Task<ActionResult<dynamic>> FindById(int id)
        {
            try
            {
                OfferDTO result = await _unitOfWork.OfferRepository.FindByIdAsync(id);
                return Ok(result);
            }
            catch (ArgumentException ex) { return ErrorMessages.ErrorMessage(id); }
        }

        [HttpPost("insert-user-to-offer")]
        public async Task<ActionResult<dynamic>> Insert([FromBody] OfferUserInsertDTO dto)
        {
            OfferDTO result = await _unitOfWork.OfferRepository.InsertUserToOffer(dto);
            await _unitOfWork.CommitAsync();

            return CreatedAtAction(nameof(FindById), new { Id = result.Id }, result);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<dynamic>> Insert([FromBody] OfferInsertDTO dto)
        {
            OfferDTO result = _unitOfWork.OfferRepository.Insert(dto);
            await _unitOfWork.CommitAsync();

            return CreatedAtAction(nameof(FindById), new { Id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<dynamic>> Update([FromBody] OfferInsertDTO dto, int id)
        {
            try
            {
                OfferDTO result = _unitOfWork.OfferRepository.Update(dto, id);
                await _unitOfWork.CommitAsync();
                return Ok(result);
            }
            catch (ArgumentException ex) { return ErrorMessages.ErrorMessage(id); }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<dynamic>> Delete(int id)
        {
            try
            {
                _unitOfWork.OfferRepository.Delete(id);
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

