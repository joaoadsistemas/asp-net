using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using System.Threading.Tasks;

namespace DSLearn.Interfaces
{
    public interface IOfferRepository
    {
        Task<IEnumerable<OfferDTO>> FindAllAsync(PageQueryParams pageQueryParams);
        Task<OfferDTO> FindByIdAsync(int id);
        Task<OfferDTO> InsertUserToOffer(OfferUserInsertDTO offerUserInsertDTO);
        OfferDTO Insert(OfferInsertDTO offerInsertDTO);
        OfferDTO Update(OfferInsertDTO offerInsertDTO, int id);
        bool Delete(int id);
    }
}
