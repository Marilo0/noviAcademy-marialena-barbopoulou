using Microsoft.AspNetCore.Mvc;
using WorldRank.Application.Services;
using WorldRank.Domain.Entities;
using WorldRank.API.Dtos;

namespace WorldRank.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IPlayerService _players;

    public PlayersController(IPlayerService players)
    {
        _players = players;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePlayerRequest request, CancellationToken cancellationToken)
    {
        Player player;
        try
        {
            player = await _players.CreateAsync(request.Name, request.Score, cancellationToken);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }

        return CreatedAtAction(nameof(GetById), new { id = player.Id }, PlayerResponse.From(player));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var player = await _players.GetByIdAsync(id, cancellationToken);
        return player is null ? NotFound() : Ok(PlayerResponse.From(player));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var players = await _players.GetAllAsync(cancellationToken);
        return Ok(players.Select(PlayerResponse.From));
    }
}
