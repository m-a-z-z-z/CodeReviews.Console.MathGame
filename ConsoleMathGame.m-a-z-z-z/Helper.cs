﻿using ConsoleMathGame.m_a_z_z_z.Model;

namespace ConsoleMathGame.m_a_z_z_z
{
	internal static class Helper
	{
		public static event Action OnReturnRequested;
		
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
				game.PlayerName = Console.ReadLine();
				
				while (string.IsNullOrEmpty(game.PlayerName) || string.IsNullOrWhiteSpace(game.PlayerName)) 
				{
					Console.Write("Enter a name, damn it!: ");
					Console.ReadLine();
				}	
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
			new Game(GameMode.Subtraction, 6, "12-06-2024", "S O\'Malley"),
			new Game(GameMode.Subtraction, 6, "11-06-2024", "M. Dvalishvili"),
			new Game(GameMode.Multiplication, 4, "10-06-2024", "C. Sandhagen"),
			new Game(GameMode.Multiplication, 3, "10-06-2024", "M. Vera"),
			new Game(GameMode.Addition, 10, "09-06-2024", "H. Cejudo"),
			new Game(GameMode.Addition, 9, "09-06-2024", "D. Figueiredo"),
			new Game(GameMode.Addition, 3, "08-06-2024", "S. Yadong"),///////////////
			new Game(GameMode.Division, 9, "08-06-2024", "J. Aldo"),
			new Game(GameMode.Division, 7, "07-06-2024", "R. Font"),
			new Game(GameMode.Division, 5, "06-06-2024", "U. Nurmagonedov"),
			// new Game(GameMode.Addition, 0, "05-06-2024", "K. Phillips")
		};
	}
}
