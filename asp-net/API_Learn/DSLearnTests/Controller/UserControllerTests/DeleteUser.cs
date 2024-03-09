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
    public class DeleteUser
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserController _userController;

        public DeleteUser()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _userController = new UserController(_unitOfWork);

        }



        [Fact]
        public async void DeleteShouldReturnNoContentWhenExistsId()
        {

            //Arrange
            var existingId = Guid.NewGuid().ToString();

            _unitOfWork.UserRepository.Delete(existingId);

            //Act
            var actionResult = await _userController.Delete(existingId);

            //Assert
            Assert.IsAssignableFrom<NoContentResult>(actionResult.Result);

        }


        [Fact]
        public async void DeleteShouldReturnBadRequestWhenDoesNotExistsId()
        {

            //Arrange
            var nonExistingId = Guid.NewGuid().ToString();
            var msg = $"Id {nonExistingId} does not exists";

            _unitOfWork.UserRepository.Delete(nonExistingId).Throws(new ArgumentException(msg));

            //Act
            var actionResult = await _userController.Delete(nonExistingId);

            //Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(actionResult.Result);

        }
    }
}
