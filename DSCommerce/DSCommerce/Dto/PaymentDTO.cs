using DSCommerce.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSCommerce.Dto
{
    public class PaymentDTO
    {

        public long Id { get; set; }
        public DateTime Moment { get; set; }
        public long OrderId { get; set; }


        public PaymentDTO() { }

        public PaymentDTO(Payment entity)
        {
            this.Id = entity.Id;
            this.Moment = entity.Moment;
            this.OrderId = entity.OrderId;
        }

    }
}