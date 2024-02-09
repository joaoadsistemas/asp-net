using DSLearn.Entities.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSLearn.Entities
{
    [Table("tb_resource")]
    public class Resource
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public string imgUri { get; set; }
        public ResourceType Type { get; set; }
        public string? ExternalLink{ get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        public IEnumerable<Section> Sections { get; set; }

    }
}
