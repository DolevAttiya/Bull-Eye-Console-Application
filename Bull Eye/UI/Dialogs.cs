using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bull_Eye.Models;
using Bull_Eye.Logics;

namespace Bull_Eye.UI
{
    internal class Dialogs
    {
        private const string k_Yes = "Y";
        private const string k_No = "N";
        private const string k_Quit = "Q";
        private const string k_Restart = "restart";
        public static int GetNumberOfGeussFromUser()
        {
            int numberOfGuess = 0;
            string strNumberOfGuess;
            bool isValidInput = false;

            Console.WriteLine("Please type your max guesses (between {0}-{1}), To exit press {2}", GameLogics.k_LowestGuess, GameLogics.k_HighestGuess, k_Quit);
            strNumberOfGuess = Console.ReadLine();
            while (!isValidInput)
            {
                if (int.TryParse(strNumberOfGuess, out numberOfGuess))
                {
                    if (GameLogics.k_LowestGuess <= numberOfGuess && numberOfGuess <= GameLogics.k_HighestGuess)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine(@"Invalid Number,
Please type your max guesses(between {0}-{1}), To exit press {2}", GameLogics.k_LowestGuess, GameLogics.k_HighestGuess, k_Quit);
                        strNumberOfGuess = Console.ReadLine();
                    }
                }
                else if (strNumberOfGuess.ToUpper().Equals(k_Quit))
                {
                    isValidInput = true;
                    numberOfGuess = 0;
                }
                else
                {
                    Console.WriteLine(@"Invalid Number,
Please type your max guesses(between {0}-{1}), To exit press {2}", GameLogics.k_LowestGuess, GameLogics.k_HighestGuess, k_Quit);
                    strNumberOfGuess = Console.ReadLine();
                }
            }

            return numberOfGuess;
        }

        public static string GetGuessFromUser(int i_MaxNumberCount)
        {
            string spaceString = " ";
            Console.WriteLine("Please type your {0} characters for the next guess {1} - {2} or {3} to quit", i_MaxNumberCount, (char)(GameLogics.k_StartCharRange + GameLogics.k_MinRange), (char)(GameLogics.k_StartCharRange + GameLogics.k_MaxRange), k_Quit);
            string guessFromUser = Console.ReadLine().Replace(spaceString, string.Empty);

            while (!Pin.IsValidGeuss(guessFromUser))
            {
                Console.WriteLine(@"Wrong input
Please type your {0} characters for the next guess {1} - {2} or {3} to quit", i_MaxNumberCount, (char)(GameLogics.k_StartCharRange + GameLogics.k_MinRange), (char)(GameLogics.k_StartCharRange + GameLogics.k_MaxRange), k_Quit);
                guessFromUser = Console.ReadLine().Replace(spaceString, string.Empty);
            }

            return guessFromUser.ToUpper();
        }

        // $G$ CSS-013 (-3) Input parameters names should start with i_PascaleCase.
        public static void MessageAfterWin(int i_NumberOfGeuss)
        {
            Console.WriteLine(string.Format(@"You guessed after {0} steps!", i_NumberOfGeuss));
        }

        public static void MessageAfterLost()
        {
            Console.WriteLine(string.Format(@"No more guesses allowed. You Lost."));
        }

        // $G$ CSS-999 (-3) You should have used constants here.
        public static string CheckIfStartOver()
        {
            Console.WriteLine("Would you like to start a new game? <{0}/{1}>", k_Yes, k_No);
            string answerFromUser = Console.ReadLine().ToUpper();

            while (!answerFromUser.Equals(k_Yes) && !answerFromUser.Equals(k_No))
            {
                Console.WriteLine("Wrong answer press <{0}/{1}>, Would you like to start a new game? <{0}/{1}>", k_Yes, k_No);
                answerFromUser = Console.ReadLine().ToUpper();
            }

            if (answerFromUser.Equals(k_Yes))
            {
                answerFromUser = k_Restart;
            }
            else if (answerFromUser.Equals(k_No))
            {
                answerFromUser = k_Quit;
            }

            return answerFromUser;
        }
    }
}
