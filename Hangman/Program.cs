/*
 * Program Name: Hangman
 * Program Description: This program is an exact copy of the classic game called Hangman. The goal of
 *                      the program is for the player to guess a secret word. Each time the player
 *                      guesses incorrectly, a part of a man is hanged on a noose. If the player
 *                      doesn't guess the correct word and the man is fully hanged then it's
 *                      game over.
 * By: Darian Benam (GitHub: https://github.com/BeardedFish)
 * Date: October 17, 2019
 */

using System;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        /// <summary>
        /// The random class which will be used for generating a random word in the getRandomWord() method.
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// The health of the man, less than or equal to 0 means he got hanged (game over).
        /// </summary>
        private static int health = 6;

        /// <summary>
        /// Main entry point of the program.
        /// </summary>
        /// <param name="args">The arguments passed to the program.</param>
        static void Main(string[] args)
        {
            // Change the title of the console:
            Console.Title = "Hangman - By: Darian Benam";

            // Print program explanation onto console:
            Console.WriteLine("Hangman - By: Darian Benam");
            Console.WriteLine("This program is an exact replica of the class game called Hangman. The goal of the game is to guess a randomly generated word. ");
            Console.WriteLine("\nPress any key to begin playing...");

            // Wait for the user to press any key and clear the console.
            Console.ReadKey();
            Console.Clear();

            // A string for storing a message the program wants to tell the player.
            string msg = null;
          
            // A string that will store a randomly generated word.
            string secretWord = getRandomWord();

            /*
             *  A string array that will be printed onto the console. It will be the same length as
             *  the secret word, except each letter will be replaced by an underscore. When the user
             *  guesses a correct letter, the underscore where that letter appears will be replaced
             *  by the correct letter.
             *  
             *  EX: Say the secret word was "darian"
             *  
             *  secretWord = "darian"
             *  outputWord = "______"
             *  
             *  If the user guesses the letter d then outputWord would become:
             *  outputWord = "d_____"
             */
            string[] outputWord = new string[secretWord.Length];
            for (int i = 0; i < outputWord.Length; i++)
            {
                if (secretWord[i].Equals(' '))
                {
                    outputWord[i] = " ";
                }
                else
                {
                    outputWord[i] = "_";
                }
            }

            // A list for storing used letters that the player already guessed.
            List<char> usedLetters = new List<char>();

            while (true)
            {
                // Clear the console and print the title of the program.
                Console.Clear();
                Console.WriteLine("Hangman - By: Darian Benam\n");

                // Draw the man that is being hanged onto the console:
                drawMan();

                // Check if the man is dead, if he is then that means game over.
                if (health <= 0)
                {
                    Console.WriteLine("Game over!");
                    Console.WriteLine("The secret word was '" + secretWord + ".");
                    break;
                }

                // Check if the player got the correct word:
                if (string.Equals(secretWord, string.Join("", outputWord), StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Congratulations, you guess the word!");
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
                Console.Write("Used letters: ");
                foreach (char letter in usedLetters)
                {
                    Console.Write(letter + " ");
                }
                Console.WriteLine("\n");

                // Print the message the program is trying to tell the user (ex: incorrect input, correct, etc.)
                if (msg != null)
                {
                    Console.WriteLine(msg + "\n");
                    msg = null;
                }

                Console.Write("Enter a letter or guess the word: ");
                string guess = Console.ReadLine();

                if (guess.Length == 0) // If the length is equal to 0, that means the player didn't enter a valid guess.
                {
                    msg = "You can't leave the field blank! Try again.";
                    continue;
                }
                else if (guess.Length == 1) // If the length is equal to 1, that means the player wants to guess a letter.
                {
                    // Convert the string to a char.
                    char letter = guess[0];

                    // Make sure the char is a valid letter (ex: it should not be !, @, #, etc.).
                    if (!char.IsLetter(letter))
                    {
                        msg = "Your input of '" + letter + "' was invalid. You must enter a letter. Try again.";
                        continue;
                    }

                    // Make sure the letter has not been guessed/used before.
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

                    // Add the letter to the list.
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
            } // End while loop.


            Console.ReadLine();
        }

        /// <summary>
        /// Draws the current state of the man on the noose, depending on his health.
        /// </summary>
        private static void drawMan()
        {
            switch (health)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine(" |--------|");
                    Console.WriteLine(" |        |");
                    Console.WriteLine(" |        O - I'm dead. :(");
                    Console.WriteLine(@" |       /|\ ");
                    Console.WriteLine(@" |       / \ ");
                    Console.WriteLine(" |");
                    Console.WriteLine();
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine(" |--------|");
                    Console.WriteLine(" |        |");
                    Console.WriteLine(" |        O");
                    Console.WriteLine(@" |       /|\ ");
                    Console.WriteLine(@" |       /");
                    Console.WriteLine(" |");
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine(" |--------|");
                    Console.WriteLine(" |        |");
                    Console.WriteLine(" |        O");
                    Console.WriteLine(@" |       /|\ ");
                    Console.WriteLine(@" |");
                    Console.WriteLine(" |");
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine(" |--------|");
                    Console.WriteLine(" |        |");
                    Console.WriteLine(" |        O");
                    Console.WriteLine(@" |       /|");
                    Console.WriteLine(@" |");
                    Console.WriteLine(" |");
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine();
                    Console.WriteLine(" |--------|");
                    Console.WriteLine(" |        |");
                    Console.WriteLine(" |        O");
                    Console.WriteLine(@" |        |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(" |");
                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine();
                    Console.WriteLine(" |--------|");
                    Console.WriteLine(" |        |");
                    Console.WriteLine(" |        O");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(" |");
                    Console.WriteLine();
                    break;
                case 6:
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

        /// <summary>
        /// Generates a randomly generated word from a word bank string array.
        /// </summary>
        /// <returns>A string that contains a randomly generated word.</returns>
        private static string getRandomWord()
        {
            string[] wordbank = new string[] { "august", "attempt", "calm", "cookies", "doll", "exist", "film", "facing", "memory", "poetry", "scared", "zoo", "university", "college", "slope", "math", "darian benam" };

            return wordbank[random.Next(0, wordbank.Length - 1)];
        }
    }
}
