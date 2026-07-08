namespace WorldRank.Exceptions;

public class InsufficientFundsException : WalletException
{
    public InsufficientFundsException()
        : base("Insufficient funds.")
    {
    }

    public InsufficientFundsException(string message)
        : base(message)
    {
    }

    public InsufficientFundsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}