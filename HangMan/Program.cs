using System;

namespace HangMan // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int THREE_LETTERS_WORD = 2;
            char underline = '_';
            bool playAgain = true;
            string userKnowsTheWord = " ";
            int showTriesLeft = 0;

            List<char> guessedLetter = new List<char>();

            List<string> hiddenWords = new List<string>()
            {
                "row",  
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

                //add  1 more try for words that are less thatn 3 letters long.
                              

                for (int guessCounter = 0; guessCounter < maximumTries; guessCounter++)
                {
                    if (randomHiddenWord.Length <= 3)
                    {
                        maximumTries = THREE_LETTERS_WORD;
                        showTriesLeft = THREE_LETTERS_WORD - guessCounter;
                    }
                    else
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

                            guessedLetter[i] = userLetter.KeyChar; //here is where the underline becomes the guessed letter.    

                        }

                        Console.Write(guessedLetter[i]);
                    }

                    //ask the user if he knows the word after he already guessed at least 1 letter.
                    if (randomHiddenWord.Contains(userLetter.KeyChar))
                    {
                        Console.WriteLine();
                        Console.Write("Maybe you already know the word?(Y/N): ");
                        ConsoleKeyInfo waitingInput = Console.ReadKey();

                        bool userTry = true;
                        userTry = (waitingInput.KeyChar == 'y');

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
                            else
                            {
                                Console.WriteLine("Wrong!");
                            }
                        }
                    }
                }
                Console.WriteLine();                
                Console.WriteLine("Would you like to play again?: Y/N");
                ConsoleKeyInfo userAnswer = Console.ReadKey();
                playAgain = (userAnswer.KeyChar == 'y');
                guessedLetter.Clear();
            }
        }
    }
}

