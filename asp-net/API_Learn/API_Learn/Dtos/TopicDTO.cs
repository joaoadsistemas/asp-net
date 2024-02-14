using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class TopicDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Moment { get; set; }


        public int LessonId { get; set; }

        public int OfferId { get; set; }

        public IEnumerable<UserDTO> Likes { get; set; }

        public string AuthorId { get; set; }


        public int? AnswerId { get; set; }


        public IEnumerable<ReplyDTO> Replies { get; set; }

        public TopicDTO(Topic entity)
        {
            this.Id = entity.Id;
            this.Title = entity.Title;
            this.Body = entity.Body;
            this.Moment = entity.Moment;
            this.LessonId = entity.LessonId;
            this.OfferId = entity.OfferId;
            this.Likes = entity.Likes != null ? entity.Likes.AsEnumerable().Select(l => new UserDTO(l)) : null;
            this.AnswerId = entity.AnswerId;
            this.Replies = null;// implementar
        }
    }
}