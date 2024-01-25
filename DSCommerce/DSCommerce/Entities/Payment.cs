using System.ComponentModel.DataAnnotations.Schema;

namespace DSCommerce.Entities
{

    [Table("tb_payment")]
    public class Payment
    {

        public long Id { get; set; }
        public DateTime Moment { get; set; }

        [Column("order_id")]
        public long OrderId { get; set; }
        public Order Order { get; set; }


    }
}
