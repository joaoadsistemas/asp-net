using ApiCatalogo.Dtos;
using ApiCatalogo.Repositories;
using DSLearn.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DSLearnTests.Controller.UserControllerTests
{
    public class PutUser
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserController _userController;

        public PutUser()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _userController = new UserController(_unitOfWork);

        }

        [Fact]
        public async void InsertShouldReturnNoContentWhenExistsId()
        {
            //Arrange
            var existingId = Guid.NewGuid().ToString();
            var registerUserDTO = new RegisterUserDTO()
            {
                Username = "Teste",
                Email = "teste@gmail.com",
                Password = "password",
                PhoneNumber = "1234567890",
                PhoneNumberIsConfirmed = false
            };


            _unitOfWork.UserRepository.Update(registerUserDTO, existingId);

            //Act
            var actionResult = await _userController.Insert(registerUserDTO, existingId);



            //Assert
            Assert.IsAssignableFrom<NoContentResult>(actionResult.Result);
        }

        [Fact]
        public async void InsertShouldReturnBadRequestWhenIdDoesNotExists()
        {
            //Arrange
            var nonExistingId = Guid.NewGuid().ToString();
            var registerUserDTO = new RegisterUserDTO()
            {
                Username = "Teste",
                Email = "teste@gmail.com",
                Password = "password",
                PhoneNumber = "1234567890",
                PhoneNumberIsConfirmed = false
            };


            _unitOfWork.UserRepository.Update(registerUserDTO, nonExistingId).Throws(new ArgumentException($"Id {nonExistingId} does not exists"));

            //Act
            var actionResult = await _userController.Insert(registerUserDTO, nonExistingId);



            //Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(actionResult.Result);
        }

    }
}
