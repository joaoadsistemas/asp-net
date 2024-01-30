using System;
using System.Collections.Generic;

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
        
        // permite a navegação, exemplo, User.DeliverAddresses[0].ZipCode
        public List<DeliverAddress> DeliverAddresses { get; set; } = new List<DeliverAddress>();

        // relacionamento muitos para muitos simples, SEM DADOS ADICIONAISNA TABELA, apenas o Id do Department e do User
        public List<Department> Departments { get; set; } = new List<Department>();
        
    }
}