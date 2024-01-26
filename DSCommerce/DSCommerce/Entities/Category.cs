using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DSCommerce.Entities
{

    [Table("tb_category")]
    public class Category
    {

        public long Id { get; set; }
        public string name { get; set; }

        [JsonIgnore]
        public List<Product> products { get; set; } = new List<Product>();

    }
}
