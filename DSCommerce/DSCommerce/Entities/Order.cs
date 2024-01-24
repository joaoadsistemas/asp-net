using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DSCommerce.Entities.enums;

namespace DSCommerce.Entities
{
    [Table("tb_order")]
    public class Order
    {

        [Key()]
        public long Id { get; set; }
        public DateTime moment { get; set; }
        public OrderStatus status { get; set; }

        [Column("user_id")]
        public long userId { get; set; }
        public User user { get; set; } 

        public Order() { }

        public Order(long id, DateTime moment, OrderStatus status, User user)
        {
            this.Id = id;
            this.moment = moment;
            this.status = status;
            this.user = user;
        }

    }
}
