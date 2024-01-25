using DSCommerce.Dto;
using DSCommerce.Repositories;

namespace DSCommerce.Services
{
    public class OrderService : OrderRepository
    {
        public Task<List<OrderDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> Insert(OrderDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> Update(OrderDTO dto, long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
