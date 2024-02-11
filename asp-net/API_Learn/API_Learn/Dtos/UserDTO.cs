using DSLearn.Entities;
using Microsoft.AspNetCore.Identity;

namespace DSLearn.Dtos
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberIsConfirmed { get; set; }


        public UserDTO(User entity)
        {
            this.Id = entity.Id;
            this.UserName = entity.UserName;
            this.Email = entity.Email;
            this.PhoneNumber = entity.PhoneNumber;
            this.PhoneNumberIsConfirmed = entity.PhoneNumberConfirmed;
        }

    }
}
