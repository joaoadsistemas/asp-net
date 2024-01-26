using DSCommerce.Dto;

namespace DSCommerce.Repositories
{
    public interface ProductRepository
    {
        Task<List<ProductDTO>> FindAll();
        Task<ProductDTO> FindById(long id);
        Task<ProductDTO> Insert(ProductDTO dto);
        Task<ProductDTO> Update(ProductDTO dto, long id);
        Task<bool> DeleteById(long id);
    }
}
