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

                //Get Player 1 and Player 2 name from input
                Console.WriteLine("Enter Player 1 Name :");
                Player player1 = new Player(Console.ReadLine());
                Console.WriteLine("Enter Player 2 Name :");
                Player player2 = new Player(Console.ReadLine());

                ITennisGame tennisGame = new TennisGame(player1, player2);

                Console.WriteLine("Enter Point Sequence separated by comma: ");

                // Read input from console
                string input = Console.ReadLine();
                string pattern = @"^[\w\d]+(,[\w\d]+)*$";

                if (Regex.IsMatch(input, pattern))
                {
                    // Split input string into array of strings
                    string[] PointSequence = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    // Convert array of string to array of integers
                    int[] Points = new int[PointSequence.Length];
                    for (int i = 0; i < PointSequence.Length; i++)
                    {
                        if (int.TryParse(PointSequence[i], out int Point))
                        {

                            //check if number is either 0 or 1 only
                            if (Point != 0 && Point != 1)
                            {
                                Console.WriteLine($"Invalid input: '{Point}' is neither 0 not 1.");
                                Console.WriteLine("Press any key to exit.");
                                Console.ReadKey();
                            }
                            else
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
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input: '{Point}' is not a valid integer.");
                            break;
                        }
                    }

                    Console.WriteLine($"\r\nGame over! {tennisGame.GetWinner().Name } wins!");
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid pattern recongised for Point sequence, it should be separated by comma.");
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
    }
}
