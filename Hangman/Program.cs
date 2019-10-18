using System;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        private static int health = 6;
        static void Main(string[] args)
        {
            // Print program explanation onto console:
            Console.WriteLine("Hangman - By: Darian Benam");
            Console.WriteLine("This program is an exact replica of the class game called Hangman. The goal of the game is to guess a randomly generated word. ");
            Console.WriteLine("\nPress any key to begin playing...");

            Console.ReadKey();
            Console.Clear();

            // A string for storing a message the program wants to tell the player.
            string msg = null;

            List<char> usedChars = new List<char>();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Hangman - By: Darian Benam\n");

                drawMan();

                // Print used letters onto screen:
                Console.WriteLine("Used letters: \n");


                if (msg != null)
                {
                    Console.WriteLine(msg + "\n");
                    msg = null;
                }

                Console.Write("Enter a letter or guess the word: ");
                string guess = Console.ReadLine();

                if (guess.Length == 0)
                {
                    msg = "You can't leave the field blank! Try again.";
                    continue;
                }
                else if (guess.Length == 1)
                {
                    
                }
                else
                {

                }
            }
        }

        private static void drawMan()
        {
            switch (health)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine(" |--------|");
                    Console.WriteLine(" |        |");
                    Console.WriteLine(" |        O ");
                    Console.WriteLine(@" |       /|\ ");
                    Console.WriteLine(@" |       / \ ");
                    Console.WriteLine(" |");
                    Console.WriteLine();
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine(" |--------|");
                    Console.WriteLine(" |        |");
                    Console.WriteLine(" |        O ");
                    Console.WriteLine(@" |       /|\ ");
                    Console.WriteLine(@" |       /");
                    Console.WriteLine(" |");
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine(" |--------|");
                    Console.WriteLine(" |        |");
                    Console.WriteLine(" |        O ");
                    Console.WriteLine(@" |       /|\ ");
                    Console.WriteLine(@" |");
                    Console.WriteLine(" |");
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine(" |--------|");
                    Console.WriteLine(" |        |");
                    Console.WriteLine(" |        O ");
                    Console.WriteLine(@" |       /|");
                    Console.WriteLine(@" |");
                    Console.WriteLine(" |");
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine();
                    Console.WriteLine(" |--------|");
                    Console.WriteLine(" |        |");
                    Console.WriteLine(" |        O ");
                    Console.WriteLine(@" |        |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(" |");
                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine();
                    Console.WriteLine(" |--------|");
                    Console.WriteLine(" |        |");
                    Console.WriteLine(" |        O ");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(" |");
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine(" |--------|");
                    Console.WriteLine(" |        |");
                    Console.WriteLine(" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(" |");
                    Console.WriteLine();
                    break;
            }
        }

        private static void getRandomWord()
        {
            string[] wordbank = new string[] { "" };

        }
    }
}
