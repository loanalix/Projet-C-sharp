using Main.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Class
{
    public class Player
    {

        string m_sName = "";
        private int m_iPosX;
        private int m_iPosY;

        public int PosX {  get => m_iPosX; private set => m_iPosX = value; }
        public int PosY { get => m_iPosY; private set => m_iPosY = value; }

        public string Name { get => m_sName; set => m_sName = value; }

        public Inventory Inventory {get; private set; }

        public Player()
        {

            m_sName = "player0";
            PosX = 10; 
            PosY = 12;
            Inventory = new Inventory();    

        }
        public int ConvertTo1Dim(int x, int y, int width)
        {
            return y * width + x;
        }
        public bool CheckCollid(Draw oDraw, int iNextPosX, int iNextPosY)
        {
            if (oDraw.GetMap[ConvertTo1Dim(iNextPosX, iNextPosY, 73)] == 'w')
            {
                return false;
            }
            return true;
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

        public void AddItemToInventory(GameObject item) 
        {
            Inventory.AddItem(item);
        }

        public void UseItemFromInventory (int index ) 
        {
            Inventory.UseItem(this, index) ;
        }

    }
}