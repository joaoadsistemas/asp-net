using DSCommerce.Dto;
using DSCommerce.Entities;
using DSCommerce.Entities.enums;
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
            List<Order> orders = _dbContext.Orders
                .Include(o => o.Payment)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToList();
            return orders.AsEnumerable().Select(o => new OrderDTO(o)).ToList();

        }

        public async Task<OrderDTO> FindById(long id)
        {
            Order entity = _dbContext.Orders
                               .Include(o => o.Payment)
                               .Include(o => o.Items)
                               .ThenInclude(i => i.Product)
                         .SingleOrDefault()
                           ?? throw new Exception("Resource not found");
            return new OrderDTO(entity);
        }

        public async Task<OrderDTO> Insert(OrderSimpleDTO dto)
        {
            Order entity = new Order();
            copyDtoToEntity(dto, entity);
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return new OrderDTO(entity);

        }


        public async Task<OrderDTO> Update(OrderSimpleDTO dto, long id)
        {
            Order entity = _dbContext.Orders.Find(id) ?? throw new Exception("Resource not found");
            copyDtoToEntity(dto, entity);
            _dbContext.SaveChanges();
            return new OrderDTO(entity);
        }

        public async Task<bool> DeleteById(long id)
        {
            Order entity = _dbContext.Orders.Find(id) ?? throw new Exception("Resource not found");
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        private void copyDtoToEntity(OrderSimpleDTO dto, Order entity)
        {
            entity.userId = dto.userId;
            entity.moment = DateTime.Now;
            entity.status = OrderStatus.WAITING_PAYMENT;

            foreach (ProductIdAndQuantity itemDto in dto.items)
            {
                Product product = _dbContext.Products.Find(itemDto.productId);
                OrderItem item = new OrderItem(entity, product, itemDto.quantity, product.Price);
                entity.Items.Add(item);
            }
        }
    }
}
