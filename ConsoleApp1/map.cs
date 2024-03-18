using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class map
    {
        static string loadMap = "";

        public string Map()
        {
            
            loadMap += "------------------------------------";
            return loadMap;
        }

        public string LoadMap()
        {
            StreamReader reader = File.OpenText("../../../map.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                char[] characters = line.ToCharArray();

                for(int i = 0; i < characters.Length - 1; i++) {
                    char currentChar = characters[i];
                    char nextChar = characters[i + 1];
                    
                    
                    if(currentChar == ' ' && nextChar == 'b')
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(currentChar);
                        i++;
                    }
                    else if (currentChar == ' ' || nextChar == ' ')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(currentChar);

                    }
                    else if (currentChar == '-' && nextChar == 'v')
                    {
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(currentChar);
                        i++;
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(currentChar);
                    }
                }

                Console.ResetColor();

                Console.Write(characters[characters.Length - 1]);

                Console.WriteLine();
            }
            return loadMap;
        }

    }
}
