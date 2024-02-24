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

namespace ApiCatalogoxUnitTest.UnitTests
{
    public class GetProductUnitTests : IClassFixture<ProductsUnitTestController>
    {

        // aqui 
        private readonly ProductController _controller;

        public GetProductUnitTests(ProductsUnitTestController controller)
        {
            // voce passa aqui todos os argumentos que o controller precisa, ex: automapper, usermanger
            _controller = new ProductController(controller.repository);
        }



        [Fact]
        public async Task GetProductByIdShouldReturnProductDTO()
        {
            // Arrange
            int id = 1;


            //Act 
            var data = await _controller.FindById(id);


            //Assert (xUnit)
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(data.Result);
            Assert.Equal(200, okResult.StatusCode);

        }



        [Fact]
        public async Task GetProductByIdShouldReturnNotFound()
        {
            // Arrange
            int id = 1000;


            //Act
            var data = await _controller.FindById(id);


            //Assert
            NotFoundObjectResult notFound = Assert.IsType<NotFoundObjectResult>(data.Result);
            Assert.Equal(404, notFound.StatusCode);

        }



        [Fact]
        public async Task GetAllProductShouldReturnListOfProductDTO()
        {
            // Arrange
            PageQueryParams pqp = new PageQueryParams();
            pqp.Name = "punto";


            //Act
            var data = await _controller.FindAll(pqp);


            //Assert
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(data.Result);
            Assert.Equal(200, okResult.StatusCode);

            var productList = Assert.IsAssignableFrom<IEnumerable<ProductDTO>>(okResult.Value);

            // Verifique se pelo menos um produto tem o nome esperado
            Assert.Contains(productList, p => p.Name.ToLower() == pqp.Name.ToLower());

        }



        [Fact]
        public async Task GetAllProductShouldReturnNotFound()
        {

            // Arrange
            PageQueryParams pqp = new PageQueryParams();
            pqp.Name = "ferrari";


            //Act
            var data = await _controller.FindAll(pqp);


            //Assert
            NotFoundObjectResult okResult = Assert.IsType<NotFoundObjectResult>(data.Result);
            Assert.Equal(404, okResult.StatusCode);

        }

    }
}
