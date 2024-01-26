using DSCommerce.Dto;
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

        public Task<List<PaymentDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDTO> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDTO> Insert(PaymentDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDTO> Update(PaymentDTO dto, long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
