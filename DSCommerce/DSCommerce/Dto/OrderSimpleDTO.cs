using DSCommerce.Entities.enums;

namespace DSCommerce.Dto
{
    public class OrderSimpleDTO
    {
        public long userId { get; set; }
        public List<ProductIdAndQuantity> items { get; set; } = new List<ProductIdAndQuantity>();


    }

    public class ProductIdAndQuantity
    {
        public long productId { get; set; }
        public int quantity { get; set; }
    }
}
