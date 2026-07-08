using WorldRank.Enums;
using WorldRank.Exceptions;
using WorldRank.Interfaces;

namespace WorldRank;

public class Player : IPlayer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public Dictionary<Currency, Wallet> Wallets { get; set; } = new ();

    public Player(int id, string name, int score)
    {
        Name = name;
        Id = id;
        Score = score;
    }

    public void UpdateScore(int newScore)
    {
        if (newScore < 0)
            throw new NegativeScoreException();

        Score = newScore;
    }

    public override string ToString()
    {
        return $"[{Id}] {Name} - Score: {Score}";
    }
}