using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using ApiCatalogo.Repositories.db;
using ApiCatalogo.Services;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
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


            var productNameToSearch = "ProductTest1";

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
            var existsId = 1;

            //Act
            var result = await productService.FindProductByIdAsync(existsId);


            //Assert
            Assert.NotNull(result);
            Assert.IsType<ProductDTO>(result);
            Assert.Equal(existsId, result.Id);
        }




        [Fact]
        public async void InsertShouldReturnProductDTO()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var productService = new ProductService(dbContext);
            var productInsertDTO = new ProductInsertDTO()
            {
                Name = "ProductInsert",
                Description = "DescriptionInsert",
                ImgUrl = "https://imgteste.com",
                Price = 1,
                Stock = 1,
                CategoryId = 1
            };


            //Act
            var result = productService.InsertProduct(productInsertDTO);


            //Assert
            Assert.NotNull(result);
            Assert.IsType<ProductDTO>(result);
            Assert.Equal(productInsertDTO.Name, result.Name);

        }



        [Fact]
        public async void InsertShouldThrowExceptionWhenCategoryIdDoesNotExists()
        {

            //Arrange
            var dbContext = await GetDatabaseContext();
            var productService = new ProductService(dbContext);
            var expectedErrorMessage = "Resource not found";
            var productInsertDTO = new ProductInsertDTO()
            {
                Name = "ProductInsert",
                Description = "DescriptionInsert",
                ImgUrl = "https://imgteste.com",
                Price = 1,
                Stock = 1,
                CategoryId = 1000
            };



            //Act //Assert
            var exception = await Assert.ThrowsAsync<Exception>(async () =>
                productService.InsertProduct(productInsertDTO));


            Assert.Equal(expectedErrorMessage, exception.Message); ;
        }



        [Fact]
        public async void UpdateShouldReturnProductDTOWhenIdExists()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var productService = new ProductService(dbContext);
            var existsId = 1;
            var productInsertDTO = new ProductInsertDTO()
            {
                Name = "ProductInsert",
                Description = "DescriptionInsert",
                ImgUrl = "https://imgteste.com",
                Price = 1,
                Stock = 1,
                CategoryId = 1
            };

            //Act
            var result = productService.UpdateProduct(productInsertDTO,existsId);


            //Assert
            Assert.NotNull(result);
            Assert.IsType<ProductDTO> (result);
            Assert.Equal(productInsertDTO.Name, result.Name);
        }


        [Fact]
        public async void UpdateShouldThrowExceptionWhenIdDoesNotExists()
        {

            //Arrange
            var dbContext = await GetDatabaseContext();
            var productService = new ProductService (dbContext);
            var nonExistsId = 1000;
            var expectedErrorMessage = "Resource not found";
            var productInsertDTO = new ProductInsertDTO()
            {
                Name = "ProductInsert",
                Description = "DescriptionInsert",
                ImgUrl = "https://imgteste.com",
                Price = 1,
                Stock = 1,
                CategoryId = 1
            };



            //Act //Assert
            var exception = await Assert.ThrowsAsync<Exception>(async () =>
                productService.UpdateProduct(productInsertDTO, nonExistsId));


            Assert.Equal(expectedErrorMessage, exception.Message);


        }


        [Fact]
        public async void UpdateShouldThrowExceptionWhenCategoryIdDoesNotExists()
        {


            //Arrange
            var dbContext = await GetDatabaseContext();
            var productService = new ProductService(dbContext);
            var existsId = 1;
            var expectedErrorMessage = "Resource not found";
            var productInsertDTO = new ProductInsertDTO()
            {
                Name = "ProductInsert",
                Description = "DescriptionInsert",
                ImgUrl = "https://imgteste.com",
                Price = 1,
                Stock = 1,
                CategoryId = 100
            };


            //Act //Assert
            var exception = await Assert.ThrowsAsync<Exception>(async () =>
                productService.UpdateProduct(productInsertDTO,existsId));


            Assert.Equal(expectedErrorMessage, exception.Message);
        }



        [Fact]
        public async void DeleteProductShouldReturnTrueWhenExistsId()
        {

            //Arrange
            var dbContext = await GetDatabaseContext();
            var productService = new ProductService(dbContext);
            var existsId = 1;



            //Act
            var result = productService.DeleteProduct(existsId);


            //Assert
            Assert.NotNull(result);
            Assert.IsType<bool>(result);
            Assert.True(result);

        }



        [Fact]
        public async void DeleteProductShouldThrowExceptionWhenIdDoesNotExists()
        {

            //Arrange
            var dbContext = await GetDatabaseContext();
            var productService = new ProductService(dbContext);
            var expectedErrorMessage = "Resource not found";
            var nonExistsId = 1000;


            //Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(async () => 
                productService.DeleteProduct(nonExistsId));


            Assert.Equal(expectedErrorMessage, exception.Message);

        }


    }
}
