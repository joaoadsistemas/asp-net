using ApiCatalogo.Controllers;
using ApiCatalogo.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiCatalogoxUnitTest.UnitTests
{
    public class PutProductUnitTests : IClassFixture<ProductsUnitTestController>
    {
        private readonly ProductController _controller;

        public PutProductUnitTests(ProductsUnitTestController controller)
        {
            _controller = new ProductController(controller.repository);
        }



        [Fact]
        public async Task PutProductShouldReturnNoContent()
        {
            //Arrange
            ProductInsertDTO productDTO = new ProductInsertDTO();
            productDTO.Price = 10;
            productDTO.Stock = 20;
            productDTO.Name = "TestPUT";
            productDTO.Description = "TestPUT";
            productDTO.ImgUrl = string.Empty;
            productDTO.CategoryId = 1;

            // Act
            var data = await _controller.UpdateProduct(productDTO, 10011);


            //Assert
            NoContentResult noContent = Assert.IsType<NoContentResult>(data.Result);
            Assert.Equal(204, noContent.StatusCode);
        }



        [Fact]
        public async Task PutProductShouldReturnNotFound()
        {
            ProductInsertDTO productDTO = new ProductInsertDTO();
            productDTO.Price = 10;
            productDTO.Stock = 20;
            productDTO.Name = "TestPUT";
            productDTO.Description = "TestPUT";
            productDTO.ImgUrl = string.Empty;
            productDTO.CategoryId = 1;

            // Act
            var data = await _controller.UpdateProduct(productDTO, 500);


            //Assert
            NotFoundObjectResult notFound = Assert.IsType<NotFoundObjectResult>(data.Result);
            Assert.Equal(404, notFound.StatusCode);
        }



    }
}
