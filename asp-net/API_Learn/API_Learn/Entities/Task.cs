using System.ComponentModel.DataAnnotations.Schema;

namespace DSLearn.Entities
{
    [Table("tb_lesson")]
    public class Task : Lesson
    {
        public string Description { get; set; }
        public int QuestionCount { get; set; }
        public int ApprovalCount { get; set; }
        public double Weight { get; set; } = 1;
        public DateTime DueMoment { get; set; }

    }
}
