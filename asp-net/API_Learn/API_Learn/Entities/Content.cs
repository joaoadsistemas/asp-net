using System.ComponentModel.DataAnnotations.Schema;

namespace DSLearn.Entities
{
    [Table("tb_content")]
    public class Content
    {
        public string? TextContent { get; set; }
        public string? VideoUri { get; set; }
    }
}
