using Game.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Class
{
    public class Attack
    {

        #region Fields

        public static List<Attack> Attacks = new List<Attack>();

        public enum AttackType { Attack = 0, Spell = 1, Stun = 2, Special = 3 };

        private string m_sAttackName;
        private Types m_cAttackTypes;
        private float m_fAttackDamage;
        private float m_fResistance;
        private int m_iSpeed;
        private float m_fHp;
        private AttackType m_attackType;
        private int m_iAttackMana;

        #endregion

        #region Property

        public string GetAttackName { get => m_sAttackName; }
        public Types GetAttackType { get => m_cAttackTypes; }
        public float GetAttackDamage { get => m_fAttackDamage; }
        public int GetAttackMana { get => m_iAttackMana; }
        public float GetAttackResistance { get => m_fResistance; }
        public int GetAttackSpeed { get => m_iSpeed; }
        public float GetAttackHP { get => m_fHp; }
        public AttackType GetAttackClass { get => m_attackType; }

        #endregion

        #region Methode

        public Attack(string sAttackName, Types cType, float fDamage, float fResistance, float fHp, int iSpeed, int iMana, AttackType attackType)
        {
            m_sAttackName = sAttackName;
            m_cAttackTypes = cType;
            m_fAttackDamage = fDamage;
            m_fResistance = fResistance;
            m_fHp = fHp;
            m_iSpeed = iSpeed;
            m_iAttackMana = iMana;
            m_attackType = attackType;

            Attacks.Add(this);
        }

        public List<Attack> AttackList()
        {
            return Attacks;
        }

        #endregion

    }
}
