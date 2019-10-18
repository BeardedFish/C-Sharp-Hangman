using System;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// 
        /// </summary>
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
            


            string secretWord = getRandomWord();
            string[] outputWord = new string[secretWord.Length];

            for (int i = 0; i < outputWord.Length; i++)
            {
                outputWord[i] = "_";
            }

            List<char> usedLetters = new List<char>();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Hangman - By: Darian Benam\n");

                drawMan();

                // Check if the man is dead, if he is then that means game over.
                if (health <= 0)
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                // Print the unguessed word onto the console:
                Console.Write("Guess the word: ");
                for (int i = 0; i < outputWord.Length; i++)
                {
                    Console.Write(outputWord[i] + " ");
                }
                Console.WriteLine();

                // Print used letters onto screen:
                Console.WriteLine("Used letters: ");
                foreach (char letter in usedLetters)
                {
                    Console.Write(letter + " ");
                }


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
                    char letter = guess[0];

                    if (usedLetters.Contains(letter))
                    {
                        msg = "You already guessed that letter. Try again.";
                        continue;
                    }

                    if (secretWord.Contains(letter, StringComparison.OrdinalIgnoreCase))
                    {
                        for (int i = 0; i < secretWord.Length; i++)
                        {
                            if (string.Equals(secretWord[i].ToString(), guess, StringComparison.OrdinalIgnoreCase))
                            {
                                outputWord[i] = letter.ToString().ToLower();
                            }
                        }

                        msg = "Nice job! You are one step closer to solving the word. Keep it up!";
                    }
                    else
                    {
                        msg = "Word does not contain '" + letter + "'. Try again.";
                        health--;
                    }

                    usedLetters.Add(letter);

                }
                else
                {
                    if (string.Equals(guess, secretWord, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Clear();
                        Console.WriteLine("Hangman - By: Darian Benam\n");
                        Console.WriteLine("Congratulations, you guess the word!");
                        break;
                    }
                    else
                    {
                        msg = "Your guess of '" + guess + "' was incorrect!";
                        health--;
                    }
                }
            }


            Console.ReadLine();
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

        private static string getRandomWord()
        {
            string[] wordbank = new string[] { "Bob" };

            return wordbank[random.Next(0, wordbank.Length - 1)];
        }
    }
}
