using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using TennisScoreSimulator.TennisScoreSimulator;


namespace TennisScoreSimulator
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                Console.WriteLine("!!! Tennis Game Simulator !!!");
                string name1 = string.Empty;
                string name2 = string.Empty;

                //Get Player 1  name from input & validate it
                do
                {
                    Console.WriteLine("Enter Player 1 Name :");
                    name1 = Console.ReadLine();

                    if (string.IsNullOrEmpty(name1) || !IsValidName(name1))
                    {
                        Console.WriteLine("Invalid name. Please try again.");
                    }
                } while (string.IsNullOrEmpty(name1) || !IsValidName(name1));

                Player player1 = new Player(name1);

                //Get Player 2  name from input & validate it
                do
                {
                    Console.WriteLine("Enter Player 2 Name :");
                    name2 = Console.ReadLine();

                    if (string.IsNullOrEmpty(name2) || !IsValidName(name2))
                    {
                        Console.WriteLine("Invalid name. Please try again.");
                    }
                } while (string.IsNullOrEmpty(name2) || !IsValidName(name2));

                Player player2 = new Player(name2);
                ITennisGame tennisGame = new TennisGame(player1, player2);
                string input = string.Empty;
                //string pattern = @"^-?\d+(?:,-?\d+)*$";
                string pattern = @"^(0|1)(,(0|1))*$";

                do
                {
                    Console.WriteLine("Enter Point Sequence separated by comma: ");

                    // Read input from console
                    input = Console.ReadLine();

                    if (!Regex.IsMatch(input, pattern))
                    {
                        Console.WriteLine("Invalid pattern recongised for Point sequence, it should be either 1 or 0 separated by comma.");
                    }
                }
                while (!Regex.IsMatch(input, pattern));

                // Split input string into array of strings
                string[] PointSequence = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // Convert array of string to array of integers
                int[] Points = new int[PointSequence.Length];
                for (int i = 0; i < PointSequence.Length; i++)
                {
                    if (int.TryParse(PointSequence[i], out int Point))
                    {

                        // Check if the match is finished after each point
                        if (!tennisGame.IsMatchFinished())
                        {
                            //build output here
                            Console.Write("\r\nPoint " + i + " : " + tennisGame.PlayPoint(Point));
                            Console.Write("\r\nCurrent Game Score :" + tennisGame.GetCurrentGameScore());
                            Console.Write("\r\nCurrent Set Score :" + tennisGame.GetCurrentSetScore());
                            Console.Write("\r\nCurrent Match Socre :" + tennisGame.GetCurrentMatchScore());
                            Console.Write("\r\n");
                        }
                        else
                        {
                            break;
                        }
                        
                    }

                }
                if (tennisGame.IsMatchFinished())
                {
                    Console.WriteLine($"\r\nGame over! {tennisGame.GetWinner().Name } wins!");
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"\r\nThe match is not finished yet!");
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static bool IsValidName(string name)
        {
            // Regex pattern to allow letters (both uppercase and lowercase) and spaces
            string pattern = @"^[a-zA-Z\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(name);
        }
    }
}
