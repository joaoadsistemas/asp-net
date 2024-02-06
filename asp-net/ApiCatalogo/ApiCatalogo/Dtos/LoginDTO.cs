﻿using System.ComponentModel.DataAnnotations;

namespace ApiCatalogo.Dtos
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "User name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }
}
