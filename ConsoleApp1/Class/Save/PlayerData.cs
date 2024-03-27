using Game.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Main.Class.Save
{
    [Serializable]
    public struct PlayerData
    {
        [JsonInclude] public int m_iposX;
        [JsonInclude] int m_iposY;
        [JsonInclude] public List<Heroes> m_lPlayerHeroes;
        [JsonInclude] public InventoryData m_inventory;

        public PlayerData(int posX, int posY, List<Heroes> lPlayerHeroes, InventoryData inventory)
        {
            m_iposX = posX;
            m_iposY = posY;
            m_lPlayerHeroes = lPlayerHeroes;
            m_inventory = inventory;
        }
        public PlayerData GetData()
        {
            PlayerData player = new PlayerData();
            return player;
        }
    }

}
