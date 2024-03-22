using Game.Class;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Game.Class
{
    public class Draw
    {
        #region Fields

        private Dictionary<string, List<char>> m_dMap;
        private List<int> m_lSpawn;
        private int m_iWidth;
        private int m_iHeight;
        #endregion

        #region Property
        public Dictionary<string, List<char>> GetMap { get { return m_dMap; } }
        public List<int> GetSpawn { get => m_lSpawn; }
        public int GetWidth { get => m_iWidth; }
        public int GetHeight { get => m_iHeight; }
        #endregion

        #region Constructor
        public Draw() 
        {
            m_dMap = new Dictionary<string, List<char>>();
            m_lSpawn = new List<int>();
            m_iWidth = 0;
            m_iHeight = 0;
        }
        #endregion

        #region Method
        
        public void DrawMap(Player oPlayer , List<char> drawMap )
        {
            for (int i = m_iWidth; i < drawMap.Count; i++)
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
                    case 's':
                        Console.BackgroundColor = ConsoleColor.Green;
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
        #endregion
    }
}