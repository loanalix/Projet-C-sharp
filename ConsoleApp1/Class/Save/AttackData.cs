using Game.Class;
using Game.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Game.Class.Attack;

namespace Main.Class.Save
{
    [Serializable]
    public struct AttackData
    {

        [JsonInclude] public string m_sAttackName;
        [JsonInclude] public Types m_cAttackTypes;
        [JsonInclude] public float m_fAttackDamage;
        [JsonInclude] public float m_fResistance;
        [JsonInclude] public int m_iSpeed;
        [JsonInclude] public float m_fHp;
        [JsonInclude] public AttackClass m_attackClass;
        [JsonInclude] public int m_iAttackMana;
        [JsonInclude] public List<Attack> m_lAttacks;

    }
}
