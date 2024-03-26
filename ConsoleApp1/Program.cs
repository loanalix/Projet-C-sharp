using Game.Enum;
using Game.Class;
using Drawing;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program 
    {

        static GameManager m_oGameManager;
        static FightManager fightManager;
        static DrawMob m_oDrawMob;
        public static void Main(string[] args)
        {
            m_oGameManager = new GameManager();
            fightManager = new FightManager();
            m_oDrawMob = new DrawMob();
            //while (true)
            //{
            //    Console.CursorVisible = false;
            //    fightManager.FightSteps();
            //}
            m_oGameManager.Game();
        }
    }
}