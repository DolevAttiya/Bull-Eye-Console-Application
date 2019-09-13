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
        private const string k_StartPins = "####";
        public const int k_MinRange = 0;
        public const int k_MaxRange = 7;
        public const int k_MaxNumberCount = 4;
        private string m_ComputerSequence;
        private List<Pin> m_UserGeussPinList;
        private int m_maxOfGeuss;

        public GameLogics()
        {

            m_UserGeussPinList = new List<Pin>();
            m_UserGeussPinList.Add(new Pin(k_StartPins, string.Empty));
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
            const char k_Bull = 'V';
            StringBuilder o_VToprint = new StringBuilder();

            foreach (char vCheckChar in i_UserPin)
            {
                if (i_ComputerPin.Contains(vCheckChar) && i_ComputerPin.IndexOf(vCheckChar) == i_UserPin.IndexOf(vCheckChar))
                {
                    o_VToprint.Append(k_Bull);
                }
            }

            return o_VToprint.ToString();
        }

        public string checkCows(string i_ComputerPin, string i_UserPin)
        {
            const char k_cow = 'X';
            StringBuilder o_XToprint = new StringBuilder();

            foreach (char xCheckChar in i_UserPin)
            {
                if (i_ComputerPin.Contains(xCheckChar) && i_ComputerPin.IndexOf(xCheckChar) != i_UserPin.IndexOf(xCheckChar))
                {
                    o_XToprint.Append(k_cow);
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
            const string k_winstring = "VVVV";
            if (i_Result.Equals(k_winstring))
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

        // $G$ CSS-013 (-3) Input parameters names should start with i_PascaleCase.
        public void AddNewGuess(string i_guess)
        {
            string resultOfUserGuess = getResultOnGuess(m_ComputerSequence, i_guess);
            Pin currentGeussFromUser = new Pin(i_guess, resultOfUserGuess);
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
            m_UserGeussPinList.Add(new Pin(k_StartPins, string.Empty));
            setRandomComputerSequence();
        }
    }
}
