using DSLearn.Entities;

namespace DSLearn.Dtos
{
    internal class ContentDTO : LessonDTO
    {
        public ContentDTO(Lesson entity) : base(entity)
        {
        }
    }
}