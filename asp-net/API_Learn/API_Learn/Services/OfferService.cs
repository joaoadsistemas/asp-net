using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using DSLearn.Interfaces;
using DSLearn.Repositories.db;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Repositories
{
    internal class OfferService : IOfferRepository
    {
        
        private readonly SystemDbContext _dbContext;

        public OfferService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OfferDTO>> FindAllAsync(PageQueryParams pageQueryParams)
        {
            IEnumerable<Offer> result = await _dbContext.Offers
                .Include(o => o.Users)
                .Include(o => o.Enrollments)
                .Include(o => o.Users)
                .Include(o => o.Course)
                .Include(o => o.Resources)
                .Include(o => o.Topics)
                .Where(o => o.Edition.Contains(pageQueryParams.Name))
           .OrderBy(o => o.Edition)
           .Skip((pageQueryParams.PageNumber - 1) * pageQueryParams.PageSize)
           .Take(pageQueryParams.PageSize)
           .AsNoTracking().ToListAsync();


            return result.AsEnumerable().Select(o => new OfferDTO(o));
        }

        public async Task<OfferDTO> FindByIdAsync(int id)
        {
            Offer result = await _dbContext.Offers
                .Include(o => o.Users)
                .Include(o => o.Enrollments)
                .Include(o => o.Users)
                .Include(o => o.Course)
                .Include(o => o.Resources)
                .Include(o => o.Topics)
                .ThenInclude(t => t.Likes)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id) ?? throw new ArgumentException("Resource not found");

            return new OfferDTO(result);
        }

        public async Task<OfferDTO> InsertUserToOffer(OfferUserInsertDTO offerUserInsertDTO)
        {
            Offer entity = await _dbContext.Offers
                .Include(o => o.Users)
                .Include(o => o.Enrollments)
                .Include(o => o.Users)
                .Include(o => o.Course)
                .Include(o => o.Resources)
                .Include(o => o.Topics)
                .ThenInclude(t => t.Likes)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == offerUserInsertDTO.OfferId) ?? throw new ArgumentException("Resource not found");

            User user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == offerUserInsertDTO.UserId) ?? throw new ArgumentException("Resource not found");

            var usersList = entity.Users.ToList();
            usersList.Add(user);
            entity.Users = usersList;

            _dbContext.Offers.Update(entity);

            return new OfferDTO(entity);
        }

        public OfferDTO Insert(OfferInsertDTO offerInsertDTO)
        {
            Offer entity = new Offer();
            copyDTOToEntity(offerInsertDTO, entity);
            _dbContext.Offers.Add(entity);
            return new OfferDTO(entity);
        }

        

        public OfferDTO Update(OfferInsertDTO offerInsertDTO, int id)
        {
            Offer entity = _dbContext.Offers
               .Include(o => o.Course)
               .AsNoTracking()
               .FirstOrDefault(o => o.Id == id) ?? throw new ArgumentException("Resource not found");
            copyDTOToEntity(offerInsertDTO, entity);
            return new OfferDTO(entity);
        }

        public bool Delete(int id)
        {
            Offer entity = _dbContext.Offers
                 .AsNoTracking()
                 .FirstOrDefault(o => o.Id == id) ?? throw new ArgumentException("Resource not found");
            _dbContext.Offers.Remove(entity);
            return true;
        }

        private void copyDTOToEntity(OfferInsertDTO offerInsertDTO, Offer entity)
        {
            entity.Edition = offerInsertDTO.Edition;
            entity.StartMoment = offerInsertDTO.StartMoment;
            entity.EndMoment = offerInsertDTO.EndMoment;

            Course course =  _dbContext.Courses.Find(offerInsertDTO.CourseId);

            entity.CourseId = course.Id;
        }
    }
}