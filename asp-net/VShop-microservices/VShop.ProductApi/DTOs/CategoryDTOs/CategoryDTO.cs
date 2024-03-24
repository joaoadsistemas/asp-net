using VShop.ProductApi.DTOs.ProductDTOs;
using VShop.ProductApi.Entities;


namespace VShop.ProductApi.DTOs.CategoryDTOs
{
    public class CategoryDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductDTO> Products { get; set; } = new List<ProductDTO>();



        public CategoryDTO()
        {
            
        }

        public CategoryDTO(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;

            Products = category.Products.AsEnumerable().Select(p => new ProductDTO(p)).ToList();
        }

    }
}
