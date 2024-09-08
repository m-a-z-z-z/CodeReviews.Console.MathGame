using ConsoleMathGame.m_a_z_z_z.Model;

namespace ConsoleMathGame.m_a_z_z_z
{
	internal static class Helper
	{
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
						
			Console.WriteLine("Enter name: ");
			game.PlayerName = Console.ReadLine();
			
			while (string.IsNullOrEmpty(game.PlayerName) || string.IsNullOrWhiteSpace(game.PlayerName)) 
			{
				Console.Write("Enter a name, damn it!: ");
				Console.ReadLine();
			}
			
			games.Add(game);
		}

		internal static void ViewHighScores(List<Game> gamesList)
		{
			int rank = 1;
			Console.WriteLine("RANK --- NAME --- SCORE --- DATE SET");
			foreach (var game in gamesList)
			{
				Console.WriteLine($"{rank} --- {game.PlayerName} --- {game.Score} --- {game.Date:dd-MM-yy}");
				rank++;
			}
		}

		internal static List<Game> games = new List<Game>()
		{
			// Pre populating the list with values so theres something to see when you view highscores
			// K. Phillips has certified CTE
			new Game(GameMode.Subtraction, 29, "12-06-2024", "S O\'Malley"),
			new Game(GameMode.Subtraction, 28, "11-06-2024", "M. Dvalishvili"),
			new Game(GameMode.Multiplication, 28, "10-06-2024", "C. Sandhagen"),
			new Game(GameMode.Multiplication, 20, "10-06-2024", "M. Vera"),
			new Game(GameMode.Addition, 14, "09-06-2024", "H. Cejudo"),
			new Game(GameMode.Addition, 14, "09-06-2024", "D. Figueiredo"),
			new Game(GameMode.Addition, 13, "08-06-2024", "S. Yadong"),
			new Game(GameMode.Division, 12, "08-06-2024", "J. Aldo"),
			new Game(GameMode.Division, 10, "07-06-2024", "R. Font"),
			new Game(GameMode.Division, 5, "06-06-2024", "U. Nurmagonedov"),
			new Game(GameMode.Addition, 0, "05-06-2024", "K. Phillips")
		};
	}
}
