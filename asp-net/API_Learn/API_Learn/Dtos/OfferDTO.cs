using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class OfferDTO
    {
        public int Id { get; set; }
        public string Edition { get; set; }
        public DateTime StartMoment { get; set; }
        public DateTime EndMoment { get; set; }


        public IEnumerable<UserInfoDTO> Users { get; set; }

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
            this.Users = entity.Users.AsEnumerable().Select(u => new UserInfoDTO(u));
            this.Enrollments = null;// implementar
            this.Course = new CourseDTO(entity.Course);
            this.Resources = null;// implementar
            this.Topics = null;// implementar

        }



    }
}