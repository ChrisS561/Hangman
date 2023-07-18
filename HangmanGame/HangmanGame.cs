using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Random;
using System.Text;

namespace Hangman.HangmanGame
{
    public class HangmanGame
    {
        private string Hint;
        private int Id;
        private string word;

        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O    |");
                Console.WriteLine("/|    |");
                Console.WriteLine(" |    |");
                Console.WriteLine("     ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine(" |   |");
                Console.WriteLine("    ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine(" |   |");
                Console.WriteLine("/   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine(" |   |");
                Console.WriteLine("/ \\===");
            }
        }
        private static int printWord(List<char> guessedLetters, string RandomWord)
        {
            int counter = 0;
            int rightLetter = 0;
            Console.Write("\r\n");
            foreach (char character in RandomWord)
            {
                if (guessedLetters.Contains(character))
                {
                    System.Console.Write(character + " ");
                    rightLetter++;
                }
                else
                {
                    Console.Write(" ");
                }
                counter++;
            }
            return rightLetter;
        }
        private static void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach (char c in randomWord)
            {
                Console.Write("\u0305 ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game Hangman");
            Console.WriteLine("-------------------------------------------------------");


            Random random = new Random();
            List<HangmanGame> wordDictionary = new List<HangmanGame>();

            wordDictionary.Add(new HangmanGame { Id = 1, Hint = "Country", word = "United States" });
            wordDictionary.Add(new HangmanGame { Id = 2, Hint = "Country", word = "Russia" });
            wordDictionary.Add(new HangmanGame { Id = 3, Hint = "Animal", word = "Elephant" });
            wordDictionary.Add(new HangmanGame { Id = 4, Hint = "Color", word = "Purple" });
            wordDictionary.Add(new HangmanGame { Id = 5, Hint = "Fruit", word = "Banana" });
            wordDictionary.Add(new HangmanGame { Id = 6, Hint = "City", word = "Paris" });
            wordDictionary.Add(new HangmanGame { Id = 7, Hint = "Sport", word = "Football" });
            wordDictionary.Add(new HangmanGame { Id = 8, Hint = "Vehicle", word = "Motorcycle" });
            wordDictionary.Add(new HangmanGame { Id = 9, Hint = "Food", word = "Pizza" });
            wordDictionary.Add(new HangmanGame { Id = 10, Hint = "Movie", word = "Titanic" });

            int randomIndex = random.Next(wordDictionary.Count);
            string randomWordF = wordDictionary[randomIndex].word;
            string randomHintF = wordDictionary[randomIndex].Hint;

            foreach (char x in randomWordF)
            {
                Console.Write("_ ");
            }
            
            int lengthOfWordToGuess = randomWordF.Length;
            int amountOfTimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;

            while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\r\n");
                Console.Write("Hint:" + randomHintF + " ");
                Console.Write("\nLetters gussed so far: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }

                //Promt user for input
                Console.Write("\nGuess a Letter: ");
                char letterGuessed = Console.ReadLine()[0];
                //Check if letter has already been guessed 
                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.WriteLine("\nYou have already guessed that letter.");
                }
                else
                {
                    currentLettersGuessed.Add(letterGuessed);
                    bool isLetterInWord = false;

                    foreach (char letter in randomWordF)
                    {
                        if (letter == letterGuessed)
                        {
                            isLetterInWord = true;
                            break; // No need to continue checking if letter is already found
                        }
                    }

                    if (isLetterInWord)
                    {
                        Console.WriteLine();
                        printHangman(amountOfTimesWrong);
                        currentLettersRight = printWord(currentLettersGuessed, randomWordF);
                        Console.WriteLine();
                        printLines(randomWordF);
                    }
                    else
                    {
                        amountOfTimesWrong++;
                        Console.WriteLine();
                        printHangman(amountOfTimesWrong);
                        currentLettersRight = printWord(currentLettersGuessed, randomWordF);
                        Console.WriteLine();
                        printLines(randomWordF);
                    }
                }

            }
            Console.WriteLine("\r\n The word was: " + randomWordF);
        }
    }
}
