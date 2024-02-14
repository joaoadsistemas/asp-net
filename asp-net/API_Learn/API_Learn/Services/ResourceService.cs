using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using DSLearn.Interfaces;
using DSLearn.Repositories.db;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Repositories
{
    internal class ResourceService : IResourceRepository
    {

        private readonly SystemDbContext _dbContext;

        public ResourceService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<IEnumerable<ResourceDTO>> FindAllAsync(PageQueryParams pageQueryParams)
        {
            IEnumerable<Resource> resources = await _dbContext.Resources.Include(r => r.Sections).Where(r => r.Title.Contains(pageQueryParams.Name))
           .OrderBy(r => r.Title)
           .Skip((pageQueryParams.PageNumber - 1) * pageQueryParams.PageSize)
           .Take(pageQueryParams.PageSize)
           .AsNoTracking().ToListAsync();

            return resources.AsEnumerable().Select(r => new ResourceDTO(r));
        }

        public async Task<ResourceDTO> FindByIdAsync(int id)
        {
            Resource resource = await _dbContext.Resources
                .Include(r => r.Sections)
                .AsNoTracking().FirstOrDefaultAsync(r => r.Id == id) ?? throw new ArgumentException("Resource not found");
            return new ResourceDTO(resource);
        }

        public ResourceDTO Insert(ResourceInsertDTO resourceInsertDTO)
        {
            Resource entity = new Resource();
            copyDTOToEntity(resourceInsertDTO, entity);
            _dbContext.Resources.Add(entity);
            return new ResourceDTO(entity);

        }

       

        public ResourceDTO Update(ResourceInsertDTO resourceInsertDTO, int id)
        {
            Resource entity = _dbContext.Resources
                .Include(r => r.Sections)
                .FirstOrDefault(r => r.Id == id) ?? throw new ArgumentException("Resource not found");
            copyDTOToEntity(resourceInsertDTO, entity);
            return new ResourceDTO(entity);

        }


        public bool Delete(int id)
        {
            Resource entity =  _dbContext.Resources.FirstOrDefault(r => r.Id == id) ?? throw new ArgumentException("Resource not found");
            _dbContext.Resources.Remove(entity);
            return true;
    
        }

        private void copyDTOToEntity(ResourceInsertDTO resourceInsertDTO, Resource entity)
        {
            entity.Title = resourceInsertDTO.Title;
            entity.Description = resourceInsertDTO.Description;
            entity.Position = resourceInsertDTO.Position;
            entity.imgUri = resourceInsertDTO.imgUri;
            entity.Type = resourceInsertDTO.Type;
            entity.ExternalLink = resourceInsertDTO.ExternalLink;

            Offer offer = _dbContext.Offers.Find(resourceInsertDTO.OfferId);

            entity.OfferId = offer.Id;
        }
    }
}