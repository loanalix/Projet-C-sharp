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
        #region Fields
        string m_sName;
        private int m_iPosX;
        private int m_iPosY;
        #endregion

        #region Property
        public int PosX {  get => m_iPosX; set => m_iPosX = value; }
        public int PosY { get => m_iPosY; set => m_iPosY = value; }
        public string Name { get => m_sName; set => m_sName = value; }
        #endregion

        #region Constructor
        public Player()
        {
            m_sName = "player0";
            PosX = 10;
            PosY = 14;
        }
        #endregion

        #region Method
        public int ConvertTo1Dim(int x, int y, int width)
        {
            return y * width + x;
        }
        public bool CheckCollide(Draw oDraw, int iNextPosX, int iNextPosY, string sCurrentMap)
        {
           if (iNextPosY > 0 )
           {
                if (oDraw.GetMap[sCurrentMap][ConvertTo1Dim(iNextPosX, iNextPosY, oDraw.GetWidth)] == 'w'
                || oDraw.GetMap[sCurrentMap][ConvertTo1Dim(iNextPosX, iNextPosY, oDraw.GetWidth)] == 'v'
                || oDraw.GetMap[sCurrentMap][ConvertTo1Dim(iNextPosX, iNextPosY, oDraw.GetWidth)] == 'd')
                {
                    return false;
                }
                else if(oDraw.GetMap[sCurrentMap][ConvertTo1Dim(iNextPosX, iNextPosY, oDraw.GetWidth)] == 's')
                {
                    Console.WriteLine("Oh un combat");
                    return false;
                }
            }
            return true;
        }
        public void MoveUp(Draw oDraw, string sCurrentMap)
        {
            if (CheckCollide(oDraw, PosX, PosY - 1, sCurrentMap))
            {
                PosY--;
            }
        }
        public void MoveDown(Draw oDraw, string sCurrentMap)
        {
            if (CheckCollide(oDraw, PosX, PosY + 1, sCurrentMap))
            {
                PosY++;

            }
            
        }
        public void MoveRight(Draw oDraw, string sCurrentMap)
        {
            if (CheckCollide(oDraw, PosX + 1, PosY, sCurrentMap))
            {
                PosX++;

            }
            
        }
        public void MoveLeft(Draw oDraw, string sCurrentMap)
        {
            if (CheckCollide(oDraw, PosX - 1, PosY, sCurrentMap))
            {
                PosX--;
            }
            
        }
        #endregion

    }
}