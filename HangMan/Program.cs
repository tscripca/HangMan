using System;
using System.Collections.Generic;

namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            const char USER_CHOICE_YES = 'y';
            const char UNDERLINE = '_';
            bool userWantsToPlayAgain = true;
            bool userTryGuessFullWord = true;
            string userKnowsTheWord = "";
            int showTriesLeft = 0;

            List<char> displayedLettersList = new List<char>();

            List<string> hiddenWords = new List<string>()
            {
                "foot",
                "row",
                "airplane",
                "eagle",
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

                int counterLettersGuessedRight = 0;

                for (int guessCount = 0; guessCount < maximumTries; guessCount++)
                {
                    showTriesLeft = maximumTries - guessCount;

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
                            if (!currentLetterMatch)
                            {
                                counterLettersGuessedRight++;
                            }
                            displayedLettersList[i] = userLetter.KeyChar;

                            currentLetterMatch = true;
                        }
                        Console.Write(displayedLettersList[i]);
                    }

                    if (!displayedLettersList.Contains(UNDERLINE))
                    {
                        Console.WriteLine();
                        Console.WriteLine("WINNER! You guessed the word before max tries was reached!");
                        break;
                    }

                    if (counterLettersGuessedRight >= 2)
                    {
                        if (!displayedLettersList.Contains(userLetter.KeyChar))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Letter doesn't match.");
                        }

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

                    if (showTriesLeft <= 1 && !displayedLettersList.Contains(userLetter.KeyChar))
                    {
                        Console.WriteLine();
                        Console.WriteLine("You didn't guess any letter.");
                        break;
                    }

                    if (showTriesLeft <= 1 && displayedLettersList.Contains(UNDERLINE))
                    {
                        Console.WriteLine();
                        Console.WriteLine("You didn't guess all the letters.");

                        Console.WriteLine();
                        Console.Write("But still maybe you want to guess the word?(Y/N): ");
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
                            }
                            else
                            {
                                Console.WriteLine("GAME OVER! That's not the word");
                            }
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