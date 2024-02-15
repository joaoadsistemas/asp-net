using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using System.Threading.Tasks;

namespace DSLearn.Interfaces
{
    public interface IDeliverRepository
    {
        Task<IEnumerable<DeliverDTO>> FindAllAsync(PageQueryParams pageQueryParams);
        Task<DeliverDTO> FindByIdAsync(int id);
        DeliverDTO Insert(DeliverInsertDTO deliverInsertDTO);
        DeliverDTO Update(DeliverInsertDTO deliverInsertDTO, int id);
        bool Delete(int id);
    }
}
