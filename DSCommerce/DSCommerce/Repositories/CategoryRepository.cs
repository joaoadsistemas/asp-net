using DSCommerce.Dto;

namespace DSCommerce.Repositories
{
    public interface CategoryRepository
    {

        Task<List<CategoryDTO>> FindAll();
        Task<CategoryDTO> FindById(long id);
        Task<CategoryDTO> Insert(CategoryDTO dto);
        Task<CategoryDTO> Update(CategoryDTO dto, long id);
        Task<bool> DeleteById(long id);

    }
}
