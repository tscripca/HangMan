﻿using System;
using System.Collections.Generic;

namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MINIMUM_TRIES = 2;
            const char USER_CHOICE_YES = 'y';
            const char UNDERLINE = '_';
            bool userWantsToPlayAgain = true;
            bool userTryGuessFullWord = true;
            string userKnowsTheWord = " ";

            List<char> displayedLettersList = new List<char>();

            List<string> hiddenWords = new List<string>()
            {
                "row",
                /*"airplane",
                "parachute",
                "sternocleidomastoid",
                "netherlands",
                "carbonara",
                "eagle",
                "Hippopotomonstrosesquippedaliophobia",
                "massachusetts",*/
            };

            Random rng = new Random();

            while (userWantsToPlayAgain)
            {
                int randomListIndex = rng.Next(hiddenWords.Count);
                string randomHiddenWord = hiddenWords[randomListIndex];
                int maximumTries = randomHiddenWord.Length / 2;     //change the number of tries based on the word's length.                         

                Console.Clear();

                for (int j = 0; j < randomHiddenWord.Length; j++)
                {
                    displayedLettersList.Add(UNDERLINE);
                    Console.Write(displayedLettersList[j]);
                }

                if (maximumTries <= 1)
                {
                    maximumTries = MINIMUM_TRIES;
                }

                for (int guessCount = 0; guessCount < maximumTries; guessCount++)
                {
                    int showTriesLeft = maximumTries - guessCount;

                    Console.WriteLine();
                    Console.WriteLine($"{showTriesLeft} attempts left");
                    Console.WriteLine();
                    Console.Write("Insert letter: \n");
                    ConsoleKeyInfo userLetter = Console.ReadKey();

                    Console.WriteLine();
                    Console.Clear();

                    for (int i = 0; i < randomHiddenWord.Length; i++)
                    {
                        if (userLetter.KeyChar == randomHiddenWord[i])
                        {
                            displayedLettersList[i] = userLetter.KeyChar;
                        }

                        Console.Write(displayedLettersList[i]);
                    }

                    //ask the user only after he guessed at least one letter
                    if (displayedLettersList.Contains(userLetter.KeyChar))
                    {
                        Console.WriteLine();
                        Console.Write("Maybe you already know the word?(Y/N): ");
                        ConsoleKeyInfo waitingInput = Console.ReadKey();

                        userTryGuessFullWord = (waitingInput.KeyChar == USER_CHOICE_YES);
                        Console.WriteLine();

                        if (userTryGuessFullWord)
                        {
                            Console.WriteLine("Type the word: ");
                            userKnowsTheWord = Console.ReadLine().ToLower().Trim();

                            if (userKnowsTheWord == randomHiddenWord)
                            {
                                Console.Clear();
                                Console.WriteLine(randomHiddenWord);
                                Console.WriteLine("WINNER!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Wrong!");
                            }
                        }

                    }

                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Your letter doesn't match.");
                        continue;
                    }

                }

                if (displayedLettersList.Contains(UNDERLINE))
                {
                    Console.WriteLine("GAME OVER!");
                    Console.WriteLine($"The word was: {randomHiddenWord}");
                    break;
                }

                Console.WriteLine();
                Console.WriteLine("Would you like to play again?: Y/N");
                ConsoleKeyInfo userAnswer = Console.ReadKey();
                userWantsToPlayAgain = (userAnswer.KeyChar == USER_CHOICE_YES);
                displayedLettersList.Clear();
            }
        }
    }
}