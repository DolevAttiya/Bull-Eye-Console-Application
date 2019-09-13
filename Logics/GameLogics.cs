namespace Bull_Eye.Logics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Bull_Eye.UI;
    using Bull_Eye.Models;

    public class GameLogics
    {
        public const int k_LowestGuess = 4;
        public const int k_HighestGuess = 10;
        public const char k_StartCharRange = 'A';
        public const int k_MinRange = 0;
        public const int k_MaxRange = 7;
        public const int k_MaxNumberCount = 4;
        private string m_ComputerSequence;
        private List<Pin> m_UserGeussPinList;
        private int m_maxOfGeuss;

        public GameLogics()
        {
            m_UserGeussPinList = new List<Pin>();
            m_UserGeussPinList.Add(new Pin("####", string.Empty));
        }

        public int MaxOfGeuss
        {
            get
            {
                return m_maxOfGeuss;
            }

            set
            {
                m_maxOfGeuss = value;
            }
        }

        public void setRandomComputerSequence()
        {
            StringBuilder randomString = new StringBuilder();
            char charTorandom = char.MinValue;
            randomString.Append((char)(k_StartCharRange + new Random().Next(k_MinRange, k_MaxRange)));
            for (int CharCount = 1; CharCount < k_MaxNumberCount; CharCount++)
            {
                bool isAllCharsDiffrent = false;

                while (!isAllCharsDiffrent)
                {
                    charTorandom = (char)(k_StartCharRange + new Random().Next(k_MinRange, k_MaxRange));
                    if (randomString.ToString().Contains(charTorandom))
                    {
                        isAllCharsDiffrent = false;
                    }
                    else
                    {
                        isAllCharsDiffrent = true;
                    }
                }

                randomString.Append(charTorandom);
            }

            m_ComputerSequence = randomString.ToString();
        }

        public string checkBulls(string i_ComputerPin, string i_UserPin)
        {
            char Bull = 'V';
            StringBuilder o_VToprint = new StringBuilder();

            foreach (char vCheckChar in i_UserPin)
            {
                if (i_ComputerPin.Contains(vCheckChar) && i_ComputerPin.IndexOf(vCheckChar) == i_UserPin.IndexOf(vCheckChar))
                {
                    o_VToprint.Append(Bull);
                }
            }

            return o_VToprint.ToString();
        }

        public string checkCows(string i_ComputerPin, string i_UserPin)
        {
            char cow = 'X';
            StringBuilder o_XToprint = new StringBuilder();

            foreach (char xCheckChar in i_UserPin)
            {
                if (i_ComputerPin.Contains(xCheckChar) && i_ComputerPin.IndexOf(xCheckChar) != i_UserPin.IndexOf(xCheckChar))
                {
                    o_XToprint.Append(cow);
                }
            }

            return o_XToprint.ToString();
        }

        public string getResultOnGuess(string i_ComputerPin, string i_UserPin)
        {
            string bulls = checkBulls(m_ComputerSequence, i_UserPin);
            string cows = checkCows(m_ComputerSequence, i_UserPin);
            string result = bulls + cows;

            return result;
        }

        public bool isWin(string i_Result)
        {
            bool win = false;
            string winstring = "VVVV";
            if (i_Result.Equals(winstring))
            {
                win = true;
            }

            return win;
        }

        public bool isLost()
        {
            int numberOfGeuss = getAmountOfGuesses();
            bool hasLost = false;
            if (numberOfGeuss == m_maxOfGeuss)
            {
                m_UserGeussPinList.ElementAt(0).Geuss = m_ComputerSequence;
                hasLost = true;
            }

            return hasLost;
        }

        public void AddNewGuess(string i_Guess)
        {
            string resultOfUserGuess = getResultOnGuess(m_ComputerSequence, i_Guess);
            Pin currentGeussFromUser = new Pin(i_Guess, resultOfUserGuess);
            m_UserGeussPinList.Add(currentGeussFromUser);
        }

        public int getAmountOfGuesses()
        {
            return m_UserGeussPinList.Count - 1;
        }

        public Pin getLastGuess()
        {
            return m_UserGeussPinList.ElementAt(m_UserGeussPinList.Count - 1);
        }

        public List<Pin> ListOfGuesses
        {
            get
            {
                return m_UserGeussPinList;
            }
        }

        public void restart()
        {
            m_UserGeussPinList.Clear();
            Ex02.ConsoleUtils.Screen.Clear();
            m_UserGeussPinList.Add(new Pin("####", string.Empty));
            setRandomComputerSequence();
        }
    }
}
