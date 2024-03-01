using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCatalogo.Controllers;
using ApiCatalogo.Dtos;
using ApiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace ApiCatalogoxUnitTest.UnitControllerTests.ProductTests
{
    public class PostProduct
    {

        private readonly IUnitOfWork _unitOfWork;

        public PostProduct()
        {
            // Substituto para a interface IUnitOfWork
            _unitOfWork = Substitute.For<IUnitOfWork>();
        }


        [Fact]
        public async void InsertProductShouldReturnProductDTO()
        {
            // Arrange
            // Criação do controlador e definição do objeto a ser inserido
            var productController = new ProductController(_unitOfWork);
            var insertProduct = new ProductInsertDTO
            {
                Name = "name",
                Description = "description",
                ImgUrl = "img.com.br",
                Price = 1
            };

            // Definição do produto esperado como resultado da inserção
            var expectedProduct = new ProductDTO
            {
                Id = 1,
                Name = "name",
                Description = "description",
                ImgUrl = "img.com.br",
                Price = 1,
                RegisterData = DateTimeOffset.Now,
                Stock = 0
            };

            // Configuração do comportamento do repositório ao chamar o método InsertProduct
            _unitOfWork.ProductRepository.InsertProduct(Arg.Any<ProductInsertDTO>()).Returns(expectedProduct);

            // Act
            // Chama o método de inserção no controlador
            var result = await productController.InsertProduct(insertProduct);

            // Assert
            // Verifica se o resultado é do tipo CreatedAtActionResult
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);

            // Verifica se o objeto retornado é do tipo ProductDTO
            var actualProduct = Assert.IsAssignableFrom<ProductDTO>(createdResult.Value);

            // Verifica se o produto retornado é igual ao produto esperado
            Assert.Equal(expectedProduct, actualProduct);
        }


        [Fact]
        public async Task InsertProductShouldThrowBadRequest()
        {
            // Arrange
            // Criação do controlador e definição do objeto a ser inserido
            var productController = new ProductController(_unitOfWork);
            var insertProduct = new ProductInsertDTO
            {
                Name = "name",
                Description = "description",
                ImgUrl = "img.com.br",
                Price = 1
            };

            // Configuração do comportamento do repositório ao lançar uma exceção ao chamar o método InsertProduct
            _unitOfWork.ProductRepository.InsertProduct(Arg.Any<ProductInsertDTO>()).Throws(new Exception("Not a possible created"));

            // Act
            // Chama o método de inserção no controlador
            var result = await productController.InsertProduct(insertProduct);

            // Assert
            // Verifica se o resultado é do tipo BadRequestObjectResult
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);

            // Verifica o StatusCode retornado (deve ser 400)
            Assert.Equal(400, badRequestResult.StatusCode);

            // Verifica o Valor retornado (mensagem de erro)
            var errorMessage = Assert.IsType<string>(badRequestResult.Value);
            Assert.Equal("Not a possible created", errorMessage);
        }
    }
}
