using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using DSLearn.Dtos;
using DSLearn.Entities;
using System.Threading.Tasks;

namespace DSLearn.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<EnrollmentDTO>> FindAllAsync(PageQueryParams pageQueryParams);
        Task<IEnumerable<EnrollmentDTO>> FindBySelfEnrollmentAsync(string id);
        Task<EnrollmentDTO> FindByUserIdAsync(string id);
        Task<EnrollmentDTO> FindByOfferIdAsync(int id);
        EnrollmentDTO Insert(EnrollmentInsertDTO enrollmentInsertDTO);
        EnrollmentDTO Update(EnrollmentInsertDTO enrollmentInsertDTO, int id);
        bool Delete(int id);
    }
}
