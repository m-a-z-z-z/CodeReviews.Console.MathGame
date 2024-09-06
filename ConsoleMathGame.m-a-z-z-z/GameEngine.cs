using System.Diagnostics;

namespace ConsoleMathGame.m_a_z_z_z;

internal class GameEngine
{
    public event Action OnReturnRequested;

    internal void PlayGame(char mathOperator)
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

        userAnswer = Helper.ValidateNumber(userAnswer);  // ensure number was entered

        // Prompt question again if users answer is incorrect
        while (int.Parse(userAnswer) != correctAnswer)
        {
            Console.WriteLine("Wrong Answer. Try again.\n");
            Console.Write($"{firstNum} {mathOperator} {secondNum} = ? ");
            userAnswer = Console.ReadLine();
            userAnswer = Helper.ValidateNumber(userAnswer);
        }

        Console.WriteLine("\nCorrect!");

        //TODO
        //Increment score after while loop

        // Prompt user to continue or return to menu
        Console.WriteLine("Press any key to continue.\nR - Return to main menu.");
        var continueOrReturnInput = Console.ReadLine();

        if (continueOrReturnInput.Trim().ToUpper() == "R")
        {
            Console.Clear();
            OnReturnRequested?.Invoke();    // Trigger the main program again, which triggers StartProgram().
        } else
        {
            Console.Clear();
            PlayGame(mathOperator);
        }
    }

}
