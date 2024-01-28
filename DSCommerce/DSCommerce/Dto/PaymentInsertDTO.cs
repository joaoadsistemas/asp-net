using DSCommerce.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSCommerce.Dto
{
    public class PaymentInsertDTO
    {

        public DateTime Moment { get; set; }
        public long OrderId { get; set; }


        public PaymentInsertDTO() { }

        public PaymentInsertDTO(Payment entity)
        {
            this.Moment = entity.Moment;
            this.OrderId = entity.OrderId;
        }

    }
}