using Main.Class;
using Main.Enum;
using System;
using System.Security.Cryptography.X509Certificates;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program 
    {
        public static void Main(string[] args)
        {

            Map m_oMap = new Map();
            Player m_oPlayer = new Player();
            Draw m_oDraw = new Draw();  
            InputManager m_oInputManager = new InputManager();
            m_oDraw.LoadMap("../../../txt/map.txt");
            m_oDraw.DrawMap(m_oPlayer);

            Console.CursorVisible = false;
            bool isRunning = true;

            FightManager fightManager = new FightManager();

            Heroes hTest = new Heroes("Test", 100, 500, 30.0f, 15.0f, 50, Types.Fire);
            Heroes hTest2 = new Heroes("Poke2", 500, 50, 50.0f, 10.0f, 50, Types.Water);
            Heroes hTest3 = new Heroes("Poke3", 500, 50, 50.0f, 10.0f, 50, Types.Dragon);

            while (isRunning)
            {
                Console.SetCursorPosition(0, 0);
                m_oInputManager.GetInput(m_oPlayer, m_oDraw);
                m_oDraw.DrawMap(m_oPlayer);
            }

            //Console.WriteLine("Nom du héro: " + hTest.Name);
            //Console.WriteLine("Hp de " + hTest.Name + ": " + hTest.HP);
            //Console.WriteLine("Mana de " + hTest.Name + ": " + hTest.Mana);
            //Console.WriteLine("Damage de " + hTest.Name + ": " + hTest.Damage);
            //Console.WriteLine("Resistance de " + hTest.Name + ": " + hTest.Resistance);
            //Console.WriteLine("Speed de " + hTest.Name + ": " + hTest.Speed);
            //Console.WriteLine("Precision de " + hTest.Name + ": " + hTest.Precision);
            //Console.WriteLine("Type de " + hTest.Name + ": " + hTest.GetType);

            //hTest.GenerateIVSpeed();
            //hTest2.GenerateIVSpeed();

            //Console.WriteLine("IVSpeed Poke0: " + hTest.IVSpeed);
            //Console.WriteLine("IVSpeed Poke1: " + hTest2.IVSpeed);

            //FightManager.CalculateWhoIsStarting(hTest, hTest2);

            //Attack attack = new Attack("test", Types.Fire, 50f, 20);
            //hTest.AddAttacks("test");
            //hTest.GetAttackProperties("test");
            //hTest.PerformAttackTo(hTest2, "test");

            fightManager.StartFight();

            //Heroes.CalculateWhoIsStarting(hTest, hTest2);

            //test.LoadMap();


            Potion healthPotion = new Potion("Potion de santé", 50);
            Inventory inventory = new Inventory();
            inventory.AddItem(healthPotion);
            inventory.UseItem(0);




        }
    }
}