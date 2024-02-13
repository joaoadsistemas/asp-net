﻿using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories;
using DSLearn.Dtos;
using DSLearn.Entities;
using DSLearn.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSLearn.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize(Policy = "StudentOnly")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> FindAll([FromQuery] PageQueryParams pageQueryParams)
        {
            return Ok(await _unitOfWork.UserRepository.FindAllAsync(pageQueryParams));

        }


        [HttpGet("user-roles")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> FindAllUserRoles ([FromQuery] PageQueryParams pageQueryParams)
        {
            return Ok(await _unitOfWork.UserRepository.FindAllUserRolesAsync(pageQueryParams));

        }


        [HttpGet("{id}")]
        [Authorize(Policy = "StudentOnly")]
        public async Task<ActionResult<UserDTO>> FindById(string id)
        {
            try
            {
                UserDTO result = await _unitOfWork.UserRepository.FindByIdAsync(id);
                return Ok(result);

            } catch (ArgumentException ex) 
            {
                return BadRequest($"Id {id} does not exists");
            }
        }


        [HttpPut("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<dynamic>> Insert([FromBody] RegisterUserDTO registerUserDTO, string id)
        {
            try
            {

                _unitOfWork.UserRepository.Update(registerUserDTO, id);
                await _unitOfWork.CommitAsync();
                return NoContent();

            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Id {id} does not exists");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<dynamic>> Delete(string id)
        {
            try
            {

                _unitOfWork.UserRepository.Delete(id);
                await _unitOfWork.CommitAsync();
                return NoContent();

            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Id {id} does not exists");
            }
        }

    }
}
