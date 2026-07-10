using WorldRank.Domain.Entities.Wallets;

namespace WorldRank.Application.Strategies
{
    internal class SubtractFundsStrategy : IFundsStrategy
    {
        public FundsOperation Operation => FundsOperation.Subtract;

        public void Execute(Wallet wallet, decimal amount) => wallet.Withdraw(amount);

    }
}
