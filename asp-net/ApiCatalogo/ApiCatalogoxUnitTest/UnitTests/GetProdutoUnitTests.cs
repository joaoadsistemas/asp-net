using ApiCatalogo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoxUnitTest.UnitTests
{
    internal class GetProdutoUnitTests : IClassFixture<ProdutosUnitTestController>
    {
        private readonly ProductController _controller;

        public GetProdutoUnitTests(ProdutosUnitTestController controller)
        {
            _controller = new ProductController(controller.repository);
        }



        [Fact]
        public async Task GetProductByIdShouldReturnProductDTO()
        {

        }



        [Fact]
        public async Task GetProductByIdShouldReturnNotFound()
        {

        }



        [Fact]
        public async Task GetProductByIdShouldReturnBadRequest()
        {

        }



        [Fact]
        public async Task GetAllProductShouldReturnListOfProductDTO()
        {

        }



        [Fact]
        public async Task GetAllProductShouldReturnBadRequest()
        {

        }

    }
}
