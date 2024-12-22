// See https://aka.ms/new-console-template for more information

public class Player
{
    
    public string Name { get; set; }
    public string Position { get; set; }
    public int Score { get; set; }

    public Player(string name, string position, int score)
    {
        Name = name;
        Position = position;
        Score = score;
    }

    
    public void UpdateScore(int newScore)
    {
        Score = newScore;
    }
}

public class Team
{
    private List<Player> players = new List<Player>();


    public void AddPlayer(Player player)
    {
        players.Add(player);
        Console.WriteLine($"Dodano zawodnika: {player.Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
    }
    public void RemovePlayer(string playerName)
    {
            Player playerToRemove = null;

            
            foreach (var player in players)
            {
                if (player.Name == playerName)
                {
                    playerToRemove = player;
                    break;
                }
            }

            
            if (playerToRemove != null)
            {
                players.Remove(playerToRemove);
                Console.WriteLine($"Usunięto zawodnika: {playerName}");
            }
            else
            {
                Console.WriteLine("Zawodnik nie istnieje w drużynie.");
            }
            }
}