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
    public struct HeroesData
    {


        [JsonInclude] public Attack m_cAttack;
        [JsonInclude] public string m_sAtackName;
        [JsonInclude] public Types m_cAttackType;
        [JsonInclude] public float m_fAttackDamage;
        [JsonInclude] public int m_iAttackMana;
        [JsonInclude] public float m_fAttackResistance;
        [JsonInclude] public int m_iAttackSpeed;
        [JsonInclude] public float m_fAttackHP;
        [JsonInclude] public Attack.AttackClass GetHeroAttackClass;
        [JsonInclude] public Attack m_SpecialAttacks;
        [JsonInclude] public Attack m_StunAttacks;
        [JsonInclude] public Attack m_SpellAttacks;
        [JsonInclude] public Attack m_NormalAttacks;

        [JsonInclude] public string m_sName;
        [JsonInclude] public Types m_cType;
        [JsonInclude] public float m_fDamage;
        [JsonInclude] public float m_fResistance;
        [JsonInclude] public float m_iHp;
        [JsonInclude] public int m_iSpeed;
        [JsonInclude] public int m_iMana;
    }
}
