using DSCommerce.Dto;

namespace DSCommerce.Repositories
{
    public interface PaymentRepository
    {
        Task<List<PaymentDTO>> FindAll();
        Task<PaymentDTO> FindById(long id);
        Task<PaymentInsertDTO> Insert(PaymentInsertDTO dto);
        Task<PaymentDTO> Update(PaymentInsertDTO dto, long id);
        Task<bool> DeleteById(long id);
    }
}
