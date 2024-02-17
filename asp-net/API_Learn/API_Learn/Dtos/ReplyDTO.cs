using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class ReplyDTO
    {

        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Moment {  get; set; }

        public IEnumerable<UserDTO> Likes { get; set; }

        public string AuthorId { get; set; }

        public ReplyDTO(Reply entity)
        {
            this.Id = entity.Id;
            this.Body = entity.Body;
            this.Moment = entity.Moment;
            this.Likes = entity.Likes != null ? entity.Likes.AsEnumerable().Select(l => new UserDTO(l)) : null;
            this.AuthorId = entity.AuthorId;
        }

    }
}