using Game.Class;
using Game.Enum;
using System;
using System.Security.Cryptography.X509Certificates;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program 
    {
        static Map m_oMap;
        static Player m_oPlayer;
        static Draw m_oDraw;
        static InputManager m_oInputManager;
        static FightManager m_oFightManager;
        public static void Main(string[] args)
        {

            m_oMap = new Map();
            m_oPlayer = new Player();
            m_oDraw = new Draw();  
            
            m_oInputManager = new InputManager();
            
            m_oDraw.LoadMap("../../../txt/map.txt");
            m_oDraw.DrawMap(m_oPlayer);

            Console.CursorVisible = false;
            bool isRunning = true;

            m_oFightManager = new FightManager();

            Mob hTest = new Mob("Test", 100, 500, 30.0f, 15.0f, 50, Types.Fire);

            Mob hTest2 = new Mob("Poke2", 500, 50, 50.0f, 10.0f, 50, Types.Water);
            Mob hTest3 = new Mob("Poke3", 500, 50, 50.0f, 10.0f, 50, Types.Dragon);

            m_oFightManager.StartFight();

            Potion healthPotion = new Potion("Potion de santé", 50);

            m_oPlayer.AddItemToInventory(healthPotion);

            m_oPlayer.UseItemFromInventory(hTest2 ,0);



            PotionMana manaHeal = new PotionMana("Potion de mana", 10);
            AttackBoost attackIncress = new AttackBoost("Boost d'Attaque", 20);


            //Potion potionHealth = new Potion("Potion de santé", 50);
            //Inventory inventory = new Inventory();
            //inventory.AddItem(potionHealth);
            //inventory.UseItem(m_oPlayer, hTest2, 0);

            while (isRunning)
            {
                Console.SetCursorPosition(0, 0);
                m_oInputManager.GetInput(m_oPlayer, m_oDraw);
                m_oDraw.DrawMap(m_oPlayer);
            }






        }
    }
}