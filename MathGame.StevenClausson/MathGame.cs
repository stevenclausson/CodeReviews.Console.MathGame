using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.StevenClausson
{
    public class MathGame
    {
        public MathGame()
        {
            bool playAgain = true;
            this.Game(playAgain);
        }

        private void Game(bool again)
        {
            List<string> history = new List<string>();
            while (again)
            {
                Console.WriteLine("\nChoose a game: ");
                Console.WriteLine("1 - Addition");
                Console.WriteLine("2 - Subtraction");
                Console.WriteLine("3 - Multiplication");
                Console.WriteLine("4 - Division");
                Console.WriteLine("5 - Exit");
                string userChoice = Console.ReadLine();
                if (userChoice == "5" || !again)
                {
                    again = false;
                    continue;
                }
                Random rnd = new Random();
                int num1 = rnd.Next(1, 10);
                int num2 = rnd.Next(1, 10);
                int correctAnswer = 0;
                string operation = "";

                Stopwatch sw = Stopwatch.StartNew();
                switch (userChoice)
                {
                    case "1":
                        sw.Start();
                        operation = "+";
                        correctAnswer = num1 + num2;
                        break;
                    case "2":
                        sw.Start();
                        operation = "-";
                        correctAnswer = num2 - num1;
                        break;
                    case "3":
                        sw.Start();
                        operation = "*";
                        correctAnswer = num2 * num1;
                        break;
                    case "4":
                        sw.Start();
                        while (num1 % num2 != 0)
                        {
                            num1 = rnd.Next(1, 101);
                            num2 = rnd.Next(1, 101);
                        }
                        operation = "/";
                        correctAnswer = num2 / num1;
                        break;
                    default:
                        Console.WriteLine("Not a choice.");
                        continue;
                }

                Console.WriteLine($"\nWhat is {num1} {operation} {num2}?");
                string userAnswer = Console.ReadLine();
                sw.Stop();

                int answer;
                if (int.TryParse(userAnswer, out answer) && answer == correctAnswer)
                {
                    Console.WriteLine("Correct answer!");
                    history.Add($"{num1} {operation} {num2} = {correctAnswer} (Correct)");
                }
                else
                {
                    Console.WriteLine($"Wrong answer. The correct answer is {correctAnswer}.");
                    history.Add($"{num1} {operation} {num2} = {correctAnswer} (Wrong)");
                }

                Console.WriteLine("\n6 - View Game History");
                //Stopwatch time
                TimeSpan ts = sw.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine($"Game time: {elapsedTime}. Do you want to play again? (y/n)");
                string playAgain = Console.ReadLine();

                if (playAgain == "6")
                {
                    ShowHistory(history);
                    Console.WriteLine("\nDo you want to play again? (y/n)");
                    playAgain = Console.ReadLine();
                }
                again = playAgain.ToLower() == "y";
            }
        }

        private void ShowHistory(List<string> history)
        {
            Console.WriteLine("\nGame History: \n");
            if (history.Count == 0)
            {
                Console.WriteLine("No games.");
            }
            else
            {
                foreach (var game in history)
                {
                    Console.WriteLine(game);
                }
            }

        }
    }
}
