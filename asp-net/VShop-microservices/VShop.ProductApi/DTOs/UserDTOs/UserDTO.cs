using VShop.ProductApi.DTOs.ProductDTOs;
using VShop.ProductApi.Entities;

namespace VShop.ProductApi.DTOs.UserDTOs
{
    public class UserDTO
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<ProductDTO> Products { get; set; }

        public UserDTO()
        {
            
        }

        public UserDTO(User entity)
        {
            this.Id = entity.Id;
            this.Name = entity.UserName;
            this.Email = entity.Email;
            this.Products = entity.Products.AsEnumerable().Select(p => new ProductDTO(p)).ToList();
        }

    }
}
