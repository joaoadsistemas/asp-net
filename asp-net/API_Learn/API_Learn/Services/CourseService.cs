using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using DSLearn.Interfaces;
using DSLearn.Repositories.db;
using Microsoft.EntityFrameworkCore;

namespace DSLearn.Services
{
    public class CourseService : ICourseRepository
    {
        private readonly SystemDbContext _dbContext;

        public CourseService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CourseDTO>> FindAllAsync(PageQueryParams pageQueryParams)
        {
            IEnumerable<Course> result = await _dbContext.Courses.Where(c => c.Name.Contains(pageQueryParams.Name))
            .OrderBy(c => c.Name)
            .Skip((pageQueryParams.PageNumber - 1) * pageQueryParams.PageSize)
            .Take(pageQueryParams.PageSize)
            .AsNoTracking().ToListAsync();


            return result.AsEnumerable().Select(c => new CourseDTO(c));
        }

        public async Task<CourseDTO> FindByIdAsync(int id)
        {
            Course result = await _dbContext.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id) ?? throw new ArgumentException("Resource not found");

            return new CourseDTO(result);
        }

        public CourseDTO Insert(CourseInsertDTO courseInsertDTO)
        {
            Course entity = new Course();
            copyDTOToEntity(courseInsertDTO, entity);
            _dbContext.Courses.Add(entity);
            return new CourseDTO(entity);
        }


        public CourseDTO Update(CourseInsertDTO courseInsertDTO, int id)
        {
            Course entity =  _dbContext.Courses
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id) ?? throw new ArgumentException("Resource not found");
                copyDTOToEntity(courseInsertDTO, entity);
            return new CourseDTO(entity);
        }

        public bool Delete(int id)
        {
            Course entity = _dbContext.Courses
                 .AsNoTracking()
                 .FirstOrDefault(c => c.Id == id) ?? throw new ArgumentException("Resource not found");
            _dbContext.Courses.Remove(entity);
            return true;

        }


        private void copyDTOToEntity(CourseInsertDTO courseInsertDTO, Course entity)
        {
            entity.ImgUri = courseInsertDTO.ImgUri;
            entity.ImgGrayUri = courseInsertDTO.ImgGrayUri;
            entity.Name = courseInsertDTO.Name;
        }

    }
}
