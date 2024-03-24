using System.ComponentModel.DataAnnotations;
namespace VShop.ProductApi.DTOs.AuthDTOs;

public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }

