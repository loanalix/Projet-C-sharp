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
            Heroes dialga = new Heroes("Dialga", 1200, 200, 75f, 70f, 70, Types.Grass); // Tout ça à yonk si vous voulez
            Heroes zekrom = new Heroes("Zekrom", 1300, 210, 80f, 76f, 45, Types.Fire);
            Heroes darkrai = new Heroes("Darkrai", 850, 90, 100f, 45f, 45, Types.Dragon);
            Ennemy pikachu = new Ennemy("Pikachu", 150, 20, 2f, 0f, 100, Types.Flying);
            Ennemy bulbizarre = new Ennemy("Bulbizarre", 150, 20, 2f, 0f, 100, Types.Grass);
            Ennemy salameche = new Ennemy("Salameche", 150, 20, 2f, 0f, 100, Types.Fire);
            Ennemy rayquaza = new Ennemy("Rayquaza", 150, 20, 2f, 0f, 100, Types.Dragon);
            Ennemy artikodin = new Ennemy("Artikodin", 150, 20, 2f, 0f, 100, Types.Flying);
            Ennemy giratina = new Ennemy("Giratina", 150, 20, 2f, 0f, 100, Types.Flying);
            Ennemy mewtwo = new Ennemy("Mewtwo", 150, 20, 2f, 0f, 100, Types.Grass);
            Ennemy lunala = new Ennemy("Lunala", 150, 20, 2f, 0f, 100, Types.Flying);
            Ennemy groudon = new Ennemy("Groudon", 150, 20, 2f, 0f, 100, Types.Fire);
            fightManager.LoadFightMenu();
            fightManager.LoadFight();
            //while (true)
            //{
            //    Console.CursorVisible = false;
            //    fightManager.FightSteps();
            //}

            


            //string Pokemon = "../../../txt/darceaufeu.txt";
            //string Pikachu = "../../../txt/pikachu.txt"; 
            //m_oDrawMob.LoadMob(Pikachu);
            //m_oDrawMob.LoadMob(Pokemon);

 
            //m_oDrawMob.MobDraw(Pikachu, Pokemon);
            //m_oDrawMob.SaveMob(Pikachu);


            m_oGameManager.Game();







         

        }
    }
}