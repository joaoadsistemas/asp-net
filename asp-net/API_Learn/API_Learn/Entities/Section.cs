using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSLearn.Entities
{
    [Table("tb_section")]
    public class Section
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public string ImgUri { get; set; }

        public int? PreRequisiteId { get; set; }
        public Section? PreRequisite { get; set; }


        public int ResourceId { get; set; }
        public Resource Resource { get; set; }

        public IEnumerable<Lesson> Lessons { get; set; }
    }

}
