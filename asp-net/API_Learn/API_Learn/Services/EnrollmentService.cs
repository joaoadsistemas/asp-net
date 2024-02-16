using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using DSLearn.Interfaces;
using DSLearn.Repositories.db;
using Microsoft.EntityFrameworkCore;

namespace DSLearn.Services
{
    public class EnrollmentService : IEnrollmentRepository
    {

        private readonly SystemDbContext _dbContext;

        public EnrollmentService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EnrollmentDTO>> FindAllAsync(PageQueryParams pageQueryParams)
        {
            IEnumerable<Enrollment> enrollments= await _dbContext.Enrollments
                .Include(e => e.LessonsDone)
                .Include(e => e.Deliveries)
                .OrderBy(e => e.EnrollMoment)
                .Skip((pageQueryParams.PageNumber - 1) * pageQueryParams.PageSize)
                .Take(pageQueryParams.PageSize)
                .AsNoTracking()
                .ToListAsync();

            return enrollments.Select(e => new EnrollmentDTO(e));
        }

        public async Task<EnrollmentDTO> FindByUserIdAsync(string id)
        {
            Enrollment entity = await _dbContext.Enrollments
                .Include(e => e.LessonsDone)
                .Include(e => e.Deliveries)
                .AsNoTracking().FirstOrDefaultAsync(e => e.UserId == id) ?? throw new ArgumentException("Resource not found");

            return new EnrollmentDTO(entity);
        }


        public async Task<IEnumerable<EnrollmentDTO>> FindBySelfEnrollmentAsync(string id)
        {

            IEnumerable<Enrollment> result = await _dbContext.Enrollments
                .Include(e => e.LessonsDone)
                .Include(e => e.Deliveries)
                .Where(e => e.User.Id == id)
                .AsNoTracking()
                .ToListAsync();

            if (result == null)
            {
                throw new ArgumentException("Resource not found");
            }

            return result.AsEnumerable().Select(e => new EnrollmentDTO(e));
        }

        public async Task<EnrollmentDTO> FindByOfferIdAsync(int id)
        {
            Enrollment entity = await _dbContext.Enrollments
                .Include(e => e.LessonsDone)
                .Include(e => e.Deliveries)
                .AsNoTracking().FirstOrDefaultAsync(e => e.OfferId == id) ?? throw new ArgumentException("Resource not found");

            return new EnrollmentDTO(entity);
        }

        public EnrollmentDTO Insert(EnrollmentInsertDTO enrollmentInsertDTO)
        {
            Enrollment entity = new Enrollment();
            copyDTOToEntity(enrollmentInsertDTO, entity);
            _dbContext.Enrollments.Add(entity);
            return new EnrollmentDTO(entity);
        }

        public EnrollmentDTO Update (EnrollmentInsertDTO enrollmentInsertDTO, int id)
        {
            Enrollment entity = _dbContext.Enrollments
               .Include(e => e.LessonsDone)
               .Include(e => e.Deliveries)
               .FirstOrDefault(e => e.OfferId == id) ?? throw new ArgumentException("Resource not found");
            copyDTOToEntity(enrollmentInsertDTO, entity);
            return new EnrollmentDTO(entity);
        }


        public bool Delete(int id)
        {
            Enrollment entity = _dbContext.Enrollments
               .Include(e => e.LessonsDone)
               .Include(e => e.Deliveries)
               .FirstOrDefault(e => e.OfferId == id) ?? throw new ArgumentException("Resource not found");
            _dbContext.Enrollments.Remove(entity);
            return true;
        }


        private void copyDTOToEntity(EnrollmentInsertDTO enrollmentInsertDTO, Enrollment entity)
        {
            entity.UserId = enrollmentInsertDTO.UserId;
            entity.OfferId = enrollmentInsertDTO.OfferId;
            entity.OnlyUpdate = enrollmentInsertDTO.OnlyUpdate;
        }

    }
}
