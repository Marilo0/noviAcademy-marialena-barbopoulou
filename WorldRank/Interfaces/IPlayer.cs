using WorldRank.Enums;

namespace WorldRank.Interfaces
{
    public interface IPlayer
    {
        int Id { get; set; }
        string Name { get; set; }
        int Score { get; set; }
        Dictionary<Currency, Wallet> Wallets { get; set; }
    }
}