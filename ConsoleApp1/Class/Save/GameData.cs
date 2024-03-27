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
    public struct GameData
    {
        [JsonInclude] public PlayerData m_splayer;
        [JsonInclude] public List<MapData> m_lMapsData;
        
        public GameData(PlayerData player, List<MapData> mapsData)
        {
            m_splayer = player;
            m_lMapsData = mapsData;
        }
    }
}
