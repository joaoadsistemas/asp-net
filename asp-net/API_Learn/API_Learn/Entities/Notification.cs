using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSLearn.Entities
{
    [Table("tb_notification")]
    public class Notification
    {

        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Moment { get; set; }
        public bool Read { get; set; } = false;
        public string Route { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

    }
}
