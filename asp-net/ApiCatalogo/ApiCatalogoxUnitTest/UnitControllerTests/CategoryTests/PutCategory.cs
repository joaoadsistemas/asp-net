using ApiCatalogo.Controllers;
using ApiCatalogo.Dtos;
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
    public class PutCategory
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CategoryController _categoryController;

        public PutCategory()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _categoryController = new CategoryController(_unitOfWork);
        }

        [Fact]
        public async void UpdateCategoryShouldReturnNoContentWhenIdExists()
        {
            // Arrange
            var existsId = 1;
            var insertCategory = new CategoryInsertDTO()
            {
                Name = "name",
                ImgUrl = "img.url"
            };
            

            _unitOfWork.CategoryRepository.UpdateCategory(
                Arg.Is<CategoryInsertDTO>(dto =>
                    dto.Name == insertCategory.Name &&
                    dto.ImgUrl == insertCategory.ImgUrl),
                existsId);  

            // Act
            var result = await _categoryController.UpdateCategory(insertCategory, existsId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result.Result);

        }


        [Fact]  
        public async void UpdateCategoryShouldThrowNotFoundWhenIdDoesNotExists()
        {

            //Arrange
            var nonExistsId = 1000;
            var insertCategory = new CategoryInsertDTO()
            {
                Name = "name",
                ImgUrl = "img.url"
            };


            _unitOfWork.CategoryRepository.UpdateCategory(
                Arg.Is<CategoryInsertDTO>(dto =>
                    dto.Name == insertCategory.Name &&
                    dto.ImgUrl == insertCategory.ImgUrl),
                nonExistsId).Throws(new Exception("Resource not found"));

            //Act
            var result = await _categoryController.UpdateCategory(insertCategory, nonExistsId);


            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal(404, notFoundResult.StatusCode);
            var errorMessage = Assert.IsType<string>(notFoundResult.Value);
            Assert.Equal("Resource not found", errorMessage);
            Assert.NotNull(result);
        }


    }
}
