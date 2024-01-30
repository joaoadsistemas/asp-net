using System;

namespace eCommerce.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public char Genre { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string MotherName { get; set; }
        public char RegisterSituation { get; set; }
        public DateTimeOffset RegisterTime { get; set; }
        
        // permite a navegação, exemplo, User.Contact.CellPhone
        public Contact Contact { get; set; }
        
        /*
         * TODO - Vincular com as classes:
         * - DeliverAddress
         * - Department
         */
    }
}