using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using one_to_many.Entities;

namespace many_to_many.Entities
{
    public class Skill
    {

        [Key()]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }



        // Configurando um lado MUITOS
        [JsonIgnore] // tirar o cliclo infinito
        public List<Character> Characters { get; set; } = new List<Character>();

    }
}
