﻿using System.Diagnostics;

namespace ConsoleMathGame.m_a_z_z_z;

internal class GameEngine
{
    public event Action OnReturnRequested;
    internal void PlayGame(char mathOperator)
    {
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

        // TODO
        // validate user input

        while (int.Parse(userAnswer) != correctAnswer)
        {
            Console.WriteLine("Wrong Answer. Try again.\n");
            Console.Write($"{firstNum} {mathOperator} {secondNum} = ? ");
            userAnswer = Console.ReadLine();
        }

        Console.WriteLine("Correct!");

        //TODO
        //Increment score after while loop
        Console.WriteLine("Press any key to continue.\nR - Return to main menu.");
        var continueOrReturnInput = Console.ReadLine();

        if (continueOrReturnInput.Trim().ToUpper() == "R")
        {
            Console.Clear();
            OnReturnRequested?.Invoke();    // Trigger the main program again, which triggers StartProgram().
        } else
        {
            PlayGame(mathOperator);
        }
    }

}
