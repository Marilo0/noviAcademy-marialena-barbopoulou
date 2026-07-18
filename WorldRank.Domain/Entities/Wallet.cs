using WorldRank.Domain.Enums;
using WorldRank.Domain.Exceptions;

namespace WorldRank.Domain.Entities;

public class Wallet : IWallet
{
    public int Id { get; private set; }
    public int PlayerId { get; }
    public Currency Currency { get; }
    public decimal Balance { get; private set; }
    public bool IsBlocked { get; private set; }
    private Wallet()
    {
    }
    public Wallet(int playerId, Currency currency, bool isBlocked = false)
    {
      
        PlayerId = playerId;
        Currency = currency;
        IsBlocked = isBlocked;
    }
    
    public void SetBalance(decimal balance)
    {
        if (balance < 0)
            throw new InsufficientFundsException(balance);

        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        if (IsBlocked)
            throw new WalletBlockedException(Id);

        if (amount <= 0)
            throw new InvalidAmountException(amount);

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (IsBlocked)
            throw new WalletBlockedException(Id);

        if (amount <= 0)
            throw new InvalidAmountException(amount);

        if (amount > Balance)
            throw new InsufficientFundsException(amount, Balance);

        Balance -= amount;
    }

    public void ForceSubtractFunds(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidAmountException(amount);

        Balance -= amount;
    }

    public void Block() => IsBlocked = true;
    public void Unblock() => IsBlocked = false;

    public override string ToString() =>
        $"[{Id}] {Currency} {Balance:0.00}{(IsBlocked ? " (blocked)" : string.Empty)}";
}
