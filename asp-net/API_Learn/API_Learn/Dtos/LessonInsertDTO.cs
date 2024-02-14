using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class LessonInsertDTO
    {


        public string Title { get; set; }
        public int Position { get; set; }
        public int SectionId { get; set; }


        public LessonInsertDTO()
        {
            
        }
        public LessonInsertDTO(string title, int position, int sectionId)
        {
            this.Title = title;
            this.Position = position;
            this.SectionId = sectionId;
        }
    }
}