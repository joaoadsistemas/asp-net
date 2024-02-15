using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class ContentDTO : LessonDTO
    {


        public string? TextContext {  get; set; }
        public string? VideoUri {  get; set; }


        public ContentDTO(Content contentEntity) : base(contentEntity)
        {
            base.Id = contentEntity.Id;
            base.Title = contentEntity.Title;
            base.Position = contentEntity.Position;
            this.TextContext = contentEntity.TextContent;
            this.VideoUri = contentEntity.VideoUri;

            base.Deliveries = contentEntity.Deliveries?.Select(d => new DeliverDTO(d));
            base.EnrollmentsDone = contentEntity.EnrollmentsDone?.Select(e => new EnrollmentDTO(e));
            base.Topics = contentEntity.Topics?.Select(t => new TopicDTO(t));
        }

    }
}