using ConsoleMathGame.m_a_z_z_z.Model;

namespace ConsoleMathGame.m_a_z_z_z
{
	internal static class Helper
	{
		public static event Action OnReturnRequested;
		
		internal static string? ValidateUsername(string? username) 
		{			
			while (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username)) 
			{
				Console.Write("Enter a name, damn it!: ");
				username = Console.ReadLine();
				if (username.Length > 4) { username = username.Substring(0,4); }
			}	
			username.Trim();
			return username;
		}
		
		internal static string? ValidateNumber(string? userAnswer)
		{
			while (string.IsNullOrEmpty(userAnswer) || !Int32.TryParse(userAnswer, out int result)) {
				Console.Write("Invalid input. Please enter a number: ");
				userAnswer = Console.ReadLine();
			}
			userAnswer.Trim();
			return userAnswer;
		}

		internal static void AddScoreToLeaderboard(Game game)
		{
			DateTime now = DateTime.Now;
			game.Date = now;
			// Filter for games only in this gamemode
			var gamesToCompare = Helper.games.Where(x => x.Score > 0 && x.GameMode == game.GameMode)
			.OrderByDescending(x => x.Score)
			.ThenBy(x => x.Date)
			.Take(10)
			.ToList();
			
			// If it beats the lowest score (out of top 10), add score to leaderboard
			if (game.Score > gamesToCompare.Last().Score) 
			{
				Console.WriteLine("Enter name (4 char max): ");	// 4 char max so the leaderboard looks neat, and to make it look retro like old arcade games
				var username = Console.ReadLine();
				ValidateUsername(username);
				game.PlayerName = username;
				games.Add(game);
			}
		}

		internal static void ViewHighScores(GameMode gameMode)
		{
			int rank = 1;
			// Filter for games only in this gamemode
			var gamesToPrint = Helper.games.Where(x => x.Score > 0 && x.GameMode == gameMode)
			.OrderByDescending(x => x.Score)
			.ThenBy(x => x.Date)
			.Take(10)
			.ToList();

			Console.WriteLine("--------------------------------------\n" + 
				$"\t{gameMode} Highscores\n" + 
				"--------------------------------------");
			Console.WriteLine("RANK --- NAME --- SCORE --- DATE SET");
			foreach (var game in gamesToPrint)
			{
				Console.WriteLine($"   {rank} --- {game.PlayerName} --- {game.Score} --- {game.Date:dd-MM-yy}");
				rank++;
			}
			Console.WriteLine("--------------------------------------");
			
			Console.WriteLine("\tPress any key to continue");
			var keyInput = Console.ReadKey();
			if (keyInput != null) 
			{
				Console.Clear();
				OnReturnRequested?.Invoke();
			}
		}

		internal static List<Game> games = new List<Game>()
		{
			// Pre populating the list with values so theres something to see when you view highscores
			// K. Phillips has certified CTE
			new Game(GameMode.Subtraction, 6, "12-06-2024", "Sean"),
			new Game(GameMode.Subtraction, 6, "11-06-2024", "Vera"),
			new Game(GameMode.Multiplication, 4, "10-06-2024", "Ya"),
			new Game(GameMode.Multiplication, 3, "10-06-2024", "Boi"),
			new Game(GameMode.Addition, 10, "09-06-2024", "Deez"),
			new Game(GameMode.Addition, 9, "09-06-2024", "Nuds"),
			new Game(GameMode.Addition, 3, "08-06-2024", "Dat"),///////////////
			new Game(GameMode.Division, 9, "08-06-2024", "Boi"),
			new Game(GameMode.Division, 7, "07-06-2024", "John"),
			new Game(GameMode.Division, 5, "06-06-2024", "Smit"),
			// new Game(GameMode.Addition, 0, "05-06-2024", "K. Phillips")
		};
	}
}
