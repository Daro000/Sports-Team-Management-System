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
    public List<Player> players = new List<Player>();


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
    
    public void ShowTeamStats()
    {
        if (players.Count == 0)
        {
            Console.WriteLine("Drużyna nie ma zawodników.");
            return;
        }
        Console.WriteLine("Statystyki drużyny:");
        foreach (var player in players)
        {
            Console.WriteLine($"Zawodnik: {player.Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
        }
    }
    
    public static double CalculateAverageScore(List<Player> players)
    {
        if (players.Count == 0) return 0;
        double totalScore = 0;
        foreach (var player in players)
        {
            totalScore += player.Score;
        }
        return totalScore / players.Count;
    }
    
    public void SearchPlayersByPosition(string position)
    {
        bool found = false;
        foreach (var player in players)
        {
            if (player.Position.ToLower() == position.ToLower())
            {
                Console.WriteLine($"Zawodnik: {player.Name}, Wynik: {player.Score}");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine($"Brak zawodników na pozycji {position}.");
        }
    }

    public void FilterPlayersByScore(int minScore)
    {
        bool found = false;

        foreach (var player in players)
        {
            if (player.Score >= minScore)
            {
                Console.WriteLine($"Zawodnik: {player.Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Brak zawodników spełniających podane kryteria.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Team team = new Team();
        
        team.AddPlayer(new Player("Jan Kowalski", "Napastnik", 10));
        team.AddPlayer(new Player("Marek Nowak", "Obrońca", 5));
        team.AddPlayer(new Player("Paweł Zieliński", "Bramkarz", 0));
        
        team.ShowTeamStats();
        
        Console.WriteLine($"Średnia punktów drużyny: {Team.CalculateAverageScore(team.players)}");
        
        team.SearchPlayersByPosition("Napastnik");
        
        team.FilterPlayersByScore(5);
        
        var player = new Player("Andrzej Wiśniewski", "Pomocnik", 8);
        player.UpdateScore(12);
        team.AddPlayer(player); 
    }
}