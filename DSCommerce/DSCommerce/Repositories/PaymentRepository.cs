using DSCommerce.Dto;

namespace DSCommerce.Repositories
{
    public interface PaymentRepository
    {
        Task<List<PaymentDTO>> FindAll();
        Task<PaymentDTO> FindById(long id);
        Task<PaymentDTO> Insert(PaymentDTO dto);
        Task<PaymentDTO> Update(PaymentDTO dto, long id);
        Task<bool> DeleteById(long id);
    }
}
