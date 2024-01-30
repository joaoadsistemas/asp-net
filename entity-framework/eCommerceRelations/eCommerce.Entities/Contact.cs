namespace eCommerce.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        
        // cria uma tabela no Banco de Dados
        public int UserId { get; set; }
        // Usado apenas para navegação, exemplo, Contact.User.Name
        public User User { get; set; }
    }
}