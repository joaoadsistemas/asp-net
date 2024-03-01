// Importando os namespaces necessários para o teste
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

namespace ApiCatalogoxUnitTest.UnitControllerTests.ProductTests
{
    // Classe que contém os testes unitários para a atualização de produtos
    public class PutProduct
    {
        // Instância de substituto para a interface IUnitOfWork
        private readonly IUnitOfWork _unitOfWork;

        // Construtor que inicializa a instância de IUnitOfWork como um substituto
        public PutProduct()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
        }

        // Teste que verifica se a atualização de um produto com um ID existente retorna NoContent
        [Fact]
        public async void UpdateProductShouldReturnNoContentWhenIdExists()
        {
            // Arrange: Criação do controlador de produto, definição de um ID existente e configuração do comportamento esperado do método UpdateProduct
            var productController = new ProductController(_unitOfWork);
            var existsId = 1;
            var insertProduct = new ProductInsertDTO
            {
                Name = "name",
                Description = "description",
                ImgUrl = "img.com.br",
                Price = 1
            };

            // Act: Chamada do método UpdateProduct no controlador
            _unitOfWork.ProductRepository.UpdateProduct(
                Arg.Is<ProductInsertDTO>(dto =>
                    dto.Name == insertProduct.Name &&
                    dto.Description == insertProduct.Description &&
                    dto.Price == insertProduct.Price),
                Arg.Any<long>());

            var result = await productController.UpdateProduct(insertProduct, existsId);

            // Assert: Verificação se o resultado é do tipo NoContentResult
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result.Result);
        }

        // Teste que verifica se a atualização de um produto com um ID inexistente lança NotFound
        [Fact]
        public async void UpdateProductShouldThrowNotFoundWhenIdDoesNotExists()
        {
            // Arrange: Criação do controlador de produto, definição de um ID inexistente e configuração do comportamento esperado do método UpdateProduct (lançar exceção)
            var productController = new ProductController(_unitOfWork);
            var nonExistsId = 1000;
            var insertProduct = new ProductInsertDTO
            {
                Name = "name",
                Description = "description",
                ImgUrl = "img.com.br",
                Price = 1
            };

            // Act: Chamada do método UpdateProduct no controlador
            _unitOfWork.ProductRepository.UpdateProduct(
               Arg.Is<ProductInsertDTO>(dto =>
                   dto.Name == insertProduct.Name &&
                   dto.Description == insertProduct.Description &&
                   dto.Price == insertProduct.Price),
               Arg.Any<long>()).Throws(new Exception("Resource not found"));

            var result = await productController.UpdateProduct(insertProduct, nonExistsId);

            // Assert: Verificação se o resultado é do tipo NotFoundObjectResult e se a mensagem de erro está correta
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal(404, notFoundResult.StatusCode);
            var errorMessage = Assert.IsType<string>(notFoundResult.Value);
            Assert.Equal("Resource not found", errorMessage);

            Assert.NotNull(result);
        }
    }
}
