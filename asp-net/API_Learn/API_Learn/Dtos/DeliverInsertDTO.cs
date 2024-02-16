using DSLearn.Entities.enums;

namespace DSLearn.Dtos
{
    public class DeliverInsertDTO
    {
        public string Uri { get; set; }
        public DateTime Moment { get; set; }
        public DeliverStatus Status { get; set; }
        public string Feedback { get; set; }
        public int? correctCount { get; set; }
        public int OfferId { get; set; }
        public string UserId { get; set; }
        public int LessonId { get; set; }
    }
}