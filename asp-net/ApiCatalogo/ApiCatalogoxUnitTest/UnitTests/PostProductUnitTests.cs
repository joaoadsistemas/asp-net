using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCatalogo.Controllers;
using ApiCatalogo.Dtos;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ApiCatalogoxUnitTest.UnitTests
{
    public class PostProductUnitTests : IClassFixture<ProductsUnitTestController>
    {

        private readonly ProductController _controller;

        public PostProductUnitTests(ProductsUnitTestController controller)
        {
            _controller = new ProductController(controller.repository);
        }


        [Fact]
        public async Task PostProductShouldReturnCreated()
        {
            //Arrange
            ProductInsertDTO productDTO = new ProductInsertDTO();
            productDTO.Price = 10;
            productDTO.Stock = 20;
            productDTO.Name = "Test";
            productDTO.Description = "Test";
            productDTO.ImgUrl = string.Empty;
            productDTO.CategoryId = 1;

            // Act
            var data = await _controller.InsertProduct(productDTO);


            //Assert
            CreatedAtActionResult createdResult = Assert.IsType<CreatedAtActionResult>(data.Result);
            Assert.Equal(201, createdResult.StatusCode);

            var product = Assert.IsAssignableFrom<ProductDTO>(createdResult.Value);



        }


        [Fact]
        public async Task PostProductShouldReturnBadRequest()
        {
            //Arrange
            ProductInsertDTO productDTO = new ProductInsertDTO();
            productDTO.Price = 10;
            productDTO.Stock = 20;
            productDTO.Name = "Test";
            productDTO.Description = "Test";
            productDTO.ImgUrl = string.Empty;

            // Act
            var data = await _controller.InsertProduct(productDTO);


            //Assert
            BadRequestObjectResult badResult = Assert.IsType<BadRequestObjectResult>(data.Result);
            Assert.Equal(400, badResult.StatusCode);

        }

    }
}
