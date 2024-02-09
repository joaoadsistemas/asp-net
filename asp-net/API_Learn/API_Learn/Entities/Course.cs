using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSLearn.Entities
{

    [Table("tb_course")]
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUri { get; set; }
        public string ImgGrayUri { get; set; }


        public IEnumerable<Offer> Offers{ get; set; }
    }
}
