using DSCommerce.Dto;

namespace DSCommerce.Repositories
{
    public interface ProductRepository
    {
        Task<List<ProductDTO>> FindAll();
        Task<ProductDTO> FindById(long id);
        Task<ProductInsertDTO> Insert(ProductInsertDTO dto);
        Task<ProductDTO> Update(ProductInsertDTO dto, long id);
        Task<bool> DeleteById(long id);
    }
}
