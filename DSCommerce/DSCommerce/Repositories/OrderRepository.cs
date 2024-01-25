using DSCommerce.Dto;

namespace DSCommerce.Repositories
{
    public interface OrderRepository
    {
        Task<List<OrderDTO>> FindAll();
        Task<OrderDTO> FindById(long id);
        Task<OrderDTO> Insert(OrderDTO dto);
        Task<OrderDTO> Update(OrderDTO dto, long id);
        Task<bool> DeleteById(long id);
    }
}
