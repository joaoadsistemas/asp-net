using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Entities
{
    public class DeliverAddress
    {
        public int Id { get; set; }
        public string AddressName { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }

        // cria uma tabela no Banco de Dados
        [ForeignKey("User")]
        public int UserId { get; set; }
        // Usado apenas para navegação, exemplo, DeliverAddress.User.Name
        public User User { get; set; }
    }
}