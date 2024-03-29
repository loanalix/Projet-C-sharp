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
    public struct InventoryData
    {
        #region Field
        [JsonInclude] public List<GameObject> m_lItems;
        #endregion

        #region Constructor
        public InventoryData(List<GameObject> items)
        {
            m_lItems = items;
        }
        #endregion
    }


}
