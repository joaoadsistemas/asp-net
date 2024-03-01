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
    public class PostCategory
    {

        private readonly IUnitOfWork _unitOfWork;

        // Construtor da classe de teste
        public PostCategory()
        {
            // Substitui a interface IUnitOfWork por uma instância substituta
            _unitOfWork = Substitute.For<IUnitOfWork>();
        }


        [Fact]
        public async void InsertCategoryShouldReturnCategoryDTO()
        {

            // Arranjo
            var categoryController = new CategoryController(_unitOfWork);

            // Definição do objeto CategoryInsertDTO para inserção
            var insertCategory = new CategoryInsertDTO()
            {
                Name = "name",
                ImgUrl = "img.url"
            };

            // Definição da categoria esperada como resultado da inserção
            var expectedCategory = new CategoryDTO()
            {
                Id = 1,
                Name = "name",
                ImgUrl = "img.url"
            };

            // Configuração do comportamento do repositório ao chamar o método InsertCategory
            _unitOfWork.CategoryRepository.InsertCategory(Arg.Any<CategoryInsertDTO>()).Returns(expectedCategory);

            // Ação
            var result = await categoryController.InsertCategory(insertCategory);

            // Afirmação
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var actualCategory = Assert.IsAssignableFrom<CategoryDTO>(createdResult.Value);
            Assert.Equal(expectedCategory, actualCategory);
        }


        [Fact]
        public async void InserCategoryShouldThrowBadRequest()
        {

            // Arranjo
            var categoryController = new CategoryController(_unitOfWork);

            // Definição do objeto CategoryInsertDTO para inserção
            var insertCategory = new CategoryInsertDTO()
            {
                Name = "name",
                ImgUrl = "img.url"
            };

            // Configuração do comportamento do repositório para lançar uma exceção ao chamar o método InsertCategory
            _unitOfWork.CategoryRepository.InsertCategory(Arg.Any<CategoryInsertDTO>()).Throws(new Exception("Not a possible created"));

            // Ação
            var result = await categoryController.InsertCategory(insertCategory);

            // Afirmação
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);

            // Verifica se o código de status é 400 (BadRequest)
            Assert.Equal(400, badRequestResult.StatusCode);

            // Verifica se a mensagem de erro retornada é a esperada
            var errorMessage = Assert.IsType<string>(badRequestResult.Value);
            Assert.Equal("Not a possible created", errorMessage);
        }

    }
}
