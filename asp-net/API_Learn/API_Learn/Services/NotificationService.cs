using ApiCatalogo.Pagination;
using AutoMapper;
using DSLearn.Dtos;
using DSLearn.Entities;
using DSLearn.Interfaces;
using DSLearn.Repositories.db;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Repositories
{
    internal class NotificationService : INotificationRepository
    {

        private readonly SystemDbContext _dbContext;
        private readonly IMapper _mapper;

        public NotificationService(SystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NotificationDTO>> FindAllAsync(PageQueryParams pageQueryParams)
        {
            IEnumerable<Notification> result = await _dbContext.Notifications.Include(n => n.User)
             .Where(n => n.Text.Contains(pageQueryParams.Name))
            .OrderBy(n => n.Moment)
            .Skip((pageQueryParams.PageNumber - 1) * pageQueryParams.PageSize)
            .Take(pageQueryParams.PageSize)
            .AsNoTracking().ToListAsync();


            return result.AsEnumerable().Select(n => new NotificationDTO(n));
        }

        public async Task<NotificationDTO> FindByIdAsync(int id)
        {
            Notification result = await _dbContext.Notifications
                .AsNoTracking()
                .Include(n => n.User)
                .FirstOrDefaultAsync(n => n.Id == id) ?? throw new ArgumentException("Resource not found");

            return new NotificationDTO(result);
        }

        public NotificationDTO Insert(NotificationInsertDTO notificationInsertDTO)
        {
            Notification entity = new Notification();
            copyDTOToEntity(notificationInsertDTO, entity);
            _dbContext.Notifications.Add(entity);
            return new NotificationDTO(entity);
        }


        public NotificationDTO Update(NotificationInsertDTO notificationInsertDTO, int id)
        {
            Notification entity = _dbContext.Notifications
                .AsNoTracking()
                .Include(n => n.User)
                .FirstOrDefault(n => n.Id == id) ?? throw new ArgumentException("Resource not found");
            copyDTOToEntity(notificationInsertDTO, entity);
            return new NotificationDTO(entity);
        }


        public bool Delete(int id)
        {
            Notification entity = _dbContext.Notifications
                .AsNoTracking()
                .Include(n => n.User)
                .FirstOrDefault(n => n.Id == id) ?? throw new ArgumentException("Resource not found");
            _dbContext.Notifications.Remove(entity);
            return true;
        }

        private void copyDTOToEntity(NotificationInsertDTO notificationInsertDTO, Notification entity)
        {
            entity.Text = notificationInsertDTO.Text;
            entity.Moment = notificationInsertDTO.Moment;
            entity.Read = notificationInsertDTO.Read;
            entity.Route = notificationInsertDTO.Route;
            entity.User = _dbContext.Users.Find(notificationInsertDTO.UserId) ?? throw new ArgumentException("Resource not found");
        }

    }
}