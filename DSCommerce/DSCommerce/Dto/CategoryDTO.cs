using DSCommerce.Entities;

namespace DSCommerce.Dto
{
    public class CategoryDTO
    {


        public long Id { get; set; }
        public string Name { get; set; }

        public CategoryDTO(Category entity)
        {
            this.Id = entity.Id;
            this.Name = entity.name;
        }

    }
}
