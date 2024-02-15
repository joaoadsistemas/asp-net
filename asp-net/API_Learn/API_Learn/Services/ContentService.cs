using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using DSLearn.Interfaces;
using DSLearn.Repositories.db;
using Microsoft.EntityFrameworkCore;

namespace DSLearn.Services
{
    public class ContentService : IContentRepository
    {

        private readonly SystemDbContext _dbContext;

        public ContentService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<ContentDTO>> FindAllAsync(PageQueryParams pageQueryParams)
        {
            IEnumerable<Content> contents = await _dbContext.Contents
                .Include(c => c.EnrollmentsDone)
                .Include(c => c.Topics)
                .Include(c => c.Deliveries)
                .Where(c => c.Title.Contains(pageQueryParams.Name))  
                .OrderBy(c => c.Title)
                .Skip((pageQueryParams.PageNumber - 1) * pageQueryParams.PageSize)
                .Take(pageQueryParams.PageSize)
                .AsNoTracking()
                .ToListAsync();

            return contents.Select(c => new ContentDTO(c));
        }


        public async Task<ContentDTO> FindByIdAsync(int id)
        {
            Content entity = await _dbContext.Contents
               .Include(c => c.EnrollmentsDone)
               .Include(c => c.Topics)
               .Include(c => c.Deliveries)
               .AsNoTracking().FirstOrDefaultAsync(c => c.Id == id) ?? throw new ArgumentException("Resource not found");

            return new ContentDTO(entity);
        }

        public ContentDTO Insert(ContentInsertDTO contentInsertDTO)
        {
            Content entity = new Content();
            copyDTOToEntity(contentInsertDTO, entity);
            _dbContext.Contents.Add(entity);
            return new ContentDTO(entity);
        }

        public ContentDTO Update(ContentInsertDTO contentInsertDTO, int id)
        {
            Content entity = _dbContext.Contents
                .Include(c => c.EnrollmentsDone)
                .Include(c => c.Topics)
                .Include(c => c.Deliveries)
                .FirstOrDefault(c => c.Id == id) ?? throw new ArgumentException("Resource not found");
            copyDTOToEntity(contentInsertDTO, entity);
            return new ContentDTO(entity);
        }

        public bool Delete(int id)
        {
            Content entity = _dbContext.Contents
                .Include(c => c.EnrollmentsDone)
                .Include(c => c.Topics)
                .Include(c => c.Deliveries)
                .FirstOrDefault(c => c.Id == id) ?? throw new ArgumentException("Resource not found");
            _dbContext.Contents.Remove(entity);
            return true;
        }


        private void copyDTOToEntity(ContentInsertDTO contentInsertDTO, Content entity)
        {
            entity.Title = contentInsertDTO.Title;
            entity.Position = contentInsertDTO.Position;

            Section section = _dbContext.Sections.Find(contentInsertDTO.SectionId);

            entity.SectionId = section.Id;


            entity.TextContent = contentInsertDTO.TextContext;
            entity.VideoUri = contentInsertDTO.VideoUri;
        }

    }
}
