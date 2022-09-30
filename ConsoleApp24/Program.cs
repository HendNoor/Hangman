using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
    class Program
    {
        static string[] listOfWords = { "Hend", "Brain", "Apple", "Gold"};
        static void Main(string[] args)
        {
           Console.WriteLine("Welcom to hangman game! \n");

            Random random = new Random();


            string randomWord = listOfWords[random.Next(0, listOfWords.Length)];
            string randomWordUppercase = randomWord.ToUpper();

            StringBuilder display = new StringBuilder(randomWord.Length);
            for (int i = 0; i < randomWord.Length; i++)
                display.Append('_');

            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            int attempts = 10;
            bool won = false;
            int lettersRevealed = 0;

            string input;
            char guess;

            while (!won && attempts > 0)
            {
                Console.Write("The word has {0} letters,\nGuess a letter: ", randomWord.Length);

                input = Console.ReadLine().ToUpper();
                guess = input[0];
                Console.WriteLine("Remaining attempts: {0}", attempts);

                if (correctGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                    continue;
                }

                if (randomWordUppercase.Contains(guess))
                {
                    correctGuesses.Add(guess);

                    for (int i = 0; i < randomWord.Length; i++)
                    {
                        if (randomWordUppercase[i] == guess)
                        {
                            display[i] = randomWord[i];
                            lettersRevealed++;
                        }
                    }

                    if (lettersRevealed == randomWord.Length)
                        won = true;
                }
                else
                {
                    incorrectGuesses.Add(guess);

                    Console.WriteLine("Incorrect, there's no '{0}' in it!", guess);
                    attempts--;
                }

                Console.WriteLine(display.ToString());
            }

            if (won)
                Console.WriteLine("You won! the word is {0}",randomWord);
            else
                Console.WriteLine("You lost! It was '{0}'", randomWord);

            Console.Write("Press ENTER to exit...");
            Console.ReadLine();
            Console.Clear();
            Environment.Exit(0);
        }
    }
}
