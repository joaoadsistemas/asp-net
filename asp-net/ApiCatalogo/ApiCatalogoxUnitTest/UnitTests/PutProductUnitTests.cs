using ApiCatalogo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task PutProductShouldReturnOk()
        {

        }



        [Fact]
        public async Task PutProductShouldReturnNotFound()
        {

        }



    }
}
