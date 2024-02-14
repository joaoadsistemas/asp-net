using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class LessonDTO
    {


        public int Id { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }

        public IEnumerable<DeliverDTO> Deliveries { get; set; }

        public IEnumerable<EnrollmentDTO> EnrollmentsDone { get; set; }

        public IEnumerable<TopicDTO> Topics { get; set; }

        public LessonDTO(Lesson entity)
        {
            this.Id = entity.Id;
            this.Title = entity.Title;
            this.Position = entity.Position;
            this.Deliveries = entity.Deliveries != null ? entity.Deliveries.AsEnumerable().Select(d => new DeliverDTO(d)) : null;
            this.EnrollmentsDone = entity.EnrollmentsDone != null ? entity.EnrollmentsDone.AsEnumerable().Select(d => new EnrollmentDTO(d)) : null;
            this.Topics = entity.Topics != null ? entity.Topics.AsEnumerable().Select(d => new TopicDTO(d)) : null;
        }

    }
}