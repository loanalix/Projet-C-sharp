using Game.Class;
using Tools;

namespace Game.Class
{
    public class Player
    {
        #region Fields
        string m_sName;
        private int m_iPosX;
        private int m_iPosY;
        Inventory m_oInventory;
        FightManager m_fightManager;
        private Utils utils;
        private List<Heroes> m_lPlayerHeroes = new List<Heroes>();
        #endregion

        #region Property
        public int PosX { get => m_iPosX; set => m_iPosX = value; }
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
            utils = new Utils();
            m_fightManager = new FightManager();
        }
        #endregion

        #region Method
        public bool CheckCollide(int iWidth, int iNextPosX, int iNextPosY, List<char> lCurrentMap)
        {
            if (iNextPosY > 0)
            {
                if (lCurrentMap[utils.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 'w'
                || lCurrentMap[utils.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 'v'
                || lCurrentMap[utils.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 'd')
                {
                    return false;
                }
                else if (lCurrentMap[utils.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 's')
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
                PosY += utils.MoveUpOrLeft();
            }
        }
        public void MoveDown(int iWidth, List<char> lCurrentMap)
        {
            if (CheckCollide(iWidth, PosX, PosY + 1, lCurrentMap))
            {
                PosY += utils.MoveDownOrRight();
            }

        }
        public void MoveRight(int iWidth, List<char> lCurrentMap)
        {
            if (CheckCollide(iWidth, PosX + 1, PosY, lCurrentMap))
            {
                PosX += utils.MoveDownOrRight();
            }

        }
        public void MoveLeft(int iWidth, List<char> lCurrentMap)
        {
            if (CheckCollide(iWidth, PosX - 1, PosY, lCurrentMap))
            {
                PosX += utils.MoveUpOrLeft();
            }

        }
        #endregion

        public void AddItemToInventory(GameObject item)
        {
            m_oInventory.AddItem(item);
        }

        public void UseItemFromInventory(Mob target, int index)
        {
            m_oInventory.UseItem(this, target, index);
        }

        public void InitHeroes()
        {
            for(int i = 0; i < Heroes.GetHeroes.Count; i++)
            {
                m_lPlayerHeroes.Add(Heroes.GetHeroes[i]);
            }
        }

    }
}