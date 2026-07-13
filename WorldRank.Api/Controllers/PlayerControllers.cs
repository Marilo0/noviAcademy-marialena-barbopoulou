using Microsoft.AspNetCore.Mvc;
using WorldRank.Application.Interfaces;
using WorldRank.Domain.Entities;

namespace WorldRank.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PlayerControllers : ControllerBase
    {
        private readonly IPlayerRepository _PlayerRepository;

        public PlayerControllers(IPlayerRepository playerRepository)
        {
            _PlayerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = _PlayerRepository.GetAllPlayers().ToList();
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("[playerId]")]
        public async Task<ActionResult<Player>> GetById(int playerId)
        {
            try
            {
                var result = _PlayerRepository.FindPlayer(playerId);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
