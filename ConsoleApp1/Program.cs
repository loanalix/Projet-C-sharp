using main.Class;
using Main;
using Main.Class;
using System;
using System.Security.Cryptography.X509Certificates;


namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program 
    {
      
        public static void Main(string[] args)
        {
            
            Map m_oMap = new Map();
            player m_oPlayer = new player();
            Draw m_oDraw = new Draw();  
            InputManager m_oInputManager = new InputManager();
            m_oDraw.LoadMap();
            m_oDraw.DrawMap(m_oPlayer);

            Console.CursorVisible = false;
            bool isRunning = true;


            while (isRunning)
            {
                Console.SetCursorPosition(0, 0);
                m_oInputManager.GetInput(m_oPlayer, m_oDraw);
                m_oDraw.DrawMap(m_oPlayer);

            }



        }
    }
}