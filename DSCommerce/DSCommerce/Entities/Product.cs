using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DSCommerce.Entities
{
    [Table("tb_product")]
    public class Product
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        [Column("img_url")]
        public string imgUrl { get; set; }

        [JsonIgnore]
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
