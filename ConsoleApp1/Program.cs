using Main;
using System;
using System.Security.Cryptography.X509Certificates;


namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program 
    { 
        static void Main(string[] args)
        {

            map test = new map();
            test.LoadMap();
            test.DrawMap();

            bool isRunning = true;

            ConsoleKeyInfo input;
            

            while (isRunning)
            {

                input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.UpArrow)
                {
                    test.Move("up");
                }
                else if (input.Key == ConsoleKey.DownArrow)
                {
                    test.Move("down");
                }
                else if (input.Key == ConsoleKey.RightArrow)
                {
                    test.Move("right");

                }
                else if (input.Key == ConsoleKey.LeftArrow)
                {
                    test.Move("left");
                }
                test.DrawMap();

            }



        }
    }
}