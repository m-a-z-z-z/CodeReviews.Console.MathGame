using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return userAnswer;
        }
    }
}
