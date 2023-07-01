using System;

namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MINIMUM_TRIES = 2;
            const char USER_CHOICE_YES = 'y';
            const char USER_CHOICE_NO = 'n';
            char underline = '_';
            bool playAgain = true;
            bool userTry = true;
            string userKnowsTheWord = " ";
            int showTriesLeft = 0;

            List<char> guessedLetter = new List<char>();

            List<string> hiddenWords = new List<string>()
            {
                "row",
                "airplane",
                "parachute",
                "sternocleidomastoid",
                "netherlands",
                "massachusetts",
                "carbonara",
                "eagle",
                "Hippopotomonstrosesquippedaliophobia",
            };

            Random rng = new Random();

            while (playAgain)
            {
                int randomPicker = rng.Next(hiddenWords.Count);
                string randomHiddenWord = hiddenWords[randomPicker];
                int maximumTries = randomHiddenWord.Length / 2;     //change the number of tries based on the word's length.                         

                Console.Clear();

                for (int j = 0; j < randomHiddenWord.Length; j++)
                {
                    guessedLetter.Add(underline);
                    Console.Write(guessedLetter[j]);
                }

                if (maximumTries <= 1)
                {
                    maximumTries = MINIMUM_TRIES;
                }

                for (int guessCounter = 0; guessCounter < maximumTries; guessCounter++)
                {
                    showTriesLeft = maximumTries - guessCounter;

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
                            guessedLetter[i] = userLetter.KeyChar;
                        }

                        Console.Write(guessedLetter[i]);

                        if (guessedLetter[i] == randomHiddenWord[i])
                        {
                            Console.WriteLine();
                            Console.Write("Maybe you already know the word?(Y/N): ");
                            ConsoleKeyInfo waitingInput = Console.ReadKey();

                            userTry = (waitingInput.KeyChar == USER_CHOICE_YES);

                            if (userTry)
                            {
                                Console.Clear();
                                Console.WriteLine("Type the word: ");
                                userKnowsTheWord = Console.ReadLine().ToLower().Trim();

                                if (userKnowsTheWord == randomHiddenWord)
                                {
                                    Console.Clear();
                                    Console.WriteLine(randomHiddenWord);
                                    Console.WriteLine("WINNER!");
                                    break;
                                }

                                if (userKnowsTheWord != randomHiddenWord)
                                {
                                    Console.WriteLine("Wrong!");
                                }
                            }
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Would you like to play again?: Y/N");
                ConsoleKeyInfo userAnswer = Console.ReadKey();
                playAgain = (userAnswer.KeyChar == USER_CHOICE_YES);
                guessedLetter.Clear();
            }
        }
    }
}

