using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories;
using DSLearn.Controllers.Utils;
using DSLearn.Dtos;
using DSLearn.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace DSLearn.Controllers
{
    [Route("notifications")]
    [ApiController]
    public class NotificationController : ControllerBase
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;


        public NotificationController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;

        }

        [HttpGet]
        [Authorize(Policy = "InstructorOnly")]
        public async Task<ActionResult<IEnumerable<NotificationDTO>>> FindAll([FromQuery] PageQueryParams pageQueryParams)
        {
            return Ok(await _unitOfWork.NotificationRepository.FindAllAsync(pageQueryParams));

        }

        [HttpGet("id")]
        [Authorize(Policy = "InstructorOnly")]
        public async Task<ActionResult<dynamic>> FindById(int id)
        {
            try
            {
                NotificationDTO result = await _unitOfWork.NotificationRepository.FindByIdAsync(id);
                return Ok(result);
            } catch (ArgumentException ex) { return ErrorMessages.ErrorMessage(id); }


        }

        [HttpGet("notification-user")]
        [Authorize(Policy = "StudentOnly")]
        public async Task<ActionResult<dynamic>> FindSelfNotification(string id)
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
                if (!userLoggedId.Equals(id, StringComparison.OrdinalIgnoreCase) && !rolesUserLogged.Contains("Instructor"))
                {
                    // Se a condição acima for verdadeira, retornar uma resposta de não autorizado
                    return Unauthorized("Access Denied: The user does not have permission to make this task. Either the user ID does not match or the user does not have the 'Instructor' role.");
                }

                // Se o usuário tem as permissões necessárias, retornar as notificações associadas ao usuário
                return Ok(await _unitOfWork.NotificationRepository.FindByUserAsync(id));
            }
            catch (ArgumentException ex)
            {
                // Se ocorrer uma exceção do tipo ArgumentException, retornar uma mensagem de erro
                return ErrorMessages.ErrorMessage(id);
            }
        }

        [HttpPost]
        [Authorize(Policy = "InstructorOnly")]
        public async Task<ActionResult<dynamic>> Insert([FromBody] NotificationInsertDTO dto)
        {
            NotificationDTO result = _unitOfWork.NotificationRepository.Insert(dto);
            await _unitOfWork.CommitAsync();

            return CreatedAtAction(nameof(FindById), new { Id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "InstructorOnly")]
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
        [Authorize(Policy = "InstructorOnly")]
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

