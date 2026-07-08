using WorldRank.Exceptions;
using WorldRank.Interfaces;

namespace WorldRank.Console
{
    public class InMemoryWalletRepository : IWalletRepository
    {
        private List<Player> _players;

        public InMemoryWalletRepository(List<Player> players)
        {
            _players = players;
        }

        public void Add(Wallet wallet, int playerId)
        {
            var player = _players.Where(item => item.Id == playerId).SingleOrDefault();

            if (player != null)
            {
                if (player.Wallets.ContainsKey(wallet.Currency))
                    throw new WalletException("Player already has a wallet in this currency.");

                player.Wallets.Add(wallet.Currency, wallet);
            }
        }

        public List<Wallet> GetByPlayer(int playerId)
        {
            var wallets = _players.Where(item => item.Id == playerId).SelectMany(item => item.Wallets.Values);
            return wallets.ToList();
        }
    }
}