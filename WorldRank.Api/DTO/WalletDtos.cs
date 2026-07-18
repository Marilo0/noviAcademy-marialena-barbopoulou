using WorldRank.Domain.Entities;
using WorldRank.Domain.Enums;

namespace WorldRank.API.Dtos;
public record CreateWalletRequest(int PlayerId, Currency Currency);
public record DepositRequest(decimal Amount);
public record WalletResponse(int Id, int PlayerId, string Currency, decimal Balance, bool IsBlocked)
{
    public static WalletResponse From(Wallet wallet) =>
        new(wallet.Id, wallet.PlayerId, wallet.Currency.ToString(), wallet.Balance, wallet.IsBlocked);
}
