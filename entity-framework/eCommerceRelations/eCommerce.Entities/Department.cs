using System.Collections.Generic;

namespace eCommerce.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // relacionamento muitos para muitos simples, SEM DADOS ADICIONAISNA TABELA, apenas o Id do Department e do User
        public List<User> Users { get; set; } = new List<User>();
    }
}