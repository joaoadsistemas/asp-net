using ApiCatalogo.Controllers;
using ApiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiCatalogoxUnitTest.UnitControllerTests.CategoryTests
{
    public class DeleteCategory
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly CategoryController _categoryController;

        public DeleteCategory()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _categoryController = new CategoryController(_unitOfWork);
        }


        [Fact]
        public async Task DeleteCategoryShouldReturnNoContent()
        {

            //Arrange
            var existingId = 1;


            _unitOfWork.CategoryRepository.DeleteCategory(existingId).Returns(true);

            //Act
            var result = await _categoryController.DeleteById(existingId);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result.Result);

        }



        [Fact]
        public async Task DeleteCategoryShouldReturnNotFound()
        {

            //Arrange
            var nonExistingId = 1000;

            _unitOfWork.CategoryRepository.DeleteCategory(nonExistingId).Throws(new Exception("Resource not found"));

            //Act
            var result = await _categoryController.DeleteById(nonExistingId);

            //Assert
            Assert.NotNull(result);
            var notFoundResponse = Assert.IsType<NotFoundObjectResult>(result.Result);
            var errorMessage = Assert.IsType<string>(notFoundResponse.Value);
            Assert.Equal("Resource not found", errorMessage);

        }

    }
}
