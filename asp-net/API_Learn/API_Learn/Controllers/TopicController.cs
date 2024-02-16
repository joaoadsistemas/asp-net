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
    [Route("topics")]
    [ApiController]
    public class TopicController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public TopicController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
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
        [Authorize(Policy = "StudentOnly")]
        public async Task<ActionResult<dynamic>> Insert([FromBody] TopicInsertDTO dto)
        {

            var userId = await _userManager.FindByIdAsync(dto.AuthorId);

            if (userId == null)
            {
                return BadRequest($"Id {dto.AuthorId} does not exists");
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
            if (!userLoggedId.Equals(dto.AuthorId, StringComparison.OrdinalIgnoreCase) && !rolesUserLogged.Contains("Instructor"))
            {
                // Se a condição acima for verdadeira, retornar uma resposta de não autorizado
                return Unauthorized("Access Denied: The user does not have permission to make this task. Either the user ID does not match or the user does not have the 'Admin' role.");
            }

            TopicDTO result = _unitOfWork.TopicRepository.Insert(dto);
            await _unitOfWork.CommitAsync();

            return CreatedAtAction(nameof(FindById), new { Id = result.Id }, result);
        }

        [HttpPut("{id}")]
       //[Authorize(Policy = "StudentOnly")]
        public async Task<ActionResult<dynamic>> Update([FromBody] TopicInsertDTO dto, int id)
        {
            try
            {
                var userId = await _userManager.FindByIdAsync(dto.AuthorId);

                if (userId == null)
                {
                    return BadRequest($"Id {dto.AuthorId} does not exists");
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
                if (!userLoggedId.Equals(dto.AuthorId, StringComparison.OrdinalIgnoreCase) && !rolesUserLogged.Contains("Instructor"))
                {
                    // Se a condição acima for verdadeira, retornar uma resposta de não autorizado
                    return Unauthorized("Access Denied: The user does not have permission to make this task. Either the user ID does not match or the user does not have the 'Admin' role.");
                }

                TopicDTO result = _unitOfWork.TopicRepository.Update(dto, id);
                await _unitOfWork.CommitAsync();
                return Ok(result);
            }
            catch (ArgumentException ex) { return ErrorMessages.ErrorMessage(id); }
        }

        [HttpDelete("{queryUserId}/{id}")]
        //[Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<dynamic>> Delete(string queryUserId,int id)
        {
            try
            {
                var userId = await _userManager.FindByIdAsync(queryUserId);

                if (userId == null)
                {
                    return BadRequest($"Id {queryUserId} does not exists");
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
                if (!userLoggedId.Equals(queryUserId, StringComparison.OrdinalIgnoreCase) && !rolesUserLogged.Contains("Instructor"))
                {
                    // Se a condição acima for verdadeira, retornar uma resposta de não autorizado
                    return Unauthorized("Access Denied: The user does not have permission to make this task. Either the user ID does not match or the user does not have the 'Admin' role.");
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

