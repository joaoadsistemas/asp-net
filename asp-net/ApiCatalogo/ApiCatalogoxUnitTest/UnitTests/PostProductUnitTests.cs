using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCatalogo.Controllers;

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

        }


        [Fact]
        public async Task PostProductShouldReturnBadRequest()
        {

        }

    }
}
