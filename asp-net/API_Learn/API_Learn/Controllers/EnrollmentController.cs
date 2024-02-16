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
    [Route("enrollments")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public EnrollmentController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<IEnumerable<EnrollmentDTO>>> FindAll([FromQuery] PageQueryParams pageQueryParams)
        {
            return Ok(await _unitOfWork.EnrollmentRepository.FindAllAsync(pageQueryParams));

        }


        [HttpGet("self-enrollment")]
        [Authorize(Policy = "StudentOnly")]
        public async Task<ActionResult<dynamic>> FindSelfEnrollment(string id)
        {
            try
            {

                var userId = await _userManager.FindByIdAsync(id);

                if (userId == null)
                {
                    return BadRequest($"Id {id} does not exists");
                }


                // Obter as reivindicações de identidade do usuário a partir do contexto HTTP
                var claimsIdentity = (ClaimsIdentity)User.Identity;

                // Obter o ID único do usuário a partir das reivindicações de identidade
                var userLoggedId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                // Buscar informações do usuário utilizando o UserManager
                var userLogged = await _userManager.FindByIdAsync(userLoggedId);

                // Obter as roles (funções) associadas ao usuário utilizando o UserManager
                var rolesUserLogged = await _userManager.GetRolesAsync(userLogged);


                // Verificar se o ID do usuário não corresponde ao ID fornecido OU se o usuário não tem a função "Instructor"
                if (!userLoggedId.Equals(id, StringComparison.OrdinalIgnoreCase) && !rolesUserLogged.Contains("Admin"))
                {
                    // Se a condição acima for verdadeira, retornar uma resposta de não autorizado
                    return Unauthorized("Access Denied: The user does not have permission to make this task. Either the user ID does not match or the user does not have the 'Admin' role.");
                }

                // Se o usuário tem as permissões necessárias, retornar as notificações associadas ao usuário
                return Ok(await _unitOfWork.EnrollmentRepository.FindByUserIdAsync(id));
            }
            catch (ArgumentException ex)
            {
                // Se ocorrer uma exceção do tipo ArgumentException, retornar uma mensagem de erro
                return ErrorMessages.ErrorMessage(id);
            }

        }

        [HttpGet("offer-id")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<dynamic>> FindByOfferId(int id)
        {
            try
            {
                EnrollmentDTO result = await _unitOfWork.EnrollmentRepository.FindByOfferIdAsync(id);
                return Ok(result);
            }
            catch (ArgumentException ex) { return ErrorMessages.ErrorMessage(id); }
        }

        [HttpGet("user-id")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<dynamic>> FindByUserId(string id)
        {
            try
            {
                EnrollmentDTO result = await _unitOfWork.EnrollmentRepository.FindByUserIdAsync(id);
                return Ok(result);
            }
            catch (ArgumentException ex) { return ErrorMessages.ErrorMessage(id); }
        }


        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<dynamic>> Insert([FromBody] EnrollmentInsertDTO dto)
        {
            EnrollmentDTO result = _unitOfWork.EnrollmentRepository.Insert(dto);
            await _unitOfWork.CommitAsync();

            return CreatedAtAction(nameof(FindByUserId), new { Id = result.UserId }, result);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<dynamic>> Update([FromBody] EnrollmentInsertDTO dto, int id)
        {
            try
            {
                EnrollmentDTO result = _unitOfWork.EnrollmentRepository.Update(dto, id);
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

