using System.Runtime.InteropServices;
using DSCommerce.Entities;

namespace DSCommerce.Dto
{
    public class OrderItemDTO
    {

        public long productId { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public string imgUrl { get; set; }


        public OrderItemDTO(OrderItem entity)
        {
            this.productId = entity.ProductId;
            this.name = entity.Product?.Name;
            this.price = entity.Price;
            this.quantity = entity.Quantity;
            this.imgUrl = entity.Product?.imgUrl;

        }

    }
}
