using ApiCatalogo.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiCatalogoxUnitTest.UnitTests
{
    public class DeleteProductUnitTests : IClassFixture<ProductsUnitTestController>
    {
        private readonly ProductController _controller;

        public DeleteProductUnitTests(ProductsUnitTestController controller)
        {
            _controller = new ProductController(controller.repository);
        }



        [Fact]
        public async Task DeleteProductShouldReturnNoContent()
        {
            //act
            var data = await _controller.DeleteProduct(10009);

            //assert
            NoContentResult noContent = Assert.IsType<NoContentResult>(data.Result);
            Assert.Equal(204, noContent.StatusCode);


        }



        [Fact]
        public async Task DeleteProductShouldReturnNotFound()
        {
            //act
            var data = await _controller.DeleteProduct(500);

            //assert
            NotFoundObjectResult notFound = Assert.IsType<NotFoundObjectResult>(data.Result);
            Assert.Equal(404, notFound.StatusCode);
        }



    }
}
