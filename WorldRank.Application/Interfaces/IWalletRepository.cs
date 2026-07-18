using WorldRank.Domain.Entities;
using WorldRank.Domain.Enums;

namespace WorldRank.Application.Interfaces;

public interface IWalletRepository
{
    Task AddAsync(Wallet wallet, CancellationToken cancellationToken = default);
    Task<List<Wallet>> GetAllWalletsByPlayerIdAsync( int playerId,CancellationToken cancellationToken = default);
    Task<Wallet?> GetWalletByIdAsync(int walletId, CancellationToken cancellationToken = default);
    Task<Wallet?> GetWalletAsync( int playerId,Currency currency,CancellationToken cancellationToken = default);
    Task UpdateBalanceAsync(int playerId,Currency currency,decimal newBalance, CancellationToken cancellationToken = default);
    Task DepositAsync(int playerId,Currency currency,decimal amount,CancellationToken cancellationToken = default);
    Task WithdrawAsync( int playerId, Currency currency, decimal amount,CancellationToken cancellationToken = default);
    Task BlockAsync(  int playerId, Currency currency, CancellationToken cancellationToken = default);
    Task UnblockAsync( int playerId, Currency currency, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Wallet>> GetAllAsync(CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
