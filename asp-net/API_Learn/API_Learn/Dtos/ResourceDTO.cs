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

        public IEnumerable<SectionDTO> Sections { get; set; }


        public ResourceDTO(Resource entity)
        {
            this.Id = entity.Id;
            this.Title = entity.Title;
            this.imgUri = entity.imgUri;
            this.Description = entity.Description;
            this.Position = entity.Position; 
            this.Type = entity.Type;
            this.ExternalLink = entity.ExternalLink;
            this.Sections = entity.Sections != null ? entity.Sections.AsEnumerable().Select(s => new SectionDTO(s)) : null;
        }
    }
}