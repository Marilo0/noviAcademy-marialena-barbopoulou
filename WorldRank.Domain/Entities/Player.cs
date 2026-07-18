namespace WorldRank.Domain.Entities;

public class Player : IPlayer
{
    public int Id { get; private set;}
    public string Name { get; }
    public int Score { get; private set; }

    public Player(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        //Id = id;
        Name = name;
        Score = 0;
    }

    private Player()
    {
        Name = string.Empty;
    }

    public void UpdateScore(int newScore)
    {
        if (newScore < 0)
            throw new ArgumentOutOfRangeException(nameof(newScore), "Score cannot be negative.");

        Score = newScore;
    }

    public override string ToString() => $"[{Id}] {Name} - Score: {Score}";
}
