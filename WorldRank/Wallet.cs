using WorldRank.Enums;
using WorldRank.Exceptions;

namespace WorldRank
{
    public class Wallet
    {
        public decimal Balance { get; private set; }
        public Currency Currency { get; set; }
      
        public bool IsBlocked { get; set; }

        public Wallet(decimal balance, Currency currency, bool isBlocked)
        {
            Balance = balance;
            Currency = currency;
            IsBlocked = false;
        }

        public void SetBalance(decimal balance)
        {
            if (balance < 0)
                throw new InsufficientFundsException("Balance cannot become negative.");

            Balance = balance;
        }

        public override string ToString()
        {
            return "Balance -> " + Balance + " Currency ->" + Currency + " IsBlocked -> " + IsBlocked;
        }
    }
}
