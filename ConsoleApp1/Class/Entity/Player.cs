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
        ItemsManager m_oItemManager;
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
        public Player(ItemsManager oItemsManager, Inventory oInventory)
        {
            m_sName = "player0";
            PosX = 10;
            PosY = 14;
            m_oInventory = oInventory;
            m_oItemManager = oItemsManager;
        }
        #endregion

        #region Method
       
        public bool CheckCollide(int iWidth, int iNextPosX, int iNextPosY, Map oMap)
        {
           if (iNextPosY > 0 )
           {
                if (oMap.GetMap[Maths.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 'w'
                || oMap.GetMap[Maths.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 'v'
                || oMap.GetMap[Maths.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 'd')
                {
                    return false;
                }
                else if(oMap.GetMap[Maths.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 's')
                {
                    Console.WriteLine("Oh un combat");
                    return false;
                }
                else if (Array.Exists(oMap.Object, element => element == Maths.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth))){
                    m_oInventory.AddItem(m_oItemManager.FindItem(Maths.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)));
                    oMap.Object = m_oItemManager.RemoveObject(oMap.Object, Maths.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth));
                    return true;
                }
            }
            return true;
        }
        public void MoveUp(int iWidth, Map oMap)
        {
            if (CheckCollide(iWidth, PosX, PosY - 1, oMap))
            {
                PosY += utils.MoveUpOrLeft();
            }
        }
        public void MoveDown(int iWidth, Map oMap)
        {
            if (CheckCollide(iWidth, PosX, PosY + 1, oMap))
            {
                PosY += utils.MoveDownOrRight();
            }

        }
        public void MoveRight(int iWidth, Map oMap)
        {
            if (CheckCollide(iWidth, PosX + 1, PosY, oMap))
            {
                PosX += utils.MoveDownOrRight();
            }

        }
        public void MoveLeft(int iWidth, Map oMap)
        {
            if (CheckCollide(iWidth, PosX - 1, PosY, oMap))
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