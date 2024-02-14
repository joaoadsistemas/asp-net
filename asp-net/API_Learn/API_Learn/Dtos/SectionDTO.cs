using DSLearn.Entities;

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

        public IEnumerable<LessonDTO> Lessons { get; set; }


        public SectionDTO(Section entity)
        {
            this.Id = entity.Id;
            this.Title = entity.Title;
            this.Description = entity.Description;
            this.Position = entity.Position;
            this.ImgUri = entity.ImgUri;
            this.PrerequesiteId = entity.PreRequisiteId;

            this.Lessons = entity.Lessons != null ? entity.Lessons.AsEnumerable().Select(l => new LessonDTO(l)) : null;
        }
    }
}