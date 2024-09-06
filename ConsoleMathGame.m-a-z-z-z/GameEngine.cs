using ConsoleMathGame.m_a_z_z_z.Model;
using System.Diagnostics;

namespace ConsoleMathGame.m_a_z_z_z;

internal class GameEngine
{
    public event Action OnReturnRequested;

    internal void PlayGame(char mathOperator, Game game)    // Game is passed in method to keep track of game state as the PlayGame method calls on itself if user chooses to continue playing
    {
        Console.CursorVisible = true;   // make console cursor visible again now that we're not in menu and taking input
        Random random = new Random();
        string userAnswer;
        int correctAnswer = 0;
        int firstNum = random.Next(1, 99);
        int secondNum = random.Next(1, 99);

        // Calculate answer
        switch (mathOperator)
        {
            case '+':
                correctAnswer = firstNum + secondNum;
                break;
            case '-':
                correctAnswer = firstNum - secondNum;
                break;
            case '*':
                correctAnswer = firstNum * secondNum;
                break;
            case '/':
                while (firstNum % secondNum != 0)
                {
                    firstNum = random.Next(1, 99);
                    secondNum = random.Next(1, 99);
                }
                correctAnswer = firstNum / secondNum;
                break;
        }

        // Take user answer
        Console.Write($"{firstNum} {mathOperator} {secondNum} = ? ");
        userAnswer = Console.ReadLine();

        // ensure number was entered
        userAnswer = Helper.ValidateNumber(userAnswer);

        // Prompt question again if users answer is incorrect
        while (int.Parse(userAnswer) != correctAnswer)
        {
            Console.WriteLine("Wrong Answer. Try again.\n");
            Console.Write($"{firstNum} {mathOperator} {secondNum} = ? ");
            userAnswer = Console.ReadLine();
            userAnswer = Helper.ValidateNumber(userAnswer);
        }        
        
        game.Score++;
        Console.WriteLine($"\nCorrect!\t Score: {game.Score}");

        // Prompt user to continue or return to menu
        Console.WriteLine("Press any key to continue.\nR - Return to main menu.");
        var continueOrReturnInput = Console.ReadLine();

        if (continueOrReturnInput.Trim().ToUpper() == "R")
        {
            Console.Clear();
            // Go back to Program.cs and trigger StartProgram()
            OnReturnRequested?.Invoke();    // I prefer this to calling on the menu method in here again as it keeps the flow of the program to Main()/top level statement
        } else
        {
            Console.Clear();
            PlayGame(mathOperator, game);   // game is passed in and game state is preserved, keeping track of score and game mode selected
        }
    }

}
