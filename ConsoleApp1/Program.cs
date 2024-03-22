using Game.Map;
using Game.Inventory;
using Game.Entity;
using Game.Character;
using Game.InputController;
using Game.FightController;
using Game.Enum;
using Game.Brewing;
using Drawing;
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