using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using System.Threading.Tasks;

namespace DSLearn.Interfaces
{
    public interface IReplyRepository
    {
        Task<IEnumerable<ReplyDTO>> FindAllAsync(PageQueryParams pageQueryParams);
        Task<ReplyDTO> FindByIdAsync(int id);
        ReplyDTO Insert(ReplyInsertDTO replyInsertDto);
        ReplyDTO Update(ReplyInsertDTO replyInsertDto, int id);
        bool Delete(int id);
    }
}
