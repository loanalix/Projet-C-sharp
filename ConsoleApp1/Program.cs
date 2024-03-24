using Game.Enum;
using Game.Class;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program 
    {

        //static GameManager m_oGameManager;
        static FightManager fightManager;
        public static void Main(string[] args)
        {
            //m_oGameManager = new GameManager();
            fightManager = new FightManager();
            fightManager.LoadFightMenu();
            fightManager.InitFightStuff(fMob);
            /*
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                fightManager.StartFight();
                fightManager.MenuInput();
            }*/
            //m_oGameManager.Game();
        }
    }
}