using DSCommerce.Entities;

namespace DSCommerce.Dto
{
    public class UserSimpleDTO
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime birthDate { get; set; }



        public UserSimpleDTO()
        {

        }

        public UserSimpleDTO(long id, string name, string email, string password, string phone, DateTime birthDate)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
            this.birthDate = birthDate;
        }


        public UserSimpleDTO(User entity)
        {
            this.Name = entity.Name;
            this.Email = entity.Email;
            this.Password = entity.Password;
            this.Phone = entity.Phone;
            this.birthDate = entity.birthDate;

        }

    }
}
