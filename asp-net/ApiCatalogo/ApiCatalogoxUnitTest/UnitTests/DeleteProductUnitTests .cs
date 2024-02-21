using ApiCatalogo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }



        [Fact]
        public async Task DeleteProductShouldReturnNotFound()
        {

        }



    }
}
