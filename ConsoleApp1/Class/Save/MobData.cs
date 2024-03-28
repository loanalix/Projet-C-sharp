using Game.Class;
using Game.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Main.Class.Save
{
    [Serializable]
    public struct MobData
    {
        //[JsonInclude] public string m_sName;
        //[JsonInclude] public int m_iMaxHp;
        //[JsonInclude] public float m_iHp;
        //[JsonInclude] public int m_iMana;
        //[JsonInclude] public float m_fDamage;
        //[JsonInclude] public float m_fResistance;
        //[JsonInclude] public int m_iSpeed;
        //[JsonInclude] public int m_iIVSpeed;
        //[JsonInclude] public int m_iFinalSpeed;
        //[JsonInclude] public float m_fPrecision;
        //[JsonInclude] public float m_fExp;
        //[JsonInclude] public int m_iLevel;
        //[JsonInclude] public Types m_cTypes;
        //[JsonInclude] public bool m_bIsStun;

        //[JsonInclude] public string m_sAttackName;
        //[JsonInclude] public Types m_cAttackType;
        //[JsonInclude] public float m_fAttackDamage;
        //[JsonInclude] public int m_iAttackMana;
        [JsonInclude] public List<Mob> m_lAllMobs;

        [JsonInclude] public EnnemyData ennemy;
        [JsonInclude] public HeroesData heroes;
        [JsonInclude] public AttackData attack;
    }
}
