using System;

namespace HangMan // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            const int MAX_TRIES = 3;            
            char underline = '_';
            char userLetter;
            bool playAgain = true;

            List<char> guessedLetter = new List<char>();

            List<string> hiddenWords = new List<string>()
                {
                "airplane",
                "parachute",
                "framework",
                "netherlands",
                "sternocleidomastoid",
                "carbonara",
                "massachusetts"
                };
            
            List<string> terminationsList = new List<string>() 
            {
                "st",
                "nd",
                "rd",
                "th"
            };

            Random rng = new Random();

            while (playAgain)
            {
                int randomPicker = rng.Next(hiddenWords.Count);
                string randomHiddenWord = hiddenWords[randomPicker];

                Console.Clear();                

                for (int j = 0; j < randomHiddenWord.Length; j++)
                {
                    guessedLetter.Add(underline);
                    Console.Write(guessedLetter[j]);
                }

                for (int guessCounter = 0; guessCounter <= MAX_TRIES; guessCounter++)
                {
                    int countOfTries = guessCounter + 1;
                    Console.Write($"\n{countOfTries}{terminationsList[guessCounter]} attempt\nInsert letter: ");
                    userLetter = Convert.ToChar(Console.ReadLine().ToLower().Trim());

                    Console.Clear();                    

                    for (int i = 0; i < randomHiddenWord.Length; i++)
                    {
                        if (userLetter == randomHiddenWord[i])
                        {
                            guessedLetter[i] = userLetter;//here is where the underline becomes the guessed letter                            
                        }

                        Console.Write(guessedLetter[i]);
                    }
                }

                Console.WriteLine($"\nTry to guess the word: ");                
                string userKnowsTheWord = Console.ReadLine().ToLower().Trim();
                
                if (userKnowsTheWord == randomHiddenWord)
                {
                    Console.WriteLine("WINNER!");
                }
                else
                {
                    Console.WriteLine("\nSorry, GAME OVER!");
                }

                Console.WriteLine("\nWould you like to play again?: Y/N");
                string userAnswer = Console.ReadLine().ToLower();
                playAgain = (userAnswer == "y");
                guessedLetter.Clear();
            }
        }
    }
}
