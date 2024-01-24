using System.ComponentModel.DataAnnotations.Schema;

namespace DSCommerce.Entities
{

    [Table("tb_user")]
    public class User
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        [Column("birth_date")]
        public DateTime birthDate { get; set; }

        public HashSet<Order> orders { get; set; } = new HashSet<Order>();

        public User()
        {

        }

        public User(long id, string name, string email, string password, string phone, DateTime birthDate)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
            this.birthDate = birthDate;
        }


    }
}
