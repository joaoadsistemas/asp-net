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
        private readonly UserManager<User> _userManager;

        public ReplyController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
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
        [Authorize(Policy = "StudentOnly")]
        public async Task<ActionResult<dynamic>> Insert([FromBody] ReplyInsertDTO dto)
        {

            ReplyDTO result = _unitOfWork.ReplyRepository.Insert(dto);
            await _unitOfWork.CommitAsync();

            return CreatedAtAction(nameof(FindById), new { Id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "StudentOnly")]
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
        [Authorize(Policy = "StudentOnly")]
        public async Task<ActionResult<dynamic>> Delete(int id)
        {
            try
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;

                // Obter o ID único do usuário a partir das reivindicações de identidade
                var userLoggedId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                // Buscar informações do usuário utilizando o UserManager
                var userLogged = await _userManager.FindByIdAsync(userLoggedId);

                // verifica as roles do usuário
                var rolesUserLogged = await _userManager.GetRolesAsync(userLogged);

                // pega a reply com base no id passado
                ReplyDTO reply = await _unitOfWork.ReplyRepository.FindByIdAsync(id);

                // verifica se o author da reply não é igual ao do usuário, ou se ele não tem role admin
                if (!userLoggedId.Equals(reply.AuthorId, StringComparison.OrdinalIgnoreCase) && !rolesUserLogged.Contains("Admin"))
                {
                    return Unauthorized("This reply is not yours");
                }

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

