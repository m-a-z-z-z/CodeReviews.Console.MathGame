using ConsoleMathGame.m_a_z_z_z.Model;

namespace ConsoleMathGame.m_a_z_z_z;
internal class GameEngine
{	
	internal int[] NumGenerator(int score) 
	{
		Random random = new Random();
		
		// increase difficulty by score
		if (score < 2 ) 
		{
			var firstNum = random.Next(1, 12);
			var secondNum = random.Next(1, 12);
			return new int[] { firstNum, secondNum };
		} 
		else if (score >= 2 && score < 5) 
		{
			var firstNum = random.Next(3, 12);
			var secondNum = random.Next(3, 12);
			return new int[] { firstNum, secondNum };
			
		}
		else
		{
			var firstNum = random.Next(2, 99);
			var secondNum = random.Next(2,99);
			return new int[] { firstNum, secondNum };
		}
	}
	
	internal void PlayGame(char mathOperator, Game game)    // Game is passed in method to keep track of game state as the PlayGame method calls on itself if user chooses to continue playing
	{
		// Var declartion
		Console.CursorVisible = true;   // make console cursor visible again now that we're not in menu and taking input
		string userAnswer;
		int correctAnswer = 0;
		int[] nums = NumGenerator(game.Score);

		// Calculate answer
		switch (mathOperator)
		{
			case '+':
				correctAnswer = nums[0] + nums[1];
				break;
			case '-':
				correctAnswer = nums[0] - nums[1];
				break;
			case '*':
				correctAnswer = nums[0] * nums[1];
				break;
			case '/':
				while (nums[0] % nums[1] != 0)
				{
					nums = NumGenerator(game.Score);
				}
				correctAnswer = nums[0] / nums[1];
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
			Console.WriteLine("Continue? [y/n]");
			var reply = Console.ReadLine().Trim().ToLower();
			
			if (reply == "n" || reply == "no") 
			{
				Helper.AddScoreToLeaderboard(game);	
				Console.Clear();
				Helper.ViewHighScores(game.GameMode);
			}
			game.Score = 0;	// reset if user presses key besides 'y' or 'yes'
		}
		else if (int.Parse(userAnswer) == correctAnswer)	// Case for correct answer 
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
		PlayGame(mathOperator, game);   // game is passed in and game state is preserved, keeping track of score and game mode selected
	}

}
