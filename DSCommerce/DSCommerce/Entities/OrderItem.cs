using System.ComponentModel.DataAnnotations.Schema;

namespace DSCommerce.Entities
{
    [Table("order_item")]
    public class OrderItem
    {
        [Column("order_id")]
        public long OrderId { get; set; }
        public Order Order { get; set; }

        [Column("product_id")]
        public long ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        private double _price;

        [Column("price")]
        public double Price
        {
            get { return _price; }
            set { _price = Product?.Price * value ?? 0; }
        }
    }
}