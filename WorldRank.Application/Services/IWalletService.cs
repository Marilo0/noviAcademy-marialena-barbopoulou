using WorldRank.Application.Strategies;
using WorldRank.Domain.Entities;
using WorldRank.Domain.Enums;

namespace WorldRank.Application.Services;

public interface IWalletService
{
    Task<Wallet> CreateWalletAsync(int playerId, Currency currency, CancellationToken cancellationToken = default);
    Task<Wallet?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Wallet>> GetByPlayerAsync(int playerId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Wallet>> GetAllAsync(CancellationToken cancellationToken = default);

    // Applies a strategy to an already-fetched wallet and persists the change.
    Task ApplyFundsAsync(Wallet wallet, decimal amount, IFundsStrategy strategy, CancellationToken cancellationToken = default);

    // Deposit by id — fetches, deposits, and persists. Returns null if the wallet does not exist.
    Task<Wallet?> DepositAsync(int walletId, decimal amount, CancellationToken cancellationToken = default);

    // Toggles the block flag on an already-fetched wallet and persists the change.
    Task SetBlockedAsync(Wallet wallet, bool blocked, CancellationToken cancellationToken = default);
}
