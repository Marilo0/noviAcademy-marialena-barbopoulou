using WorldRank.Domain.Entities.Wallets;

namespace WorldRank.Application.Strategies
{
    internal class ForceSubtractFundsStrategy : IFundsStrategy
    {
        public FundsOperation Operation => FundsOperation.ForceSubtract;

        public void Execute(Wallet wallet, decimal amount) => wallet.ForceSubtractFunds(amount);
    }
}
