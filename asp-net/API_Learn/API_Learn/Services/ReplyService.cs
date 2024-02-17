using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using DSLearn.Interfaces;
using DSLearn.Repositories.db;
using Microsoft.EntityFrameworkCore;

namespace DSLearn.Services
{
    public class ReplyService : IReplyRepository
    {

        public readonly SystemDbContext _dbContext;

        public ReplyService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReplyDTO>> FindAllAsync(PageQueryParams pageQueryParams)
        {
            IEnumerable<Reply> contents = await _dbContext.Replys
                .Include(r => r.AuthorId)
                .Include(r => r.Likes)
                .Where(r => r.Body.Contains(pageQueryParams.Name))
                .OrderBy(r => r.Body)
                .Skip((pageQueryParams.PageNumber - 1) * pageQueryParams.PageSize)
                .Take(pageQueryParams.PageSize)
                .AsNoTracking()
                .ToListAsync();

            return contents.Select(r => new ReplyDTO(r));
        }

        public async Task<ReplyDTO> FindByIdAsync(int id)
        {
            Reply entity = await _dbContext.Replys
                .Include(r => r.AuthorId)
                .Include(t => t.Likes)
                .AsNoTracking().FirstOrDefaultAsync(c => c.Id == id) ?? throw new ArgumentException("Resource not found");


            return new ReplyDTO(entity);
        }

        public ReplyDTO Insert(ReplyInsertDTO replyInsertDto)
        {
            Reply entity = new Reply();
            copyDTOToEntity(replyInsertDto, entity);
            _dbContext.Replys.Add(entity);
            return new ReplyDTO(entity);
        }


        public ReplyDTO Update(ReplyInsertDTO replyInsertDto, int id)
        {
            Reply entity = _dbContext.Replys
                .Include(r => r.Likes)
                .FirstOrDefault(r => r.Id == id) ?? throw new ArgumentException("Resource not found");
            copyDTOToEntity(replyInsertDto, entity);
            return new ReplyDTO(entity);
        }

        public bool Delete(int id)
        {
            Reply entity = _dbContext.Replys
                .Include(r => r.Likes)
                .FirstOrDefault(r => r.Id == id) ?? throw new ArgumentException("Resource not found");
            _dbContext.Replys.Remove(entity);
            return true;
        }

        private void copyDTOToEntity(ReplyInsertDTO replyInsertDto, Reply entity)
        {
            entity.Body = replyInsertDto.Body;
            entity.Moment = replyInsertDto.Moment;

            Topic topic = _dbContext.Topics.Find(replyInsertDto.TopicId);

            entity.TopicId = topic.Id;

            User user = _dbContext.Users.Find(replyInsertDto.AuthorId);

            entity.AuthorId = user.Id;
        }
    }
}
