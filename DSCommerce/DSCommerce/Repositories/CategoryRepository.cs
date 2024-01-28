using DSCommerce.Dto;

namespace DSCommerce.Repositories
{
    public interface CategoryRepository
    {

        Task<List<CategoryDTO>> FindAll();
        Task<CategoryDTO> FindById(long id);
        Task<CategoryInsertDTO> Insert(CategoryInsertDTO dto);
        Task<CategoryDTO> Update(CategoryInsertDTO dto, long id);
        Task<bool> DeleteById(long id);

    }
}
