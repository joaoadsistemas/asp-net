using System.ComponentModel.DataAnnotations.Schema;

namespace DSLearn.Entities
{
    [Table("tb_enrollment")]
    public class Enrollment
    {

       
        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


        public DateTime EnrollMoment { get; set; }
        public DateTime? RefoundMoment { get; set; } = null;
        public bool Avaiable { get; set; }
        public bool OnlyUpdate { get; set; }

        public IEnumerable<Lesson> LessonsDone { get; set; }

        public IEnumerable<Deliver> Deliveries { get; set;}
    }
}
