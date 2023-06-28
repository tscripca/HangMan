using System;

namespace HangMan // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            const int MAX_TRIES = 3;            
            char underline = '_';
            //char userLetter;
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

                Console.WriteLine();

                for (int guessCounter = 0; guessCounter <= MAX_TRIES; guessCounter++)
                {                    
                    int countOfTries = MAX_TRIES - guessCounter + 1;
                    Console.Write($"{countOfTries} attempts left");
                    Console.WriteLine();
                    Console.Write("Insert letter: ");
                    ConsoleKeyInfo userLetter = Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine($"You've entered: {userLetter.KeyChar}");

                    Console.Clear();                    

                    for (int i = 0; i < randomHiddenWord.Length; i++)
                    {
                        if (userLetter.KeyChar == randomHiddenWord[i])
                        {
                            guessedLetter[i] = userLetter.KeyChar;//here is where the underline becomes the guessed letter                            
                        }

                        Console.Write(guessedLetter[i]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Try to guess the word: ");                
                string userKnowsTheWord = Console.ReadLine().ToLower().Trim();
                
                if (userKnowsTheWord == randomHiddenWord)
                {
                    Console.Clear();
                    Console.WriteLine(randomHiddenWord);
                    Console.WriteLine("WINNER!");                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, GAME OVER!");
                }

                Console.WriteLine("Would you like to play again?: Y/N");
                string userAnswer = Console.ReadLine().ToLower();
                playAgain = (userAnswer == "y");
                guessedLetter.Clear();
            }
        }
    }
}
