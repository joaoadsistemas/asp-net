using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Entities

{
    public class Contact
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        
        /*
         * Vira uma coluna
         * cria uma tabela no Banco de Dados
         */
        [ForeignKey("User")]
        public int UserId { get; set; }
        /*
         * O banco não conhece, usada ao nível de POO apenas
         * Usado apenas para navegação, exemplo, Contact.User.Name
         */
        public User User { get; set; }
    }
}