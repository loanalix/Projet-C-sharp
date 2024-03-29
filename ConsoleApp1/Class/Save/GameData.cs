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
        //[JsonInclude] public MapData m_map;
        [JsonInclude] public List<MapData> m_lMapsData;
        [JsonInclude] public List<HeroesData> m_lHeroesData;
        [JsonInclude] public List<AttackData> m_lAttackData;
        [JsonInclude] public MapData m_oCurrentMapData;
        [JsonInclude] public GameState m_eCurrentGameState;
        [JsonInclude] public DrawState m_eCurrentDrawState;

        public GameData(PlayerData player, List<MapData> mapsData, List<HeroesData> HeroesData, List<AttackData> AttackData, MapData oCurrentMap, GameState eCurrentGameState, DrawState eCurrentDrawState)
        {
            m_splayer = player;
            m_lMapsData = mapsData;
            m_lHeroesData = HeroesData;
            m_lAttackData = AttackData;
            m_oCurrentMapData = oCurrentMap;
            m_eCurrentDrawState = eCurrentDrawState;
            m_eCurrentGameState = eCurrentGameState;
        }
    }
}
