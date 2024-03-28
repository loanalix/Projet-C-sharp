using Game.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Game.Class.GameManager;

namespace Main.Class.Save
{
    [Serializable]
    public struct GameData
    {
        [JsonInclude] public PlayerData m_splayer;
        [JsonInclude] public List<MapData> m_lMapsData;
        [JsonInclude] public GameState m_eCurrentGameState;
        [JsonInclude] public DrawState m_eCurrentDrawState;

        public GameData(PlayerData player, List<MapData> mapsData, GameState eCurrentGameState, DrawState eCurrentDrawState)
        {
            m_splayer = player;
            m_lMapsData = mapsData;
            m_eCurrentDrawState = eCurrentDrawState;
            m_eCurrentGameState = eCurrentGameState;
        }
    }
}
