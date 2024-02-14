using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class OfferInsertDTO
    {
        public string Edition { get; set; }
        public DateTime StartMoment { get; set; }
        public DateTime EndMoment { get; set; }

        public int CourseId { get; set; }

    }
}