using ApiCatalogo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using ApiCatalogo.Repositories;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace ApiCatalogoxUnitTest.UnitTests
{
    public class GetProductUnitTests
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetProductUnitTests()
        {
            // Substituto para a interface IUnitOfWork
            _unitOfWork = Substitute.For<IUnitOfWork>();
        }

        [Fact]
        public async Task FindAllShouldReturnOkWithProducts()
        {
            // Arrange
            // Criação do controlador e definição dos parâmetros da consulta
            var productController = new ProductController(_unitOfWork);
            var pageQueryParams = new PageQueryParams()
            {
                Name = "Test"
            };

            // Definição dos produtos esperados como resultado da consulta
            var expectedProducts = new List<ProductDTO>
            {
                new ProductDTO
                {
                    Id = 1,
                    Name = "Test",
                    Description = "Test",
                    Price = 10,
                    ImgUrl = null,
                    RegisterData = DateTimeOffset.Now,
                    Stock = 1
                }
            };

            // Configuração do comportamento do repositório ao chamar o método FindAllProductsAsync
            _unitOfWork.ProductRepository.FindAllProductsAsync(Arg.Any<PageQueryParams>()).Returns(expectedProducts);

            // Act
            // Chama o método de consulta no controlador
            var result = await productController.FindAll(pageQueryParams);

            // Assert
            // Verifica se o resultado é do tipo OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            // Verifica se o objeto retornado é do tipo IEnumerable<ProductDTO>
            var actualProducts = Assert.IsAssignableFrom<IEnumerable<ProductDTO>>(okResult.Value);

            // Verifica se os produtos retornados são iguais aos produtos esperados
            Assert.Equal(expectedProducts, actualProducts);

            // Verifica se o número de produtos retornados é o esperado
            Assert.Equal(expected: expectedProducts.Count, 1);
        }

        [Fact]
        public async Task FindAllShouldReturnOkWhenNameIsPassedWithProducts()
        {
            // Arrange
            // Criação do controlador e definição dos parâmetros da consulta
            var productController = new ProductController(_unitOfWork);
            var pageQueryParams = new PageQueryParams()
            {
                Name = "Test"
            };

            // Definição dos produtos esperados como resultado da consulta
            var expectedProducts = new List<ProductDTO>
            {
                new ProductDTO
                {
                    Id = 1,
                    Name = "Test",
                    Description = "Test",
                    Price = 10,
                    ImgUrl = null,
                    RegisterData = DateTimeOffset.Now,
                    Stock = 1
                }
            };

            // Configuração do comportamento do repositório ao chamar o método FindAllProductsAsync
            _unitOfWork.ProductRepository.FindAllProductsAsync(Arg.Is<PageQueryParams>(p => p.Name == pageQueryParams.Name))
                .Returns(expectedProducts);

            // Act
            // Chama o método de consulta no controlador
            var result = await productController.FindAll(pageQueryParams);

            // Assert
            // Verifica se o resultado é do tipo OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            // Verifica se o objeto retornado é do tipo IEnumerable<ProductDTO>
            var actualProducts = Assert.IsAssignableFrom<IEnumerable<ProductDTO>>(okResult.Value);

            // Verifica se os produtos retornados são iguais aos produtos esperados
            Assert.Equal(expectedProducts, actualProducts);

            // Verifica se o número de produtos retornados é o esperado
            Assert.Equal(expected: expectedProducts.Count, 1);
        }

        [Fact]
        public async Task FindAllShouldReturnNotFoundWhenExceptionThrown()
        {
            // Arrange
            // Criação do controlador e definição dos parâmetros da consulta
            var productController = new ProductController(_unitOfWork);
            var pageQueryParams = new PageQueryParams();

            // Mensagem de erro esperada
            var expectedErrorMessage = "Resource not found";

            // Configuração do comportamento do repositório ao lançar uma exceção ao chamar o método FindAllProductsAsync
            _unitOfWork.ProductRepository.FindAllProductsAsync(Arg.Any<PageQueryParams>()).Throws(new Exception("Resource not found"));

            // Act
            // Chama o método de consulta no controlador
            var result = await productController.FindAll(pageQueryParams);

            // Assert
            // Verifica se o resultado é do tipo NotFoundObjectResult
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);

            // Verifica se a mensagem de erro retornada é a esperada
            var actualErrorMessage = Assert.IsType<string>(notFoundResult.Value);
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }

    }
}
