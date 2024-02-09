using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSLearn.Entities
{

    [Table("tb_offer")]
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        public string Edition { get; set; }
        public DateTime StartMoment { get; set; }
        public DateTime EndMoment { get; set; }



        public int CourseId { get; set; }
        public Course Course { get; set;}


        public IEnumerable<Resource> Resources { get; set; }

    }
}
