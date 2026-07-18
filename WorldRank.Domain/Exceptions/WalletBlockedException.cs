namespace WorldRank.Domain.Exceptions;

// Raised when a fund operation is attempted on a blocked wallet.
public class WalletBlockedException : WalletException
{
    public int WalletId { get; }

    public WalletBlockedException(int walletId)
        : base($"Wallet {walletId} is blocked and cannot accept fund operations.")
    {
        WalletId = walletId;
    }
}
