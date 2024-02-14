using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class LessonDTO
    {


        public int Id { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }

        public LessonDTO(Lesson entity)
        {
            this.Id = entity.Id;
            this.Title = entity.Title;
            this.Position = entity.Position;
        }

    }
}