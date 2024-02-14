using DSLearn.Entities;
using DSLearn.Entities.enums;

namespace DSLearn.Dtos
{
    public class ResourceInsertDTO
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public string imgUri { get; set; }
        public ResourceType Type { get; set; }
        public string? ExternalLink { get; set; }

        public int OfferId { get; set; }
    }
}