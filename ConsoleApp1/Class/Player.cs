using Drawing;

namespace Game.Character
{
    public class Player
    {

        string m_sName;
        private int m_iPosX;
        private int m_iPosY;

        public int PosX {  get => m_iPosX; set => m_iPosX = value; }
        public int PosY { get => m_iPosY; set => m_iPosY = value; }
        public string Name { get => m_sName; set => m_sName = value; }

        public Player()
        {

            m_sName = "player0";
            PosX = 10; 
            PosY = 12;

        }

        public bool CheckCollid(Draw oDraw, int iNextPosX, int iNextPosY)
        {
            if (oDraw.GetMap[Tools.Utils.ConvertTo1Dim(iNextPosX, iNextPosY, 73)] == 'w')
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

    }
}