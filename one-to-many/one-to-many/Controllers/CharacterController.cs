using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using one_to_many.Dto;
using one_to_many.Repositories;
using one_to_many.Repositories.db;

namespace one_to_many.Controllers
{
    [Route("/characters")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterRepository _repository;
        public CharacterController(CharacterRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CharacterDTO>>> FindAll()
        {
            return Ok(_repository.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> FindById(int id)
        {
            return Ok(_repository.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<CharacterDTO>> InsertCharacter([FromBody] CharacterDTO dto)
        {
            dto = await _repository.Insert(dto);
            return CreatedAtAction(nameof(FindById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CharacterDTO>> UpdateCharacter([FromBody] CharacterDTO dto, int id)
        {
            return Ok(_repository.Update(dto, id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteById(int id)
        {
            await _repository.DeleteById(id);
            return NoContent();
        }

    }
}
