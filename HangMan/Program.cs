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
            bool underscoresLeft = true;
            
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
                    char UserKeyInfo = (char)userLetter.KeyChar;

                    Console.WriteLine();
                    Console.Clear();

                    bool currentLetterMatch = false;

                    for (int i = 0; i < randomHiddenWord.Length; i++)
                    {
                        if (UserKeyInfo == randomHiddenWord[i])
                        {
                            if (!currentLetterMatch)
                            {
                                counterLettersGuessedRight++;
                            }
                            displayedLettersList[i] = k;
                            currentLetterMatch = true;
                        }
                        Console.Write(displayedLettersList[i]);
                    }

                    underscoresLeft = (displayedLettersList.Contains(UNDERLINE) == true);

                    if (!displayedLettersList.Contains(k))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Letter doesn't match.");
                    }
                    
                    if (!underscoresLeft)
                    {
                        Console.WriteLine();
                        Console.WriteLine("WINNER! You guessed the word before max tries was reached!");
                        break;
                    }

                    if (counterLettersGuessedRight >= 2)
                    {
                        Console.WriteLine();
                        Console.Write("Maybe you know the word?(Y/N): ");
                        ConsoleKeyInfo waitingInput = Console.ReadKey();
                        char userTry = (char)waitingInput.KeyChar;

                        userTryGuessFullWord = (userTry == USER_CHOICE_YES);
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

                                if (showTriesLeft <= 1)
                                {
                                    Console.WriteLine("GAME OVER!");
                                    break;
                                }
                            }
                        }
                    }
                }

                if (counterLettersGuessedRight == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("You haven't guessed any letters.");
                }

                if (underscoresLeft && showTriesLeft == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("You haven't discovered all the letters yet.");                    
                }               

                Console.WriteLine("Would you like to play again?: Y/N");
                ConsoleKeyInfo userAnswer = Console.ReadKey();
                char willPlayAgain = (char)userAnswer.KeyChar;
                userWantsToPlayAgain = (willPlayAgain == USER_CHOICE_YES);
                displayedLettersList.Clear();
            }
        }
    }
}