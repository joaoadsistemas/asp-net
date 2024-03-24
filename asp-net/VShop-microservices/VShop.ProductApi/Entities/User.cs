using Microsoft.AspNetCore.Identity;

namespace VShop.ProductApi.Entities
{
    public class User : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
