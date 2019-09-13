using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bull_Eye.Logics;

namespace Bull_Eye.Models
{
    public class Pin
    {
        private const string k_Quite = "Q";
        private string m_Geuss;
        private string m_Result;

        public Pin(string i_Pin)
        {
            m_Geuss = i_Pin;
        }

        public Pin(string i_Pin, string i_Result)
        {
            m_Geuss = i_Pin;
            m_Result = i_Result;
        }

        public string Geuss
        {
            get
            {
                return m_Geuss;
            }

            set
            {
                m_Geuss = value;
            }
        }

        public string Result
        {
            get
            {
                return m_Result;
            }

            set
            {
                m_Result = value;
            }
        }
        
        public static bool IsValidGeuss(string i_StringToValid)
        {
            bool o_ReturnStatus = true;

            if (i_StringToValid.Length != GameLogics.k_MaxNumberCount)
            {
                if (i_StringToValid.ToUpper().Equals(k_Quite))
                {
                    o_ReturnStatus = true;
                }
                else
                {
                    o_ReturnStatus = false;
                }
            }
            else
            {
                if (!isInRange(i_StringToValid) || !isAllCharactersDiffrent(i_StringToValid))
                {
                    o_ReturnStatus = false;
                }
            }

            return o_ReturnStatus;
        }

        private static bool isInRange(string i_StringToCheckRange)
        {
            bool o_ReturnRangeStatus = true;

            foreach (char validateChar in i_StringToCheckRange)
            {
                if ((int)char.ToUpper(validateChar) - GameLogics.k_StartCharRange < GameLogics.k_MinRange ||
                    (int)char.ToUpper(validateChar) - GameLogics.k_StartCharRange > GameLogics.k_MaxRange)
                {
                    o_ReturnRangeStatus = false;
                }
            }

            return o_ReturnRangeStatus;
        }

        private static bool isAllCharactersDiffrent(string i_StringToCheckDiffrentCharacters)
        {
            bool o_ReturnDiffrentCharacters = true;
            int checkerNumber = 0;

            foreach (char validateChar in i_StringToCheckDiffrentCharacters)
            {
                int bitAtIndex = validateChar - GameLogics.k_StartCharRange;

                if ((checkerNumber & (1 << bitAtIndex)) > 0)
                {
                    o_ReturnDiffrentCharacters = false;
                }

                checkerNumber = checkerNumber | (1 << bitAtIndex);
            }

            return o_ReturnDiffrentCharacters;
        }
    }
}
