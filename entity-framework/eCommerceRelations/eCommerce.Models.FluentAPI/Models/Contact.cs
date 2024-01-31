using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Entities

{
    public class Contact
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        
      
        public int UserId { get; set; }
        public User User { get; set; }
    }
}