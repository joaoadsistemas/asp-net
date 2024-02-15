using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class ContentInsertDTO : LessonInsertDTO
    {


        public string? TextContext {  get; set; }
        public string? VideoUri {  get; set; }


        public ContentInsertDTO()
        {
            
        }

        public ContentInsertDTO(Content contentEntity) : base(contentEntity.Title, contentEntity.Position, contentEntity.SectionId)
        {
            this.TextContext = contentEntity.TextContent;
            this.VideoUri = contentEntity.VideoUri;
        }

    }
}