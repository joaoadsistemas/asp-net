using DSLearn.Entities;
using System;

namespace DSLearn.Dtos
{
    public class TaskInsertDTO : LessonInsertDTO
    {
        public string Description { get; set; }
        public int QuestionCount { get; set; }
        public int ApprovalCount { get; set; }
        public double Weight { get; set; } = 1.0;
        public DateTime DueMoment { get; set; }

        public TaskInsertDTO()
        {
            
        }

        public TaskInsertDTO(Entities.Task taskEntity) : base(taskEntity.Title, taskEntity.Position, taskEntity.SectionId)
        {
            this.Description = taskEntity.Description;
            this.QuestionCount = taskEntity.QuestionCount;
            this.ApprovalCount = taskEntity.ApprovalCount;
            this.Weight = taskEntity.Weight;
            this.DueMoment = taskEntity.DueMoment;
        }
    }
}