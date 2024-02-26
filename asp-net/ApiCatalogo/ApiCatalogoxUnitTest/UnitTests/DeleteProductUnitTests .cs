// Importando os namespaces necessários para o teste
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

namespace ApiCatalogoxUnitTest.UnitTests
{
    // Classe que contém os testes unitários para a remoção de produtos
    public class DeleteProductUnitTests
    {
        // Instância de substituto para a interface IUnitOfWork
        private readonly IUnitOfWork _unitOfWork;

        // Construtor que inicializa a instância de IUnitOfWork como um substituto
        public DeleteProductUnitTests()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
        }

        // Teste que verifica se a remoção de um produto com um ID existente retorna NoContent
        [Fact]
        public async Task DeleteProductShouldReturnNoContent()
        {
            // Arrange: Criação do controlador de produto e definição de um ID existente
            var productController = new ProductController(_unitOfWork);
            var existingId = 1;

            // Act: Configuração do comportamento esperado do método DeleteProduct e chamada do método no controlador
            _unitOfWork.ProductRepository.DeleteProduct(Arg.Any<long>()).Returns(true);
            var result = await productController.DeleteProduct(existingId);

            // Assert: Verificação se o resultado é do tipo NoContentResult
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result.Result);
        }

        // Teste que verifica se a remoção de um produto com um ID inexistente retorna NotFound
        [Fact]
        public async Task DeleteProductShouldReturnNotFound()
        {
            // Arrange: Criação do controlador de produto e definição de um ID inexistente
            var productController = new ProductController(_unitOfWork);
            var nonExistingId = 1000;

            // Act: Configuração do comportamento esperado do método DeleteProduct (lançar exceção) e chamada do método no controlador
            _unitOfWork.ProductRepository.DeleteProduct(Arg.Any<long>()).Throws(new Exception("Resource not found"));
            var result = await productController.DeleteProduct(nonExistingId);

            // Assert: Verificação se o resultado é do tipo NotFoundObjectResult e se a mensagem de erro está correta
            Assert.NotNull(result);
            var notFoundResponse = Assert.IsType<NotFoundObjectResult>(result.Result);
            var errorMessage = Assert.IsType<string>(notFoundResponse.Value);
            Assert.Equal("Resource not found", errorMessage);
        }
    }
}
