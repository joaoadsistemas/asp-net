using ApiCatalogo.Dtos;
using ApiCatalogo.Entities;
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
    public class CategoryServiceTests
    {

        private async Task<SystemDbContext> GetDatabaseContext()
        {
            // Configuração de um contexto de banco de dados em memória para testes
            var options = new DbContextOptionsBuilder<SystemDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new SystemDbContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Categories.CountAsync() <= 0)
            {
                // Adição de dados de teste ao banco de dados em memória
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Categories.Add(
                        new Category()
                        {
                            Name = "CategoryTest" + i,
                            ImgUrl = "img.com.br",
                            Products = new List<Product>()
                            {
                                new Product()
                                {
                                    Name = "ProductTest" + i,
                                    Price = i,
                                    Stock = i,
                                    ImgUrl = "img.com.br"
                                }
                            }
                        });
                    await databaseContext.SaveChangesAsync();
                }
            }

            return databaseContext;
        }

        [Fact]
        public async void GetAllCategoriesShouldReturnListOfCategories()
        {
            // Arrange
            var dbContext = await GetDatabaseContext();
            var categoryService = new CategoryService(dbContext);

            // Act
            var result = categoryService.FindAllCategoriesAsync();

            // Assert
            Assert.NotNull(result);
            await Assert.IsType<Task<IEnumerable<CategoryDTO>>>(result);
        }


        [Fact]
        public async void GetCategoryByIdShouldReturnCategoryWhenExistsId()
        {
            // Arrange
            var dbContext = await GetDatabaseContext();
            var categoryService = new CategoryService(dbContext);
            var existsId = 1;

            // Act
            var result = categoryService.FindCategoryByIdAsync(existsId);

            // Assert
            Assert.NotNull(result);
            await Assert.IsType<Task<CategoryDTO>>(result);
            Assert.Equal(existsId, result.Id);
        }


        [Fact]
        public async void GetCategoryByIdShouldThrowExceptionWhenIdDoesNotExists()
        {

            // Arrange
            var dbContext = await GetDatabaseContext();
            var categoryService = new CategoryService(dbContext);
            var nonExistsId = 1000;
            var expectedErrorMessage = "Resource not found";

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(async () =>
                await categoryService.FindCategoryByIdAsync(nonExistsId));

            // Assert the message
            Assert.Equal(expectedErrorMessage, exception.Message);
        }



        [Fact]
        public async void UpdateCategoryShouldReturnCategoryDTOWhenIdExists()
        {

            // Arrange
            var dbContext = await GetDatabaseContext();
            var categoryService = new CategoryService(dbContext);
            var existsId = 1;
            var updateCategory = new CategoryInsertDTO()
            {
                Name = "NewTest",
                ImgUrl = "img.com.br"
            };

            // Act
            var result = categoryService.UpdateCategory(updateCategory, existsId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CategoryDTO>(result);
            Assert.Equal(existsId, result.Id);
            Assert.Equal(updateCategory.Name, result.Name);
        }


        [Fact]
        public async void UpdateCategoryShouldThrowExceptionWhenIdDoesNotExists()
        {

            // Arrange
            var dbContext = await GetDatabaseContext();
            var categoryService = new CategoryService(dbContext);
            var nonExistsId = 1000;
            var expectedErrorMessage = "Resource not found";
            var updateCategory = new CategoryInsertDTO()
            {
                Name = "NewTest",
                ImgUrl = "img.com.br"
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(async () =>
                categoryService.UpdateCategory(updateCategory, nonExistsId));

            Assert.Equal(expectedErrorMessage, exception.Message);
        }




        [Fact]
        public async void DeleteCategoryShouldReturnTrueWhenIdExists()
        {

            // Arrange
            var dbContext = await GetDatabaseContext();
            var categoryService = new CategoryService(dbContext);
            var existsId = 1;

            // Act
            var result = categoryService.DeleteCategory(existsId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<bool>(result);
            Assert.True(result);
        }


        [Fact]
        public async void DeleteCategoryShouldThrowExceptionWhenIdDoesNotExists()
        {

            // Arrange
            var dbContext = await GetDatabaseContext();
            var categoryService = new CategoryService(dbContext);
            var nonExistsId = 1000;
            var expectedErrorMessage = "Resource not found";

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(async () =>
                categoryService.DeleteCategory(nonExistsId));

            Assert.Equal(expectedErrorMessage, exception.Message);
        }

    }
}
