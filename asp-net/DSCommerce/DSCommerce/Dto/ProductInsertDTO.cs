using DSCommerce.Entities;

namespace DSCommerce.Dto
{
    public class ProductInsertDTO
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string imgUrl { get; set; }

        public List<long> CategoriesIds { get; set; } = new List<long>();


        public ProductInsertDTO()
        {

        }


        public ProductInsertDTO(Product entity)
        {
            this.Name = entity.Name;
            this.Description = entity.Description;
            this.Price = entity.Price;
            this.imgUrl = entity.imgUrl;

            foreach (Category category in entity.Categories)
            {
                CategoriesIds.Add(category.Id);
            }

        }

    }
}
