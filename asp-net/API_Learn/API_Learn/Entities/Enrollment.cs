using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSLearn.Entities
{
    [Table("tb_enrollment")]
    public class Enrollment
    {
        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime EnrollMoment { get; set; }
        public DateTime? RefundMoment { get; set; } = null;
        public bool Available { get; set; }
        public bool OnlyUpdate { get; set; }

      
        public IEnumerable<Lesson> LessonsDone { get; set; }

        public IEnumerable<DeliverDTO> Deliveries { get; set; }
    }
}
