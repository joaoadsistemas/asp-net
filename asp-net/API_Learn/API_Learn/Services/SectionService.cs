using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using DSLearn.Interfaces;
using DSLearn.Repositories.db;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Repositories
{
    internal class SectionService : ISectionRepository
    {

        private readonly SystemDbContext _dbContext;
        public SectionService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SectionDTO>> FindAllAsync(PageQueryParams pageQueryParams)
        {
            IEnumerable<Section> sections = await _dbContext.Sections.Include(s => s.Lessons)
                .Where(s => s.Title.Contains(pageQueryParams.Name))
                .OrderBy(s => s.Title)
                .Skip((pageQueryParams.PageNumber - 1) * pageQueryParams.PageSize)
                .Take(pageQueryParams.PageSize)
                .AsNoTracking().ToListAsync();

            return sections.AsEnumerable().Select(s => new SectionDTO(s));
        }

        public async Task<SectionDTO> FindByIdAsync(int id)
        {
            Section section = await _dbContext.Sections.Include(s => s.Lessons)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id) ?? throw new ArgumentException("Resource not found");

            return new SectionDTO(section);
        }

        public SectionDTO Insert(SectionInsertDTO sectionInsertDTO)
        {
            Section entity = new Section();
            copyDTOToEntity(sectionInsertDTO, entity);
            _dbContext.Sections.Add(entity);
            return new SectionDTO(entity);
        }

        

        public SectionDTO Update(SectionInsertDTO sectionInsertDTO, int id)
        {
            Section entity = _dbContext.Sections.Include(s => s.Lessons)
                .FirstOrDefault(s => s.Id == id) ?? throw new ArgumentException("Resource not found");
            copyDTOToEntity(sectionInsertDTO, entity);
            return new SectionDTO(entity);
        }

        public bool Delete(int id)
        {
            Section entity = _dbContext.Sections.FirstOrDefault(s => s.Id == id) ?? throw new ArgumentException("Resource not found");
            _dbContext.Sections.Remove(entity);
            return true;
        }

        private void copyDTOToEntity(SectionInsertDTO sectionInsertDTO, Section entity)
        {
            entity.Title = sectionInsertDTO.Title;
            entity.Description = sectionInsertDTO.Description;
            entity.Position = sectionInsertDTO.Position;
            entity.ImgUri = sectionInsertDTO.ImgUri;

            Resource resource = _dbContext.Resources.Find(sectionInsertDTO.ResourceId);

            entity.ResourceId = resource.Id;
            entity.PreRequisiteId = sectionInsertDTO.PrerequesiteId;
        }
    }
}