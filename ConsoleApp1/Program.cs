using Main.Class;
using Main.Enum;
using System;
using System.Security.Cryptography.X509Certificates;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program 
    { 
        static void Main(string[] args)
        {

            // map test = new map();

            //Heroes hTest = new Heroes("Poke0", 100, 500, 30.0f, 15.0f, 50, 1.0f, Types.Fire);
            //Heroes hTest2 = new Heroes("Poke1", 500, 50, 50.0f, 10.0f, 50, 2.0f, Types.Water);

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

            //Heroes.CalculateWhoIsStarting(hTest, hTest2);

            //test.LoadMap();


            Potion healthPotion = new Potion("Potion de santé", 50);
            Inventory inventory = new Inventory();
            inventory.AddItem(healthPotion);
            inventory.UseItem(0);


            Console.ReadLine();


        }
    }
}