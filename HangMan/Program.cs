using System;
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
            string userKnowsTheWord = "";
            int counterLettersGuessedRight = 0;

            List<char> displayedLettersList = new List<char>();

            List<string> hiddenWords = new List<string>()
            {
                "airplane",
                "eagle",
                "row",
                "parachute",
                "sternocleidomastoid",
                "netherlands",
                "carbonara",
                "massachusetts",
            };

            Random rng = new Random();

            while (userWantsToPlayAgain)
            {
                int randomListIndex = rng.Next(hiddenWords.Count);
                string randomHiddenWord = hiddenWords[randomListIndex];
                int maximumTries = randomHiddenWord.Length;

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

                    bool currentLetterMatch = false;

                    for (int i = 0; i < randomHiddenWord.Length; i++)
                    {
                        if (userLetter.KeyChar == randomHiddenWord[i])
                        {
                            currentLetterMatch = true;
                            displayedLettersList[i] = userLetter.KeyChar;

                            if (!currentLetterMatch)
                            {
                                counterLettersGuessedRight++;
                            }

                        }
                        Console.Write(displayedLettersList[i]);
                    }

                    if (!displayedLettersList.Contains(UNDERLINE))
                    {
                        Console.WriteLine();
                        Console.WriteLine("WINNER! You guessed the word before max tries was reached!");
                        break;
                    }

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
                                Console.WriteLine("That's not the word");
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Letter doesn't match.");
                    }
                }

                if (displayedLettersList.Contains(UNDERLINE))
                {
                    Console.WriteLine();
                    Console.WriteLine("You didn't guess all the letters.");

                    Console.WriteLine();
                    Console.Write("Still maybe you know the word?(Y/N): ");
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
                            Console.WriteLine("GAME OVER! That's not the word");
                        }
                    }
                }

                Console.WriteLine("Would you like to play again?: Y/N");
                ConsoleKeyInfo userAnswer = Console.ReadKey();
                userWantsToPlayAgain = (userAnswer.KeyChar == USER_CHOICE_YES);
                displayedLettersList.Clear();

            }
        }
    }
}