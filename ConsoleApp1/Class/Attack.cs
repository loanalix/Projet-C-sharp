using Game.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Class;

namespace Game.Class
{
    public class Attack
    {

        #region Fields

        public static List<Attack> Attacks = new List<Attack>();

        private string m_sAttackName = "";
        private Types m_cAttackTypes;
        private float m_fAttackDamage;
        private int m_iAttackMana;

        #endregion

        #region Property

        public string GetAttackName { get => m_sAttackName; }
        public Types GetAttackType { get => m_cAttackTypes; }
        public float GetAttackDamage { get => m_fAttackDamage; }
        public int GetAttackMana { get => m_iAttackMana; }

        #endregion

        #region Methode

        public Attack(string sAttackName, Types cType, float fDamage, int iMana)
        {
            m_sAttackName = sAttackName;
            m_cAttackTypes = cType;
            m_fAttackDamage = fDamage;
            m_iAttackMana = iMana;

            Attacks.Add(this);
        }

        public List<Attack> AttackList()
        {
            return Attacks;
        }

        #endregion

    }
}
