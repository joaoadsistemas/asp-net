using DSCommerce.Entities;

namespace DSCommerce.Dto
{
    public class UserDTO
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime birthDate { get; set; }

        public HashSet<OrderDTO> orders { get; set; } = new HashSet<OrderDTO>();


        public UserDTO()
        {

        }

        public UserDTO(long id, string name, string email, string password, string phone, DateTime birthDate)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
            this.birthDate = birthDate;
        }


        public UserDTO(User entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Email = entity.Email;
            this.Password = entity.Password;
            this.Phone = entity.Phone;
            this.birthDate = entity.birthDate;

            foreach (Order order in entity.orders)
            {
                orders.Add(new OrderDTO(order));
            }
        }

    }
}
