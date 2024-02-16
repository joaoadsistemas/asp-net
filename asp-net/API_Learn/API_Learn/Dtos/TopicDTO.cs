using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class TopicDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Moment { get; set; }


        public IEnumerable<UserDTO> Likes { get; set; }

        public ReplyDTO? Answer { get; set; }


        public IEnumerable<ReplyDTO> Replies { get; set; }

        public TopicDTO(Topic entity)
        {
            this.Id = entity.Id;
            this.Title = entity.Title;
            this.Body = entity.Body;
            this.Moment = entity.Moment;
            this.Likes = entity.Likes != null ? entity.Likes.AsEnumerable().Select(l => new UserDTO(l)) : null;
            this.Answer = entity.Answer != null ? new ReplyDTO(entity.Answer) : null;
            this.Replies = entity.Replies != null ? entity.Replies.AsEnumerable().Select(r => new ReplyDTO(r)) : null; ;
        }
    }
}