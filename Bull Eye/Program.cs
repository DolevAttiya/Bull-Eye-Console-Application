using System;
using System.Collections.Generic;
using System.Text;
using Bull_Eye.UI;
using Bull_Eye.Logics;

// $G$ RUL-003 (-20) No submission report attached to the solution

namespace Bull_Eye
{
    public class Program
    {
        public static void Main()
        {
            Game game = new Game();
            game.Start();
            
            Console.WriteLine("Press Enter to close the window");
            Console.ReadLine();
        }
    }
}
