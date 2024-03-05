using ApiCatalogo.Controllers;
using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories;
using DSLearn.Controllers;
using DSLearn.Dtos;
using DSLearn.Entities;
using DSLearn.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DSLearnTests.Controller.AuthControllerTests
{
    public class GetUser
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserController _userController;


        public GetUser()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _userController = new UserController(_unitOfWork);
        }


        [Fact]
        public async void FindAllUsersShouldReturnListOfUserDTO()
        {

            var expectedResult = new List<UserDTO>
            {
                new UserDTO
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "email@teste.com",
                    PhoneNumber = "1234567890",
                    PhoneNumberIsConfirmed = true,
                    UserName = "Test"
                }
            };

            var pageQuery = new PageQueryParams()
            {
                Name = "",
                PageNumber = 1,
                PageSize = 1,
            };

            _unitOfWork.UserRepository.FindAllAsync(pageQuery).Returns(expectedResult);


            // Act
            var actionResult = await _userController.FindAll(pageQuery);


            //Assert
            Assert.IsAssignableFrom<ActionResult<IEnumerable<UserDTO>>>(actionResult);

            var okObjectResult = Assert.IsAssignableFrom<OkObjectResult>(actionResult.Result);
            var userDTOs = Assert.IsAssignableFrom<IEnumerable<UserDTO>>(okObjectResult.Value);

       
            var userDTO = Assert.Single(userDTOs);

            Assert.Equal(expectedResult[0].Id, userDTO.Id);
            Assert.Equal(expectedResult[0].Email, userDTO.Email);

        }

        [Fact]
        public async void FindAllUserRolesShouldReturnListOfUserRolesDTO()
        {
            // Arrange
            var expectedResult = new List<UserRolesDTO>
    {
        new UserRolesDTO
        {
            Id = Guid.NewGuid().ToString(),
            Email = "email@teste.com",
            PhoneNumber = "1234567890",
            PhoneNumberIsConfirmed = true,
            UserName = "Test"
        }
    };

            var pageQuery = new PageQueryParams
            {
                Name = "",
                PageNumber = 1,
                PageSize = 1,
            };

            _unitOfWork.UserRepository.FindAllUserRolesAsync(pageQuery)
                .Returns(expectedResult);

            // Act
            var actionResult = await _userController.FindAllUserRoles(pageQuery);

            // Assert
            Assert.IsAssignableFrom<ActionResult<IEnumerable<UserRolesDTO>>>(actionResult);

            var okObjectResult = Assert.IsAssignableFrom<OkObjectResult>(actionResult.Result);
            var userDTOs = Assert.IsAssignableFrom<IEnumerable<UserRolesDTO>>(okObjectResult.Value);

            var userDTO = Assert.Single(userDTOs);

            Assert.Equal(expectedResult[0].Id, userDTO.Id);
            Assert.Equal(expectedResult[0].Email, userDTO.Email);
        }



        [Fact]
        public async void FindAllUserAllInformationsShouldReturnListOfUserAllInformationsDTO()
        {
            var expectedResult = new List<UserAllInformationsDTO>
        {
        new UserAllInformationsDTO
        {
            Id = Guid.NewGuid().ToString(),
            Email = "email@teste.com",
            PhoneNumber = "1234567890",
            PhoneNumberIsConfirmed = true,
            UserName = "Test"
        }
        };

            var pageQuery = new PageQueryParams
            {
                Name = "",
                PageNumber = 1,
                PageSize = 1,
            };

            _unitOfWork.UserRepository.FindAllUserAllInformationsAsync(pageQuery)
                    .Returns(expectedResult);


            var actionResult = await _userController.FindAllUserAllInformations(pageQuery);



            Assert.IsAssignableFrom<ActionResult<IEnumerable<UserAllInformationsDTO>>>(actionResult);

            var okObjectResult = Assert.IsAssignableFrom<OkObjectResult>(actionResult.Result);
            var userDTOs = Assert.IsAssignableFrom<IEnumerable<UserAllInformationsDTO>>(okObjectResult.Value);

            var userDTO = Assert.Single(userDTOs);

            Assert.Equal(expectedResult[0].Id, userDTO.Id);
            Assert.Equal(expectedResult[0].Email, userDTO.Email);

        }


        [Fact]
        public async void FindAllUserInfoByIdShouldReturnUserAllInformationsDTOWhenIdExists()
        {
            var existsId = Guid.NewGuid().ToString();
            var expectedResult = new UserAllInformationsDTO
            {
                Id = Guid.NewGuid().ToString(),
                Email = "email@teste.com",
                PhoneNumber = "1234567890",
                PhoneNumberIsConfirmed = true,
                UserName = "Test"
            };


            _unitOfWork.UserRepository.FindByIdUserAllInformationsAsync(existsId)
                    .Returns(expectedResult);

            var actionResult = await _userController.FindAllUserInfoById(existsId);



            Assert.IsAssignableFrom<ActionResult<UserAllInformationsDTO>>(actionResult);

            var okObjectResult = Assert.IsAssignableFrom<OkObjectResult>(actionResult.Result);
            var userDTO = Assert.IsAssignableFrom<UserAllInformationsDTO>(okObjectResult.Value);

            Assert.Equal(expectedResult.Id, userDTO.Id);
            Assert.Equal(expectedResult.Email, userDTO.Email);

        }

        [Fact]
        public async void FindAllUserInfoByIdShouldReturnBadRequestWhenIdDoesNotExists()
        {
            var nonExistsId = Guid.NewGuid().ToString();
            


            _unitOfWork.UserRepository.FindByIdUserAllInformationsAsync(nonExistsId)
                    .Throws(new ArgumentException($"Id {nonExistsId} does not exists"));

            var actionResult = await _userController.FindAllUserInfoById(nonExistsId);



            Assert.IsAssignableFrom<ActionResult<UserAllInformationsDTO>>(actionResult);

            Assert.IsAssignableFrom<BadRequestObjectResult>(actionResult.Result);
        }


    }




}
