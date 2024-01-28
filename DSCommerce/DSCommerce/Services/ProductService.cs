using DSCommerce.Dto;
using DSCommerce.Entities;
using DSCommerce.Repositories;
using DSCommerce.Repositories.db;
using Microsoft.EntityFrameworkCore;

namespace DSCommerce.Services
{
    public class ProductService : ProductRepository
    {
        private readonly SystemDbContext _dbContext;

        public ProductService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<ProductDTO>> FindAll()
        {
            List<Product> products = _dbContext.Products
                .Include(p => p.Categories)
                .ToList();
            return products.AsEnumerable().Select(p => new ProductDTO(p)).ToList();
        }

        public async Task<ProductDTO> FindById(long id)
        {
            Product entity = _dbContext.Products
                .Include(p => p.Categories)
                .SingleOrDefault(p => p.Id == id) ?? throw new Exception("Resource not found");
            return new ProductDTO(entity);


        }

        public async Task<ProductInsertDTO> Insert(ProductInsertDTO dto)
        {
            Product entity = new Product();
            copyDtoToEntity(dto, entity);
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return new ProductInsertDTO(entity);
        }

        

        public async Task<ProductDTO> Update(ProductInsertDTO dto, long id)
        {
            Product entity = _dbContext.Products
                .Include(p => p.Categories)
                .SingleOrDefault(p => p.Id == id) ?? throw new Exception("Resource not found");
            copyDtoToEntity(dto, entity);
            _dbContext.SaveChanges();
            return new ProductDTO(entity);
        }

        public async Task<bool> DeleteById(long id)
        {
            Product entity = _dbContext.Products
                .Include(p => p.Categories)
                .SingleOrDefault(p => p.Id == id) ?? throw new Exception("Resource not found");
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }




        private void copyDtoToEntity(ProductInsertDTO dto, Product entity)
        {
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.Price = dto.Price;
            entity.imgUrl = dto.imgUrl;

            foreach (long categoryId in dto.CategoriesIds)
            {
                Category category = _dbContext.Categories.Find(categoryId) ?? throw new Exception("Resource not found");
                entity.Categories.Add(category);
            }
        }
    }
}
