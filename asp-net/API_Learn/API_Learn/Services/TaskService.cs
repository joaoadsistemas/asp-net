using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using DSLearn.Interfaces;
using DSLearn.Repositories.db;
using Microsoft.EntityFrameworkCore;

namespace DSLearn.Services
{
    public class TaskService : ITaskRepository
    {

        private readonly SystemDbContext _dbContext;
        public TaskService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TaskDTO>> FindAllAsync(PageQueryParams pageQueryParams)
        {
            IEnumerable<Entities.Task> tasks = await _dbContext.Tasks
                .Include(t => t.EnrollmentsDone)
                .Include(t => t.Topics)
                .Include(t => t.Deliveries)
                .Where(t => t.Title.Contains(pageQueryParams.Name))
                .OrderBy(t => t.Title)
                .Skip((pageQueryParams.PageNumber - 1) * pageQueryParams.PageSize)
                .Take(pageQueryParams.PageSize)
                .AsNoTracking().ToListAsync();

            return tasks.AsEnumerable().Select(t => new TaskDTO(t));
        }

        public async Task<TaskDTO> FindByIdAsync(int id)
        {
            Entities.Task entity = await _dbContext.Tasks
                .Include(t => t.EnrollmentsDone)
                .Include(t => t.Topics)
                .Include(t => t.Deliveries)
                .AsNoTracking().FirstOrDefaultAsync(t => t.Id == id) ?? throw new ArgumentException("Resource not found");

            return new TaskDTO(entity);
        }

        public TaskDTO Insert(TaskInsertDTO taskInsertDTO)
        {
            Entities.Task entity = new Entities.Task();
            copyDTOToEntity(taskInsertDTO, entity);
            _dbContext.Tasks.Add(entity);
            return new TaskDTO(entity);
        }

        public TaskDTO Update(TaskInsertDTO taskInsertDTO, int id)
        {
            Entities.Task entity = _dbContext.Tasks
                .Include(t => t.EnrollmentsDone)
                .Include(t => t.Topics)
                .Include(t => t.Deliveries)
                .FirstOrDefault(t => t.Id == id) ?? throw new ArgumentException("Resource not found");
            copyDTOToEntity(taskInsertDTO, entity);
            return new TaskDTO(entity);
        }


        public bool Delete(int id)
        {
            Entities.Task entity = _dbContext.Tasks
                .Include(t => t.EnrollmentsDone)
                .Include(t => t.Topics)
                .Include(t => t.Deliveries)
                .FirstOrDefault(t => t.Id == id) ?? throw new ArgumentException("Resource not found");
            _dbContext.Tasks.Remove(entity);
            return true;
        }



        private void copyDTOToEntity(TaskInsertDTO taskInsertDTO, Entities.Task entity)
        {
            entity.Title = taskInsertDTO.Title;
            entity.Position = taskInsertDTO.Position;

            Section section = _dbContext.Sections.Find(taskInsertDTO.SectionId);

            entity.SectionId = section.Id;


            entity.Description = taskInsertDTO.Description;
            entity.QuestionCount = taskInsertDTO.QuestionCount;
            entity.ApprovalCount = taskInsertDTO.ApprovalCount;
            entity.Weight = taskInsertDTO.Weight;
            entity.DueMoment = taskInsertDTO.DueMoment;
        }

    }
}
