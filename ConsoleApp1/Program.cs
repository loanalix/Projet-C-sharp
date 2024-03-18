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

            map test = new map();

            Heroes hTest = new Heroes("Fire-pokemon", 100, 500, 30.0f, 15.0f, 2.0f, 1.0f, Types.Fire);

            Console.WriteLine("Nom du héro: " + hTest.Name);
            Console.WriteLine("Hp de " + hTest.Name + ": " + hTest.HP);
            Console.WriteLine("Mana de " + hTest.Name + ": " + hTest.Mana);
            Console.WriteLine("Damage de " + hTest.Name + ": " + hTest.Damage);
            Console.WriteLine("Resistance de " + hTest.Name + ": " + hTest.Resistance);
            Console.WriteLine("Speed de " + hTest.Name + ": " + hTest.Speed);
            Console.WriteLine("Precision de " + hTest.Name + ": " + hTest.Precision);
            Console.WriteLine("Type de " + hTest.Name + ": " + hTest.GetType);

            test.LoadMap();


        }
    }
}