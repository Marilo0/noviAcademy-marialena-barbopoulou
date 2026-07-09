using WorldRank.Domain.Entities.Wallets;

///<summary>
/// Strategy pattern: a family of algorithms behind one interface. Each concrete
/// strategy knows which operation it implements, so the caller 
///</summary>
namespace WorldRank.Application.Strategies
{
    public interface IFundsStrategy
    {
        void Execute(Wallet wallet, decimal amount);
    }
}
