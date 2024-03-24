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
            Heroes h1 = new Heroes("apagnan", 500, 125, 50f, 15f, 100, Types.Grass);
            Ennemy e1 = new Ennemy("ennemy", 150, 20, 2f, 0f, 100, Types.Water);
            fightManager.LoadFightMenu();
            fightManager.InitFightStuff(h1);
            fightManager.InitFightStuff(e1);
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                fightManager.FightSteps();
            }
            //m_oGameManager.Game();
        }
    }
}