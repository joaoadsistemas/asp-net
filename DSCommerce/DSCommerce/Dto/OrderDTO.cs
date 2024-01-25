
using DSCommerce.Entities;
using DSCommerce.Entities.enums;

namespace DSCommerce.Dto
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public DateTime moment { get; set; }
        public OrderStatus status { get; set; }
        public PaymentDTO? payment { get; set; }


        public long userId { get; set; }


        public OrderDTO()
        {

        }

        public OrderDTO(Order entity)
        {
            this.Id = entity.Id;
            this.moment = entity.moment;
            this.status = entity.status;
            this.userId = entity.userId;
            this.payment = entity.Payment != null ? new PaymentDTO(entity.Payment) : null;
        }


    }
}
