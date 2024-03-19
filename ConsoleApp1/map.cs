using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class map
    {

        private List<char> m_lMap = new List<char>();

        private List<int> m_lSpawnable = new List<int>();
        public List<char> GetMap { get => m_lMap;}

        private int iSizeLine;
        public void LoadMap()
        {
            StreamReader reader = File.OpenText("../../../map.txt");
            string sizeLine = reader.ReadLine();
            iSizeLine = sizeLine.Length;
            string line;
           
            while ((line = reader.ReadLine()) != null)
            {
                char[] cChar= line.ToCharArray();
                for (int i = 0; i < cChar.Length; i++)
                {
                    m_lMap.Add(cChar[i]);
                }
            }
        }
        public void DrawMap()
        {
            for(int i = 0; i< m_lMap.Count; i++)
            {
                switch (m_lMap[i]) {
                    case 'v':
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(' ');
                        break;
                    case 'g':
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(' ');
                        break;
                    case 'b':
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(' ');
                        break;
                    case 'w':
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write(' ');
                        break;
                    case 'h':
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(' ');
                        break;
                    case 'p':
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(' ');
                        break;
                    case '*':
                        //Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('*');
                        break;
                    case ' ':
                        Console.ResetColor();
                        Console.Write(' ');
                        break;
                    case '/':
                        Console.ResetColor();
                        Console.Write('\n');
                        break;
  
                    default:
                        Console.Write(' ');
                        break;


                }
            }
        }
         
        private void UpdateMap(int iIndice, string sMove)
        {
            
            int move = m_lMap.FindIndex(chara => chara == '*');
            int iMovement;
            if (sMove == "down" || sMove == "right")
            {
                iMovement = move + iIndice;
            }
            else
            {
                iMovement = move - iIndice;
            }

            m_lMap.RemoveAt(move);
            m_lMap.Insert(move, 'p');
            m_lMap.RemoveAt(iMovement);
            m_lMap.Insert(iMovement, '*');

        }
        public void Move(string sCharPressed)
        {

            Console.SetCursorPosition(0, 0);
            switch (sCharPressed)
            {
                case "up":
                    UpdateMap(iSizeLine, "up");
                    break;                    
                case "down":
                    UpdateMap(iSizeLine, "down");
                    break;
                case "left":
                    UpdateMap(1, "left");
                    break;
                case "right":
                    UpdateMap(1, "right");
                    break;
            }
        }
    }
}
