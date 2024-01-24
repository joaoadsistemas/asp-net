
using DSCommerce.Entities;
using DSCommerce.Entities.enums;

namespace DSCommerce.Dto
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public DateTime moment { get; set; }
        public OrderStatus status { get; set; }


        public long userId { get; set; }


        public OrderDTO()
        {

        }

        public OrderDTO(long id, DateTime moment, OrderStatus status, long userId)
        {
            this.Id = id;
            this.moment = moment;
            this.status = status;
            this.userId = userId;
        }

        public OrderDTO(Order entity)
        {
            this.Id = entity.Id;
            this.moment = entity.moment;
            this.status = entity.status;
            this.userId = entity.userId;
        }


    }
}
