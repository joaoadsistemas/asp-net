using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using DSLearn.Interfaces;
using DSLearn.Repositories.db;
using Microsoft.EntityFrameworkCore;

namespace DSLearn.Services
{
    public class TopicService : ITopicRepository
    {

        private readonly SystemDbContext _dbContext;

        public TopicService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TopicDTO>> FindAllAsync(PageQueryParams pageQueryParams)
        {
            IEnumerable<Topic> contents = await _dbContext.Topics
                .Include(t => t.Likes)
                .Include(t => t.Answer)
                .Include(t => t.Replies)
                .Where(t => t.Title.Contains(pageQueryParams.Name))
                .OrderBy(t => t.Title)
                .Skip((pageQueryParams.PageNumber - 1) * pageQueryParams.PageSize)
                .Take(pageQueryParams.PageSize)
                .AsNoTracking()
                .ToListAsync();

            return contents.Select(t => new TopicDTO(t));
        }

        public async Task<TopicDTO> FindByIdAsync(int id)
        {
            Topic entity = await _dbContext.Topics
               .Include(t => t.Likes)
               .Include(t => t.Answer)
               .Include(t => t.Replies)
               .AsNoTracking().FirstOrDefaultAsync(c => c.Id == id) ?? throw new ArgumentException("Resource not found");


            return new TopicDTO(entity);
        }

        public TopicDTO Insert(TopicInsertDTO topicInsertDTO)
        {
            Topic entity = new Topic();
            copyDTOToEntity(topicInsertDTO, entity);
            _dbContext.Topics.Add(entity);
            return new TopicDTO(entity);
        }


        public TopicDTO Update(TopicInsertDTO topicInsertDTO, int id)
        {
            Topic entity = _dbContext.Topics
               .Include(t => t.Likes)
               .Include(t => t.Answer)
               .Include(t => t.Replies)
               .FirstOrDefault(c => c.Id == id) ?? throw new ArgumentException("Resource not found");
            copyDTOToEntity(topicInsertDTO, entity);
            return new TopicDTO(entity);
        }

        public bool Delete(int id)
        {
            Topic entity = _dbContext.Topics
               .Include(t => t.Likes)
               .Include(t => t.Answer)
               .Include(t => t.Replies)
               .FirstOrDefault(c => c.Id == id) ?? throw new ArgumentException("Resource not found");
            _dbContext.Topics.Remove(entity);
            return true;
        }


        private void copyDTOToEntity(TopicInsertDTO topicInsertDTO, Topic entity)
        {
            entity.Title = topicInsertDTO.Title;
            entity.Body = topicInsertDTO.Body;
            entity.Moment = topicInsertDTO.Moment;

            User author = _dbContext.Users.Find(topicInsertDTO.AuthorId);
            entity.AuthorId = author.Id;

            Lesson lesson = _dbContext.Lessons.Find(topicInsertDTO.LessonId);
            entity.LessonId = lesson.Id;

            Offer offer = _dbContext.Offers.Find(topicInsertDTO.OfferId);
            entity.OfferId = offer.Id;
        }
    }
}
