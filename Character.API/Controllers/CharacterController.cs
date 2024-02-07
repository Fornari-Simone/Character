using Character.Business.Abstraction;
using Character.Repository.Model;
using Character.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Character.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CharacterController : ControllerBase
    {
        private readonly IBusiness _business;

        private readonly ILogger<CharacterController> _logger;

        public CharacterController(IBusiness business, ILogger<CharacterController> logger)
        {
            _business = business;
            _logger = logger;
        }
        [HttpPost(Name = "AddCharacter")]
        public async Task<ActionResult> AddCharacter(CharacterDTO characterDTO, CancellationToken cancellation = default)
        {
            await _business.AddCharacter(characterDTO, cancellation);
            return Ok("Done!!");
        }
        [HttpGet(Name = "GetCharacter")]
        public async Task<ActionResult<CharacterDTO?>> GetCharacter(int ID, CancellationToken cancellation = default)
        {
            CharacterDTO? characterDTO = await _business.GetCharacter(ID, cancellation);
            return new JsonResult(characterDTO);
        }
        [HttpDelete(Name = "RemoveCharacter")]
        public async Task<ActionResult> RemoveCharacter(int ID, CancellationToken cancellation = default)
        {
            await _business.RemoveCharacter(ID, cancellation);
            return Ok("Done!!");
        }
        [HttpPatch(Name = "Ascend")]
        public async Task Ascend(int ID, CancellationToken cancellation = default)
        {
            await _business.Ascend(ID, cancellation);
        }
        [HttpPatch(Name = "LevelUP")]
        public async Task LevelUP(int ID, int level, CancellationToken cancellation = default)
        {
            await _business.LevelUP(ID, level, cancellation);
        }
    }
}
