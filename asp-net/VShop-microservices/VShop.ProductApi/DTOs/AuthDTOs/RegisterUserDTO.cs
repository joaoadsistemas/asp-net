using System.ComponentModel.DataAnnotations;
namespace VShop.ProductApi.DTOs.AuthDTOs;

public class RegisterUserDTO
    {
        [Required(ErrorMessage = "User name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email {  get; set; }

        [Required(ErrorMessage = "BirthDate is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        

    }

