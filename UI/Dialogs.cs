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
        public static int GetNumberOfGeussFromUser()
        {
            int numberOfGuess = 0;
            string strNumberOfGuess;
            bool isValidInput = false;
            const string k_Quit = "Q";

            Console.WriteLine("Please type your max guesses (between {0}-{1}), To exit press q", GameLogics.k_LowestGuess, GameLogics.k_HighestGuess);
            strNumberOfGuess = Console.ReadLine();
            while (!isValidInput)
            {
                if(int.TryParse(strNumberOfGuess, out numberOfGuess))
                {
                    if(GameLogics.k_LowestGuess <= numberOfGuess && numberOfGuess <= GameLogics.k_HighestGuess)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine(@"Invalid Number,
Please type your max guesses(between {0}-{1}), To exit press q", GameLogics.k_LowestGuess, GameLogics.k_HighestGuess);
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
Please type your max guesses(between {0}-{1}), To exit press q", GameLogics.k_LowestGuess, GameLogics.k_HighestGuess);
                    strNumberOfGuess = Console.ReadLine();
                }
            }
  
            return numberOfGuess;
        }

        public static string GetGuessFromUser(int i_MaxNumberCount)
        {
            string spaceString = " ";
            Console.WriteLine("Please type your {0} characters for the next guess {1} - {2} or 'q' to quit", i_MaxNumberCount, (char)(GameLogics.k_StartCharRange + GameLogics.k_MinRange), (char)(GameLogics.k_StartCharRange + GameLogics.k_MaxRange));
            string guessFromUser = Console.ReadLine().Replace(spaceString, string.Empty);

            while (!Pin.IsValidGeuss(guessFromUser))
            {
                Console.WriteLine(@"Wrong input
Please type your {0} characters for the next guess {1} - {2} or 'q' to quit", i_MaxNumberCount, (char)(GameLogics.k_StartCharRange + GameLogics.k_MinRange), (char)(GameLogics.k_StartCharRange + GameLogics.k_MaxRange));
                guessFromUser = Console.ReadLine().Replace(spaceString, string.Empty);
            }
            
            return guessFromUser.ToUpper();
        }

        public static void MessageAfterWin(int i_NumberOfGeuss)
        {
            Console.WriteLine(string.Format(@"You guessed after {0} steps!", i_NumberOfGeuss));
        }

        public static void MessageAfterLost()
        {
            
            Console.WriteLine(string.Format(@"No more guesses allowed. You Lost."));
        }

        public static string CheckIfStartOver()
        {
            const string k_Yes = "y";
            const string k_No = "n";
            const string k_Quit = "Q";
            const string k_Restart = "restart";

            Console.WriteLine("Would you like to start a new game? <Y/N>");
            string answerFromUser = Console.ReadLine().ToLower();

            while(!answerFromUser.Equals(k_Yes) && !answerFromUser.Equals(k_No))
            {
                Console.WriteLine("Wrong answer press <Y/N>, Would you like to start a new game? <Y/N>");
                answerFromUser = Console.ReadLine().ToLower();
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
