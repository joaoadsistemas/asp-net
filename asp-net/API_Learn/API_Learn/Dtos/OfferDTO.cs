using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class OfferDTO
    {
        public int Id { get; set; }
        public string Edition { get; set; }
        public DateTime StartMoment { get; set; }
        public DateTime EndMoment { get; set; }


        public IEnumerable<string> UsersId { get; set; }

        public IEnumerable<EnrollmentDTO> Enrollments { get; set; }


        public CourseDTO Course { get; set; }


        public IEnumerable<ResourceDTO> Resources { get; set; }

        public IEnumerable<TopicDTO> Topics { get; set; }

        public OfferDTO(Offer entity)
        {
            this.Id = entity.Id;
            this.Edition = entity.Edition;
            this.StartMoment = entity.StartMoment;
            this.EndMoment = entity.EndMoment;
            this.UsersId = entity.Users != null ? entity.Users.AsEnumerable().Select(u => u.Id) : null;
            this.Enrollments = entity.Enrollments != null ? entity.Enrollments.AsEnumerable().Select(e => new EnrollmentDTO(e)) : null;
            this.Course = entity.Course != null ? new CourseDTO(entity.Course) : null;
            this.Resources = entity.Resources != null ? entity.Resources.AsEnumerable().Select(r => new ResourceDTO(r)) : null;
            this.Topics = entity.Topics != null ? entity.Topics.AsEnumerable().Select(t => new TopicDTO(t)) : null;
        }



    }
}