namespace WorldRank.Domain.Exceptions;

public class InsufficientFundsException : WalletException
{
    public decimal Requested { get; }
    public decimal Available { get; }
    public decimal Shortfall => Requested - Available;

    public InsufficientFundsException(decimal requested, decimal available)
        : base($"Insufficient funds: requested {requested:0.00}, available {available:0.00}, short by {requested - available:0.00}.")
    {
        Requested = requested;
        Available = available;
    }
    public InsufficientFundsException(decimal balance)
    : base($"Balance cannot be negative. Provided balance: {balance:0.00}.")
    {
        Requested = balance;
        Available = 0;
    }
}
