using Game.Class;
using Game.Enum;
using System;
using System.Security.Cryptography.X509Certificates;
using Main.Class;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program 
    {

        static GameManager m_oGameManager;
        public static void Main(string[] args)
        {
            m_oGameManager = new GameManager();
            m_oGameManager.Game();
        }
    }
}