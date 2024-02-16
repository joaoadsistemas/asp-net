using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class TopicInsertDTO
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Moment { get; set; }
        
        public string AuthorId {  get; set; }
        public int LessonId { get; set; }
        public int OfferId { get; set; }
    }
}