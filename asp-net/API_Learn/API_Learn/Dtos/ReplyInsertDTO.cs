using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class ReplyInsertDTO
    {


        public string Body { get; set; }
        public DateTime Moment {  get; set; }

        public int TopicId { get; set; }
        public string AuthorId { get; set; }


    }
}