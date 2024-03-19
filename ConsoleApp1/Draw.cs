using Main;
using Main.Class;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace main.Class 
{
    public class Draw
    {
        public Map m_oMap = new Map();
        private List<char> m_lMap = new List<char>();
        public List<char> GetMap { get => m_lMap; }
        private int iSizeLine;
        

        public void LoadMap()
        {
            StreamReader reader = File.OpenText("../../../map.txt");
            string sizeLine = reader.ReadLine();
            iSizeLine = sizeLine.Length;
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                char[] cChar = line.ToCharArray();
                for (int i = 0; i < cChar.Length; i++)
                {
                    m_lMap.Add(cChar[i]);
                }
            }
        }
        public void DrawMap(player oPlayer)
        {
            for (int i = 0; i < m_lMap.Count; i++)
            {
                switch (m_lMap[i])
                {
                    case 'v':
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 'g':
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    case 'b':
                        Console.BackgroundColor = ConsoleColor.Blue;
                        break;
                    case 'w':
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 'h':
                        Console.BackgroundColor = ConsoleColor.White;
                        break;
                    case 'p':
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        break;
                     case ' ':
                        Console.ResetColor();
                        break;
                    case '/':
                        Console.ResetColor();
                        Console.WriteLine();
                        break;
                
                }
                if (i == oPlayer.ConvertTo1Dim(oPlayer.PosX, oPlayer.PosY, 73))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('*');
                }
                else
                {
                    if(m_lMap[i] != '/')
                    {
                        Console.Write(' ');
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;

            }
        }
    }
}