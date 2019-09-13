using System;
using System.Text;
using System.Collections.Generic;
using Bull_Eye.Logics;
using Bull_Eye.Models;

namespace Bull_Eye.UI
{
   internal class Game
    {

        private const string k_Quit = "Q";
        private const string k_Restart = "restart";
        private GameLogics m_GameLogics;
        public const int k_MaxNumberCount = 4;
        private Board m_Board;

        public Game()
        {
            m_GameLogics = new GameLogics();
            m_GameLogics.MaxOfGeuss = Dialogs.GetNumberOfGeussFromUser();
            m_Board = new Board(m_GameLogics.MaxOfGeuss);
        }

        public void Start()
        {
            m_Board.CreateBoard(m_GameLogics.ListOfGuesses);
            m_GameLogics.setRandomComputerSequence();
            string guessInputFromUser = string.Empty;

            while (!guessInputFromUser.Equals(k_Quit) && m_GameLogics.MaxOfGeuss != 0)
            {
                if (guessInputFromUser.ToLower().Equals(k_Restart))
                {
                    m_GameLogics.restart();
                    m_GameLogics.MaxOfGeuss = Dialogs.GetNumberOfGeussFromUser();
                    m_Board = new Board(m_GameLogics.MaxOfGeuss);
                    m_Board.CreateBoard(m_GameLogics.ListOfGuesses);
                }

                guessInputFromUser = Dialogs.GetGuessFromUser(k_MaxNumberCount);
                if (!guessInputFromUser.Equals(k_Quit))
                {
                    m_GameLogics.AddNewGuess(guessInputFromUser);
                    m_Board.CreateBoard(m_GameLogics.ListOfGuesses);

                    if (m_GameLogics.isWin(m_GameLogics.getLastGuess().Result))
                    {
                        Dialogs.MessageAfterWin(m_GameLogics.getAmountOfGuesses());
                        guessInputFromUser = Dialogs.CheckIfStartOver();
                    }
                    else if (m_GameLogics.isLost())
                    {
                        m_Board.CreateBoard(m_GameLogics.ListOfGuesses);
                        Dialogs.MessageAfterLost();
                        guessInputFromUser = Dialogs.CheckIfStartOver();
                    }
                }
            }

            if (guessInputFromUser.Equals(k_Restart))
            {
                m_GameLogics.restart();
            }
            else if (guessInputFromUser.ToUpper().Equals(k_Quit) || m_GameLogics.MaxOfGeuss == 0)
            {
                Console.WriteLine("Goodbye...");
            }
        }
    }
}
