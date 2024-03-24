using VShop.ProductApi.DTOs.CategoryDTOs;
using VShop.ProductApi.DTOs.UserDTOs;

namespace VShop.ProductApi.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set;}
        public long Stock {  get; set;}
        public Byte[] Img { get; set; }

        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();



    }
}
