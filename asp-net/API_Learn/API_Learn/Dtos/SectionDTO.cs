using DSLearn.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DSLearn.Dtos
{
    public class SectionDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public string ImgUri { get; set; }
        public int? PrerequesiteId { get; set; }
        public List<LessonDTO> Lessons { get; set; }

        public SectionDTO(Section entity)
        {
            this.Id = entity.Id;
            this.Title = entity.Title;
            this.Description = entity.Description;
            this.Position = entity.Position;
            this.ImgUri = entity.ImgUri;
            this.PrerequesiteId = entity.PreRequisiteId;

            this.Lessons = entity.Lessons != null ?
                entity.Lessons.AsEnumerable().Select(l => ConvertLessonToDTO(l)).ToList() : null;
        }

        // tentando implementar um retorno personalizado se for uma Task ou se for um Content
        private LessonDTO ConvertLessonToDTO(Lesson lesson)
        {
            if (lesson is Entities.Task)
            {
                return new TaskDTO((Entities.Task) lesson); 
            }
            else if (lesson is Content)
            {
                return new ContentDTO(lesson);
            }
            return new LessonDTO(lesson);
        }
    }
}
