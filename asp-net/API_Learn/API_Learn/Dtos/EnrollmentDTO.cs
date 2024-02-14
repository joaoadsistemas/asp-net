using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class EnrollmentDTO
    {

        public int OfferId { get; set; }

        public string UserId { get; set; }

        public DateTime EnrollMoment { get; set; }
        public DateTime? RefundMoment { get; set; } = null;
        public bool Available { get; set; }
        public bool OnlyUpdate { get; set; }


        public IEnumerable<LessonDTO> LessonsDone { get; set; }

        public IEnumerable<DeliverDTO> Deliveries { get; set; }


        public EnrollmentDTO(Enrollment entity)
        {
            this.OfferId = entity.OfferId;
            this.UserId = entity.UserId;
            this.EnrollMoment = entity.EnrollMoment;
            this.RefundMoment = entity.RefundMoment;
            this.Available = entity.Available;
            this.OnlyUpdate = entity.OnlyUpdate;

            this.LessonsDone = null;///// implementar
            this.Deliveries = null;//// implementar
        }

    }
}