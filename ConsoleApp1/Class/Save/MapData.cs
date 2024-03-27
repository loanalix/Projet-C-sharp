using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Main.Class.Save
{
    [Serializable]
    public struct MapData
    {
        [JsonInclude] public List<char> m_lMap;
        [JsonInclude] public List<int> m_lSpawn;
        [JsonInclude] public string m_sName;
        [JsonInclude] public int m_iWidth;
        [JsonInclude] public int m_iHeight;
        [JsonInclude] public int[] m_iObjects;
        
    }
}
