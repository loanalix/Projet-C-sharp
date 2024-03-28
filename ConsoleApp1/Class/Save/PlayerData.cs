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
        [JsonInclude] public string m_sName;
        [JsonInclude] public int m_iposX;
        [JsonInclude] public int m_iposY;
        [JsonInclude] public InventoryData m_inventory;

        public PlayerData(string name, int posX, int posY, InventoryData inventory)
        {
            m_sName = name;
            m_iposX = posX;
            m_iposY = posY;
            m_inventory = inventory;
        }

    }

}
