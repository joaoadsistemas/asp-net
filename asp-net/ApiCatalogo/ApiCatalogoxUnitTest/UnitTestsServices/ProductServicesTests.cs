using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories.db;
using ApiCatalogo.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiCatalogoxUnitTest.UnitTestsServices
{
    public class ProductServicesTests
    {
        private async Task<SystemDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<SystemDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new SystemDbContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Products.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Products.Add(
                        new ApiCatalogo.Entities.Product()
                        {
                            Name = "ProductTest" + i,
                            Price = i,
                            Description = "Lorem ipsum, Lorem ipsum, Lorem ipsum",
                            ImgUrl = "https://img.com.br/" + i,
                            RegisterData = DateTimeOffset.Now,
                            Stock = i,
                            Category = new ApiCatalogo.Entities.Category()
                            {
                                Name = "CategoryTest" + i,
                                ImgUrl = "img.com.br"
                            }
                        });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async void GetProductsShouldReturnListOfProductDTO()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var productService = new ProductService(dbContext);


            var productNameToSearch = "ProductTest5";

            var pagedQuery = new PageQueryParams
            {
                Name = productNameToSearch
            };

            //Act
            var result = await productService.FindAllProductsAsync(pagedQuery);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<ProductDTO>>(result);

            Assert.True(result.All(product => product.Name.Contains(productNameToSearch)));
        }

        [Fact]
        public async void GetProductByIdShouldReturnProductDTOWhenExistsId()
        {

            //Arrange
            var dbContext = await GetDatabaseContext();
            var productService = new ProductService(dbContext);
            var existsId = 2;

            //Act
            var result = await productService.FindProductByIdAsync(existsId);


            //Assert
            Assert.NotNull(result);
            Assert.IsType<ProductDTO>(result);
            Assert.Equal(existsId, result.Id);
        }
    }
}
