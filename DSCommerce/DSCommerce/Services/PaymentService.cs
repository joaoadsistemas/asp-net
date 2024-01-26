using DSCommerce.Dto;
using DSCommerce.Entities;
using DSCommerce.Repositories;
using DSCommerce.Repositories.db;

namespace DSCommerce.Services
{
    public class PaymentService : PaymentRepository
    {

        private readonly SystemDbContext _dbContext;

        public PaymentService(SystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PaymentDTO>> FindAll()
        {
            List<Payment> payments = _dbContext.Payments.ToList();
            return payments.AsEnumerable().Select(p => new PaymentDTO(p)).ToList();
        }

        public async Task<PaymentDTO> FindById(long id)
        {
            Payment entity = await _dbContext.Payments.FindAsync(id) ?? throw new Exception("Resource not found");
            return new PaymentDTO(entity);
        }

        public async Task<PaymentDTO> Insert(PaymentDTO dto)
        {
            Payment entity = new Payment();
            copyDtoToEntity(dto, entity);
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return new PaymentDTO(entity);
        }

        public async Task<PaymentDTO> Update(PaymentDTO dto, long id)
        {
            Payment entity = await _dbContext.Payments.FindAsync(id) ?? throw new Exception("Resource not found");
            copyDtoToEntity(dto,entity);
            _dbContext.SaveChanges();
            return new PaymentDTO(entity);
        }

        public async Task<bool> DeleteById(long id)
        {
            Payment entity = await _dbContext.Payments.FindAsync(id) ?? throw new Exception("Resource not found");
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }


        private void copyDtoToEntity(PaymentDTO dto, Payment entity)
        {

            entity.Id = dto.Id;
            entity.OrderId = dto.OrderId;
            entity.Moment = dto.Moment;

        }
    }
}
