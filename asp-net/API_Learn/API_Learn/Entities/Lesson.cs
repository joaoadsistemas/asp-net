using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSLearn.Entities
{
    [Table("tb_lesson")]
    public abstract class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }

        [ForeignKey("SectionId")]
        public Section Section { get; set; }
        public int SectionId { get; set; }


        public IEnumerable<Enrollment> EnrollmentsDone { get; set; }

        public IEnumerable<Deliver> Deliveries { get; set; }

        public IEnumerable<Topic> Topics { get; set; }
    }
}
