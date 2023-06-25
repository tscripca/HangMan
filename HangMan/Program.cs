using System;

namespace HangMan // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            const int MAX_TRIES = 4;
            int guessCounter = 0;
            char underline = '_';
            char userLetter;
            bool answer = true;

            while (answer)
            {                
                List<char> storeLetters = new List<char>();
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

                Console.Clear();

                Random rng = new Random();
                int randomPicker = rng.Next(hiddenWords.Count);
                string randomHiddenWord = hiddenWords[randomPicker];

                for (int j = 0; j < randomHiddenWord.Length; j++)
                {
                    storeLetters.Add(underline);
                    Console.Write(storeLetters[j]);
                }

                for (guessCounter = 0; guessCounter < MAX_TRIES; guessCounter++)
                {
                    Console.Write("\nInsert letter: ");
                    userLetter = Convert.ToChar(Console.ReadLine());

                    for (int i = 0; i < randomHiddenWord.Length; i++)
                    {
                        if (userLetter == randomHiddenWord[i])
                        {
                            storeLetters[i] = userLetter;//here is where the underline becomes the guessed letter
                            Console.Write(storeLetters[i]);
                        }                        
                        else
                        {
                            Console.Write(storeLetters[i]);
                        }                        
                    }
                }

                if (guessCounter == MAX_TRIES)
                {
                    Console.WriteLine("\nGAME OVER!\nWould you like to play again?: Y/N");
                    string userAnswer = Console.ReadLine().ToLower();
                    answer = (userAnswer == "y");
                }
            }
        }
    }
}
