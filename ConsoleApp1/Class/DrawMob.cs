﻿using Game.Class;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Game.Class
{
    public class DrawMob
    {
        private int m_iWidth;
        private int m_iHeight;
        private int origRow; 
        private int origCol;

        private List<string> mapLine;

        public List<string> Line { get { return mapLine; } }
        public int GetWidth { get => m_iWidth; }
        public int GetHeight { get => m_iHeight; }

        public void LoadMob(string sFileName)
        {
            mapLine = new List<string>();

            StreamReader reader = File.OpenText(sFileName);
            string line;
            int fileHeight = 0;

            while ((line = reader.ReadLine()) != null)
            {
                m_iWidth = line.Length;
                mapLine.Add(line);
                fileHeight++;
            }
             
            reader.Close();
        }

        public void MobDraw(string asciiArt)
        {
            origRow = Console.CursorLeft; 
            for (int i = 0; i < mapLine.Count / 2 ; i++)
            {
                Console.WriteLine(mapLine[i]);
            }




        }
    }
}