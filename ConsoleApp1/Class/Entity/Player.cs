using Main.Class;
using Main.Class.Manager;
using Main.Class.Save;
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

        Random random;

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
            PosX = 52;  // 4 | 52
            PosY = 1; // 13 | 1
            m_oInventory = oInventory;
            m_oItemManager = oItemsManager;
        }

        public Player(PlayerData player, Inventory oInventory)
        {
            m_sName = player.m_sName;
            PosX = player.m_iposX;
            PosY = player.m_iposY;
            m_oInventory = oInventory;
            
        }
        #endregion

        #region Method
       
        public bool CheckCollide(int iWidth, int iNextPosX, int iNextPosY, Map oMap)
        {
           if (iNextPosY > 0 )
           {    //Ici c'est les collisions avec les murs, bordures, maison, et chemin interdits d'accès
                if (oMap.GetMap[Maths.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 'w'
                || oMap.GetMap[Maths.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 'v'
                || oMap.GetMap[Maths.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 'd'
                || oMap.GetMap[Maths.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 'h')
                {
                    return false;
                }
                //ici c'est ce qui permet de déclencher un combat
                else if(oMap.GetMap[Maths.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 's')
                {
                    GameManager.StartFight();
                    return true;
                    
                }
                //ici c'est ce qui permet de déclencher un dialog
                else if(oMap.GetMap[Maths.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)] == 'q')
                {
                    GameManager.StartDialog();
                    
                    return true;
                }
                else if (Array.Exists(oMap.Object, element => element == Maths.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth))){
                    Music.PlayMusic("../../../Music/Item.wav");
                    m_oInventory.AddItem(m_oItemManager.FindItem(Maths.ConvertTo1Dim(iNextPosX, iNextPosY, iWidth)));
                    //on refait une liste d'objet sans l'objet qui vient d'etre ajouter a l'inventaire
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
                PosY += Maths.MoveUpOrLeft();
            }
        }
        public void MoveDown(int iWidth, Map oMap)
        {
            if (CheckCollide(iWidth, PosX, PosY + 1, oMap))
            {
                PosY += Maths.MoveDownOrRight();
            }

        }
        public void MoveRight(int iWidth, Map oMap)
        {
            if (CheckCollide(iWidth, PosX + 1, PosY, oMap))
            {
                PosX += Maths.MoveDownOrRight();
            }

        }
        public void MoveLeft(int iWidth, Map oMap)
        {
            if (CheckCollide(iWidth, PosX - 1, PosY, oMap))
            {
                PosX += Maths.MoveUpOrLeft();
            }

        }

        public void AddItemToInventory(GameObject item)
        {
            m_oInventory.AddItem(item);
        }

        public void UseItemFromInventory(Mob target, int index)
        {
            m_oInventory.UseItem(this, target, index);
        }

        

        public PlayerData GetPlayerData()
        {
            PlayerData player = new PlayerData(m_sName,PosX, PosY, m_oInventory.GetInventoryData());

            return player;
        }        
        #endregion
    }
}