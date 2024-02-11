using DSLearn.Entities.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSLearn.Entities
{
    [Table("tb_deliver")]
    public class Deliver
    {

        [Key]
        public int Id { get; set; }
        public string Uri { get; set; }
        public DateTime Moment {  get; set; }
        public DeliverStatus Status { get; set; }
        public string? Feedback { get; set; }
        public int? CorrectCount { get; set; }


        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int OfferId { get; set; }
        public string UserId { get; set; }
        public Enrollment Enrollment { get; set; }

    }
}
