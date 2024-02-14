using DSLearn.Entities;
using DSLearn.Entities.enums;

namespace DSLearn.Dtos
{
    public class ResourceDTO
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public string imgUri { get; set; }
        public ResourceType Type { get; set; }
        public string? ExternalLink { get; set; }

        public int OfferId { get; set; }

        public IEnumerable<SectionDTO> Sections { get; set; }


        public ResourceDTO(Resource entity)
        {
            this.Id = entity.Id;
            this.Title = entity.Title;
            this.Description = entity.Description;
            this.Position = entity.Position;
            this.imgUri = entity.imgUri;
            this.Type = entity.Type;
            this.ExternalLink = entity.ExternalLink;
            this.OfferId = entity.OfferId;
            this.Sections = null;// implementar
        }
    }
}