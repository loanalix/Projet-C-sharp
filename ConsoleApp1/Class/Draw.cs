
using Game.Map;
using Game.Character;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Drawing
{
    public class Draw
    {
        public Map m_oMap = new Map();


        private Dictionary<string, List<char>> m_dMap = new Dictionary<string, List<char>>();

        public Dictionary<string, List<char>> GetMap { get { return m_dMap; } }


        private int m_iWidth;
        public int GetWidth { get => m_iWidth; }

        private int m_iHeight;
        public int GetHeight { get => m_iHeight; } 
        public void LoadMap(string sFileName, string name)
        {
            
            List<char> map = new List<char>(); 
            StreamReader reader = File.OpenText(sFileName);
            string sizeLine = reader.ReadLine();
            m_iWidth = sizeLine.Length;
            string line;
            int fileHeight = 0;
            while ((line = reader.ReadLine()) != null)
            {
                char[] cChar = line.ToCharArray();
                for (int i = 0; i < cChar.Length; i++)
                {
                    map.Add(cChar[i]);
                }
                fileHeight++;
            }
            m_iHeight = fileHeight;
            m_dMap.Add(name, map);
        }
       
        public void DrawMap(Player oPlayer , List<char> drawMap )
        {
            for (int i = 0; i < drawMap.Count; i++)
            {
                switch (drawMap[i])
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
                    Console.Write('P');
                }
                else
                {
                    if(drawMap[i] != '/')
                    {
                        Console.Write(' ');
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;

            }
        }
    }
}