using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Class;

namespace Game.Class
{
    public class Player
    {
        #region Fields
        string m_sName;
        private int m_iPosX;
        private int m_iPosY;
        Inventory m_oInventory;
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
            m_oInventory = new Inventory();
        }
        #endregion

        #region Method
        public int ConvertTo1Dim(int x, int y, int width)
        {
            return y * width + x;
        }
        public bool CheckCollide(int iWidth, int iNextPosX, int iNextPosY, List<char> lCurrentMap)
        {
           if (iNextPosY > 0 )
           {
                if (lCurrentMap[ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 'w'
                || lCurrentMap[ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 'v'
                || lCurrentMap[ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 'd')
                {
                    return false;
                }
                else if(lCurrentMap[ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 's')
                {
                    Console.WriteLine("Oh un combat");
                    return false;
                }
            }
            return true;
        }
        public void MoveUp(int iWidth, List<char> lCurrentMap)
        {
            if (CheckCollide(iWidth, PosX, PosY - 1, lCurrentMap))
            {
                PosY--;
            }
        }
        public void MoveDown(int iWidth, List<char> lCurrentMap)
        {
            if (CheckCollide(iWidth, PosX, PosY + 1, lCurrentMap))
            {
                PosY++;

            }
            
        }
        public void MoveRight(int iWidth, List<char> lCurrentMap)
        {
            if (CheckCollide(iWidth, PosX + 1, PosY, lCurrentMap))
            {
                PosX++;

            }
            
        }
        public void MoveLeft(int iWidth, List<char> lCurrentMap)
        {
            if (CheckCollide(iWidth, PosX - 1, PosY, lCurrentMap))
            {
                PosX--;
            }
            
        }
        #endregion

        public void AddItemToInventory(GameObject item) 
        {
            m_oInventory.AddItem(item);
        }

        public void UseItemFromInventory (Mob target ,int index ) 
        {
            m_oInventory.UseItem(this, target, index) ;
        }

    }
}