using DSLearn.Entities;
using DSLearn.Entities.enums;

namespace DSLearn.Dtos
{
    public class DeliverDTO
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public DateTime Moment { get; set; }
        public DeliverStatus Status { get; set; }
        public string Feedback { get; set; }
        public int? correctCount { get; set; }

        public DeliverDTO(Deliver entity) 
        {
            this.Id = entity.Id;
            this.Uri = entity.Uri;
            this.Moment = entity.Moment;
            this.Status = entity.Status;
            this.Feedback = entity.Feedback;
            this.correctCount = entity.CorrectCount;
        }

    }
}