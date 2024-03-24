using VShop.ProductApi.DTOs.UserDTOs;
using VShop.ProductApi.Entities;

namespace VShop.ProductApi.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public long Stock { get; set; }
        public Byte[] Img { get; set; }

        public int CategoryId { get; set; }

        public ProductDTO()
        {
            
        }


        public ProductDTO(Product entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Description = entity.Description;
            this.Price = entity.Price;
            this.Stock = entity.Stock;
            this.Img = entity.Img;
            this.CategoryId = entity.CategoryId;
        }

    }
}
