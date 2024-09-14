using ConsoleMathGame.m_a_z_z_z.Model;

namespace ConsoleMathGame.m_a_z_z_z;
internal class GameEngine
{	
	internal int[] NumGenerator(Difficulty difficulty) 
	{
		Random random = new Random();
		int firstNum;
		int secondNum;
		
		switch (difficulty) 
		{
			case Difficulty.Easy:
				firstNum = random.Next(1, 12);
				secondNum = random.Next(1, 12);
				return new int[] { firstNum, secondNum };
			case Difficulty.Medium:
				firstNum = random.Next(3, 24);
				secondNum = random.Next(3, 24);
				return new int[] { firstNum, secondNum };
			case Difficulty.Hard:
				firstNum = random.Next(2, 99);
				secondNum = random.Next(2,99);
				return new int[] { firstNum, secondNum };
			default:
				firstNum = random.Next(3, 24);
				secondNum = random.Next(3, 24);
				return new int[] { firstNum, secondNum };				
		}
	}
	
	internal void PlayGame(Game game)    // Game is passed in method to keep track of game state as the PlayGame method calls on itself if user chooses to continue playing
	{
		// Var declartion
		Console.CursorVisible = true;   // make console cursor visible again now that we're not in menu and taking input
		string userAnswer;
		int correctAnswer;
		char mathOperator;
		int[] nums = NumGenerator(game.Difficulty);	// Generate numbers in a certain range based on difficulty

		// Calculate answer
		switch (game.GameMode)
		{
			case GameMode.Addition:
				correctAnswer = nums[0] + nums[1];
				mathOperator = '+';
				break;
			case GameMode.Subtraction:
				correctAnswer = nums[0] - nums[1];
				mathOperator = '-';
				break;
			case GameMode.Multiplication:
				correctAnswer = nums[0] * nums[1];
				mathOperator = '*';
				break;
			case GameMode.Division:
				while (nums[0] % nums[1] != 0)
				{
					nums = NumGenerator(game.Difficulty);
				}
				correctAnswer = nums[0] / nums[1];
				mathOperator = '/';
				break;
			default:
				correctAnswer = nums[0] + nums[1];
				mathOperator = '+';
				break;				
		}

		// Take user answer
		Console.Write($"{nums[0]} {mathOperator} {nums[1]} = ? ");
		userAnswer = Console.ReadLine();

		// ensure number was entered
		userAnswer = Helper.ValidateNumber(userAnswer);

		// Case for incorrect answer
		if (int.Parse(userAnswer) != correctAnswer)
		{
			Console.WriteLine($"Incorrect. Final score: {game.Score}");
			Helper.AddScoreToLeaderboard(game);	
			Console.WriteLine("Continue? [y/n]");
			var reply = Console.ReadLine().Trim().ToLower();
			
			if (reply == "n" || reply == "no") 
			{
				Console.Clear();
				Helper.ViewHighScores(game.GameMode);
			}
			game.Score = 0;	// reset if user presses key besides 'y' or 'yes'
		}	// Case for correct answer 
		else if (int.Parse(userAnswer) == correctAnswer)
		{
			game.Score++;
			Console.WriteLine($"\nCorrect!\t Score: {game.Score}");
			Console.WriteLine("Press any key to continue.\n" + "Q to return to menu.");
			var reply = Console.ReadLine().Trim().ToLower();
			if (reply == "q" || reply == "quit") 
			{
				Helper.AddScoreToLeaderboard(game);
				Console.Clear();
				Helper.ViewHighScores(game.GameMode);
			}
		}		
		
		Console.Clear();
		PlayGame(game);   // game is passed in and game state is preserved, keeping track of score and game mode selected
	}

}
