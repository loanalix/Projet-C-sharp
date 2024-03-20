using Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Character
{
    public class Player
    {

        string m_sName = "";
        private int m_iPosX;
        private int m_iPosY;

        public int PosX {  get => m_iPosX; private set => m_iPosX = value; }
        public int PosY { get => m_iPosY; private set => m_iPosY = value; }
        public string Name { get => m_sName; set => m_sName = value; }

        public Player()
        {

            m_sName = "player0";
            PosX = 10; 
            PosY = 12;

        }
        public int ConvertTo1Dim(int x, int y, int width)
        {
            return y * width + x;
        }
        public bool CheckCollid(Draw oDraw, int iNextPosX, int iNextPosY)
        {
            if (iNextPosX == 0 || iNextPosY == -1) return false;

      
            else if (oDraw.GetMap[ConvertTo1Dim(iNextPosX, iNextPosY, oDraw.GetWidth)] == 'w' 
                || oDraw.GetMap[ConvertTo1Dim(iNextPosX, iNextPosY, oDraw.GetWidth)] == 'v'
                || oDraw.GetMap[ConvertTo1Dim(iNextPosX, iNextPosY, oDraw.GetWidth)] == 'd')
            {
                return false;
            }
            return true;
        }

        public bool ChangeMap(Draw oDraw, int iNextPosX, int iNextPosY)
        {
            if (oDraw.GetMap[ConvertTo1Dim(iNextPosX, iNextPosY, oDraw.GetWidth)] == 'a') return true;
            return false;
        }
        public void MoveUp()
        {
            PosY --;
        }
        public void MoveDown()
        {
            PosY ++;
        }
        public void MoveRight()
        {
            PosX ++;
        }
        public void MoveLeft()
        {
            PosX --;
        }

    }
}