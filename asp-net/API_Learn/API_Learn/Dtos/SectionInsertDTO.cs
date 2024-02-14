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

        public int? PrerequesiteId { get; set; }

    }
}