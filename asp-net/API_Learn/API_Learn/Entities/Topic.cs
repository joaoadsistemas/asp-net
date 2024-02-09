using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSLearn.Entities
{
    [Table("tb_topic")]
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Moment { get; set; }


        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }


        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        public IEnumerable<User> Likes { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }


        public int? ReplyId { get; set; }
        public Reply? Reply { get; set; }


        public IEnumerable<Reply> Replies { get; set; }


    }
}
