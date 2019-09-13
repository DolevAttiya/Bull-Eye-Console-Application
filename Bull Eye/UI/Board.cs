using System;
using System.Text;
using System.Collections.Generic;
using Bull_Eye.Logics;
using Bull_Eye.Models;

namespace Bull_Eye.UI
{
    public class Board
    {
        private int m_MaxGuess;

        public Board(int i_MaxGuess)
        {
            m_MaxGuess = i_MaxGuess;
        }

        public void CreateBoard(List<Pin> i_GuessList)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(@"Current board status:

|Pins:  |Result:|
|=======|=======|");

            if (i_GuessList != null)
            {
                foreach (Pin pin in i_GuessList)
                {
                    StringBuilder spacesCreator = new StringBuilder();
                    for (int i = 0; i < pin.Geuss.Length - pin.Result.Length; i++)
                    {
                        spacesCreator.Append(" ");
                    }

                    Console.WriteLine(@"| {0}  |  {1}{2} |
|=======|=======|", pin.Geuss, pin.Result, spacesCreator);
                }

                for (int i = 0; i < m_MaxGuess + 1 - i_GuessList.Count; i++)
                {
                    Console.WriteLine(@"|       |       |
|=======|=======|");
                }
            }
        }
    }
}
