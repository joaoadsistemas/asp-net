using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using DSLearn.Interfaces;
using DSLearn.Repositories.db;
using Microsoft.EntityFrameworkCore;

namespace DSLearn.Services
{
    public class DeliverService : IDeliverRepository
    {
        private readonly SystemDbContext _dbContext;

        public DeliverService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DeliverDTO>> FindAllAsync(PageQueryParams pageQueryParams)
        {
            IEnumerable<Deliver> deliveries = await _dbContext.Delivers
               .Where(d => d.Uri.Contains(pageQueryParams.Name))
               .OrderBy(d => d.Uri)
               .Skip((pageQueryParams.PageNumber - 1) * pageQueryParams.PageSize)
               .Take(pageQueryParams.PageSize).AsNoTracking().ToListAsync();

            return deliveries.Select(d => new DeliverDTO(d));
        }

        public async Task<DeliverDTO> FindByIdAsync(int id)
        {
            Deliver entity = await _dbContext.Delivers
               .AsNoTracking().FirstOrDefaultAsync(c => c.Id == id) ?? throw new ArgumentException("Resource not found");

            return new DeliverDTO(entity);
        }

        public DeliverDTO Insert(DeliverInsertDTO deliverInsertDTO)
        {
            Deliver entity = new Deliver();
            copyDTOToEntity(deliverInsertDTO, entity);
            _dbContext.Delivers.Add(entity);
            return new DeliverDTO(entity);
        }

        public DeliverDTO Update(DeliverInsertDTO deliverInsertDTO, int id)
        {
            Deliver entity = _dbContext.Delivers
                .FirstOrDefault(d => d.Id == id) ?? throw new ArgumentException("Resource not found");
            copyDTOToEntity(deliverInsertDTO, entity);
            return new DeliverDTO(entity);
        }

        public bool Delete(int id)
        {
            Deliver entity = _dbContext.Delivers
                .FirstOrDefault(d => d.Id == id) ?? throw new ArgumentException("Resource not found"); 
            _dbContext.Delivers.Remove(entity);
            return true;
        }


        private void copyDTOToEntity(DeliverInsertDTO deliverInsertDTO, Deliver entity)
        {
            entity.Uri = deliverInsertDTO.Uri;
            entity.Moment = deliverInsertDTO.Moment;
            entity.Status = deliverInsertDTO.Status;
            entity.Feedback = deliverInsertDTO.Feedback;
            entity.CorrectCount = deliverInsertDTO.correctCount;


            Lesson lesson = _dbContext.Lessons.Find(deliverInsertDTO.LessonId);
            entity.LessonId = lesson.Id;


            Enrollment enrollment = _dbContext.Enrollments.Find(deliverInsertDTO.OfferId, deliverInsertDTO.UserId);

            entity.UserId = enrollment.UserId;
            entity.OfferId = enrollment.OfferId;
           
        }

    }
}
