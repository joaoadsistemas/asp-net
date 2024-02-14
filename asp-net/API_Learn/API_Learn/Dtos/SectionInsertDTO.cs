using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class SectionInsertDTO
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public string ImgUri { get; set; }

        public int ResourceId { get; set; }

        public SectionInsertDTO(Section entity)
        {
            this.Title = entity.Title;
            this.Description = entity.Description;
            this.Position = entity.Position;
            this.ImgUri = entity.ImgUri;

            this.ResourceId = entity.ResourceId;
        }
    }
}