using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using System.Threading.Tasks;

namespace DSLearn.Interfaces
{
    public interface ITopicRepository
    {
        Task<IEnumerable<TopicDTO>> FindAllAsync(PageQueryParams pageQueryParams);
        Task<TopicDTO> FindByIdAsync(int id);
        TopicDTO Insert(TopicInsertDTO topicInsertDTO);
        TopicDTO Update(TopicInsertDTO topicInsertDTO, int id);
        bool Delete(int id);
    }
}
