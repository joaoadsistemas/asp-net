using DSCommerce.Entities;

namespace DSCommerce.Dto
{
    public class CategoryInsertDTO
    {
        public string Name { get; set; }

        public CategoryInsertDTO()
        {

        }

        public CategoryInsertDTO(Category entity)
        {
            this.Name = entity.name;
        }
    }
}
