using System.ComponentModel.DataAnnotations.Schema;
using DSCommerce.Entities;

namespace DSCommerce.Dto
{
    public class ProductDTO
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string imgUrl { get; set; }


        public ProductDTO(Product entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Description = entity.Description;
            this.Price = entity.Price;
            this.imgUrl = entity.imgUrl;
        }

    }
}
