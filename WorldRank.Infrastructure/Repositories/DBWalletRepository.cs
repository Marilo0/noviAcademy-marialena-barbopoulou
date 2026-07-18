using Microsoft.EntityFrameworkCore;
using WorldRank.Application.Interfaces;
using WorldRank.Domain.Entities;
using WorldRank.Domain.Enums;
using WorldRank.Domain.Exceptions;
using WorldRank.Infrastructure.Persistence;

namespace WorldRank.Infrastructure.Repositories;

public class DbWalletRepository : IWalletRepository
{
    private readonly WorldRankDbContext _db;

    public DbWalletRepository(WorldRankDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync( Wallet wallet,CancellationToken cancellationToken = default)
    {
        var exists = await _db.Wallets.AnyAsync(
            item =>
                item.PlayerId == wallet.PlayerId &&
                item.Currency == wallet.Currency,
            cancellationToken);

        if (exists)
        {
            throw new DuplicateWalletException(wallet.PlayerId, wallet.Currency);
        }

        await _db.Wallets.AddAsync(wallet, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public Task<Wallet?> GetWalletByIdAsync(int walletId,CancellationToken cancellationToken = default)
    {
        return _db.Wallets.FirstOrDefaultAsync(wallet => wallet.Id == walletId, cancellationToken);
    }

    public async Task<List<Wallet>> GetAllWalletsByPlayerIdAsync(int playerId, CancellationToken cancellationToken = default)
    {
        return await _db.Wallets
            .AsNoTracking()
            .Where(wallet => wallet.PlayerId == playerId)
            .ToListAsync(cancellationToken);
    }

    public async Task<Wallet?> GetWalletAsync(int playerId,Currency currency,CancellationToken cancellationToken = default)
    {
        return await _db.Wallets
            .FirstOrDefaultAsync(wallet =>
            wallet.PlayerId == playerId &&
            wallet.Currency == currency, cancellationToken);
    }

    public async Task UpdateBalanceAsync(int playerId,Currency currency,decimal newBalance,CancellationToken cancellationToken = default)
    {
        var wallet = await GetRequiredWalletAsync(playerId,currency,cancellationToken);
        wallet.SetBalance(newBalance);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DepositAsync(int playerId,Currency currency,decimal amount,CancellationToken cancellationToken = default)
    {
        var wallet = await GetRequiredWalletAsync(playerId,currency,cancellationToken);
        wallet.Deposit(amount);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task WithdrawAsync(int playerId,Currency currency,decimal amount,CancellationToken cancellationToken = default)
    {
        var wallet = await GetRequiredWalletAsync(playerId,currency,cancellationToken);
        wallet.Withdraw(amount);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task BlockAsync(int playerId, Currency currency,CancellationToken cancellationToken = default)
    {
        var wallet = await GetRequiredWalletAsync( playerId,currency,cancellationToken);
        wallet.Block();
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UnblockAsync(
        int playerId,
        Currency currency,
        CancellationToken cancellationToken = default)
    {
        var wallet = await GetRequiredWalletAsync(
            playerId,
            currency,
            cancellationToken);

        wallet.Unblock();
        await _db.SaveChangesAsync(cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _db.SaveChangesAsync(cancellationToken);
    }

    private async Task<Wallet> GetRequiredWalletAsync( int playerId,Currency currency,CancellationToken cancellationToken)
    {
        var wallet = await _db.Wallets
            .FirstOrDefaultAsync(
                item =>
                    item.PlayerId == playerId &&
                    item.Currency == currency,
                cancellationToken);

        if (wallet is null)
        {
            throw new WalletNotFoundException(playerId,currency);
        }
        return wallet;
    }
    public async Task<IReadOnlyList<Wallet>> GetAllAsync(
    CancellationToken cancellationToken = default)
    {
        return await _db.Wallets
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}