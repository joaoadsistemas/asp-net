using DSCommerce.Dto;
using DSCommerce.Entities;
using DSCommerce.Repositories;
using DSCommerce.Repositories.db;
using Microsoft.EntityFrameworkCore;

namespace DSCommerce.Services
{
    public class OrderService : OrderRepository
    {

        private readonly SystemDbContext _dbContext;

        public OrderService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrderDTO>> FindAll()
        {
            List<Order> orders = _dbContext.Orders.Include(o => o.Payment).ToList();
            return orders.AsEnumerable().Select(o => new OrderDTO(o)).ToList();

        }

        public async Task<OrderDTO> FindById(long id)
        {
            Order entity = _dbContext.Orders.Include(o => o.Payment).SingleOrDefault()
                           ?? throw new Exception("Resource not found");
            return new OrderDTO(entity);
        }

        public async Task<OrderDTO> Insert(OrderDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDTO> Update(OrderDTO dto, long id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
