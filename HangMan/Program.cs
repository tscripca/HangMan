using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        const int MAX_TRIES = 5;

        var hiddenWords = new List<string>()
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

        //Console.WriteLine(hiddenWords[randomPicker]);
        string randomHiddenWord = hiddenWords[randomPicker];

        //print the "_" for each letter in the random word that the program picked from the list of words
        foreach (char letter in randomHiddenWord)
        {
            Console.Write("_");
        }
        
        //max.of tries is 5
        for (int guessCounter = 0; guessCounter < MAX_TRIES; guessCounter++)
        {
           
            Console.WriteLine("\nInsert letter: ");
            string userLetter = Console.ReadLine();

            if (guessCounter >= MAX_TRIES)
            {
                Console.WriteLine("GAME OVER!");
            }
            for (int i = randomHiddenWord.Length; i >= 0; i++)
            {
                Console.Write(i);
            }
        }
    }
}