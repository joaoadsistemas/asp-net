using DSCommerce.Dto;

namespace DSCommerce.Repositories
{
    public interface OrderRepository
    {
        Task<List<OrderDTO>> FindAll();
        Task<OrderDTO> FindById(int id);
        Task<OrderDTO> Insert(OrderDTO dto);
        Task<OrderDTO> Update(OrderDTO dto, int id);
        Task<bool> DeleteById(int id);
    }
}
