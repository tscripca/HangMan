using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        const int MAX_TRIES = 5;

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
        int randomPicker = rng.Next(hiddenWords.Count);
                
        string randomHiddenWord = hiddenWords[randomPicker];
                
        foreach (char letter in randomHiddenWord)
        {
            Console.Write("_");
        }

        for (int guessCounter = 0; guessCounter < MAX_TRIES; guessCounter++)
        {
            if (guessCounter >= MAX_TRIES)
            {
                Console.WriteLine("GAME OVER!");
                return;
            }

            Console.WriteLine("\nInsert letter: ");
            char userLetter = Convert.ToChar(Console.ReadLine());

            for (int i = 0; i <= randomHiddenWord.Length; i++)
            {
                Console.WriteLine();
            }
        }
    }
}