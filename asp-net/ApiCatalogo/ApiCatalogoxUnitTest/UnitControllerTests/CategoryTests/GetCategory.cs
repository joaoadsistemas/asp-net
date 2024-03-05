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
    public class GetCategory
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategory()
        {
            // Cria uma substituição para a interface IUnitOfWork
            _unitOfWork = Substitute.For<IUnitOfWork>();
        }
                        
        [Fact]
        public async void GetAllCategoriesShouldReturnIEnumerableOfCategoryDTO()
        {
            // Arrange
            var categoryController = new CategoryController(_unitOfWork);

            // Definição de uma categoria esperada como resultado da consulta
            var expectedCategory = new List<CategoryDTO>
            {
                new CategoryDTO
                {
                    Id = 1,
                    ImgUrl = "exampleImageUrl",
                    Name = "exampleName",
                }
            };

            // Configuração do comportamento do repositório ao chamar o método FindAllCategoriesAsync
            _unitOfWork.CategoryRepository.FindAllCategoriesAsync().Returns(expectedCategory);

            // Act
            var result = await categoryController.FindAllCategories();

            // Assert   
            // Verifica se o resultado é do tipo OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            // Verifica se o objeto retornado é do tipo IEnumerable<CategoryDTO>
            var actualCategory = Assert.IsAssignableFrom<IEnumerable<CategoryDTO>>(okResult.Value);

            // Verifica se os objetos de categoria retornados são iguais aos esperados
            Assert.Equal(expectedCategory, actualCategory);

            // Verifica se o número de categorias retornadas é o esperado
            Assert.Equal(expected: expectedCategory.Count, 1);
        }

        [Fact]
        public async void GetCategoryByIdShouldReturnCategoryDTOWhenIdExists()
        {
            // Arrange
            var categoryController = new CategoryController(_unitOfWork);
            var existsId = 1;

            // Criação de uma categoria DTO esperada como resultado da consulta
            var categoryDTO = new CategoryDTO
            {
                Id = 1,
                ImgUrl = "exampleImageUrl",
                Name = "exampleName",
            };

            // Configuração do comportamento do repositório ao chamar o método FindCategoryByIdAsync
            _unitOfWork.CategoryRepository.FindCategoryByIdAsync(existsId).Returns(categoryDTO);

            // Act
            var result = await categoryController.FindCategoryById(existsId);

            // Assert
            // Verifica se o resultado é do tipo ActionResult<CategoryDTO>
            var actionResult = Assert.IsType<ActionResult<CategoryDTO>>(result);

            // Verifica se o objeto retornado é do tipo OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);

            // Verifica se o objeto de categoria retornado é do tipo CategoryDTO
            var actualCategory = Assert.IsAssignableFrom<CategoryDTO>(okResult.Value);

            // Verifica se os objetos de categoria retornados são iguais aos esperados
            Assert.Equal(categoryDTO, actualCategory);
        }

        [Fact]
        public async void GetCategoryByIdShouldReturnNotFoundWhenIdDoesNotExists()
        {
            // Arrange
            var categoryController = new CategoryController(_unitOfWork);
            var nonExistsId = 1;

            // Configura o comportamento do repositório para lançar uma exceção ao chamar o método FindCategoryByIdAsync
            _unitOfWork.CategoryRepository.FindCategoryByIdAsync(nonExistsId).Throws(new Exception("Resource not found"));

            // Act
            var result = await categoryController.FindCategoryById(nonExistsId);

            // Assert
            // Verifica se o resultado é do tipo NotFoundObjectResult
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
    }
}
