using one_to_many.Dto;

namespace one_to_many.Repositories
{
    public interface CharacterRepository
    {
        Task<List<CharacterDTO>> FindAll();
        Task<CharacterDTO> FindById(int id);
        Task<CharacterDTO> Insert(CharacterDTO dto);
        Task<CharacterDTO> Update(CharacterDTO dto, int id);
        Task<bool> DeleteById(int id);

    }
}
