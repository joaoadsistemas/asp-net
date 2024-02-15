using DSLearn.Entities;

namespace DSLearn.Dtos
{
    public class TaskDTO : LessonDTO
    {

        public string Description { get; set; }
        public int QuestionCount { get; set; }
        public int ApprovalCount { get; set; }
        public double Weight { get; set; } = 1.0;
        public DateTime DueDate { get; set; }



        public TaskDTO(Entities.Task taskEntity) : base(taskEntity)
        {
            base.Id = taskEntity.Id;
            base.Title = taskEntity.Title;
            base.Position = taskEntity.Position;
            this.Description = taskEntity.Description;
            this.QuestionCount = taskEntity.QuestionCount;
            this.ApprovalCount = taskEntity.ApprovalCount;
            this.Weight = taskEntity.Weight;
            this.DueDate = taskEntity.DueMoment;

            base.Deliveries = taskEntity.Deliveries?.Select(d => new DeliverDTO(d));
            base.EnrollmentsDone = taskEntity.EnrollmentsDone?.Select(e => new EnrollmentDTO(e));
            base.Topics = taskEntity.Topics?.Select(t => new TopicDTO(t));
        }
    }
}
