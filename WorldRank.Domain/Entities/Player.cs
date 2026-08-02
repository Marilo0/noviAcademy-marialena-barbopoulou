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

    public static Player CreateNew(int id, string name, int score)
    {
        var p = new Player(name);
        p.Id = id;
        p.UpdateScore(score);
        return p;
    }

    public override string ToString() => $"[{Id}] {Name} - Score: {Score}";
}
