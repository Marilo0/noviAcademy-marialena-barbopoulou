using Microsoft.AspNetCore.Mvc;
using WorldRank.Application.Services;
using WorldRank.Domain.Exceptions;
using WorldRank.API.Dtos;

namespace WorldRank.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WalletsController : ControllerBase
{
    private readonly IWalletService _wallets;

    public WalletsController(IWalletService wallets) => _wallets = wallets;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWalletRequest request, CancellationToken cancellationToken)
    {
        var wallet = await _wallets.CreateWalletAsync(request.PlayerId, request.Currency, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = wallet.Id }, WalletResponse.From(wallet));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var wallet = await _wallets.GetByIdAsync(id, cancellationToken);
        return wallet is null ? NotFound() : Ok(WalletResponse.From(wallet));
    }

    [HttpPost("{id:int}/deposit")]
    public async Task<IActionResult> Deposit(int id, [FromBody] DepositRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var wallet = await _wallets.DepositAsync(id, request.Amount, cancellationToken);
            return wallet is null ? NotFound() : Ok(WalletResponse.From(wallet));
        }
        catch (WalletException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
