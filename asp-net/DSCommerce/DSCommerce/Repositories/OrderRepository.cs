using DSCommerce.Dto;

namespace DSCommerce.Repositories
{
    public interface OrderRepository
    {
        Task<List<OrderDTO>> FindAll();
        Task<OrderDTO> FindById(long id);
        Task<OrderDTO> Insert(OrderInsertDTO dto);
        Task<OrderDTO> Update(OrderInsertDTO dto, long id);
        Task<bool> DeleteById(long id);
    }
}
