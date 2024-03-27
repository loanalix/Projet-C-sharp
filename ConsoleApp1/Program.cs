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

            


            string Pokemon = "../../../txt/darceaufeu.txt";
            string Pikachu = "../../../txt/pikachu.txt"; 
            m_oDrawMob.LoadMob(Pikachu);
            m_oDrawMob.LoadMob(Pokemon);

 
           // m_oDrawMob.MobDraw(Pikachu, Pokemon);



            m_oGameManager.Game();
        }
    }
}