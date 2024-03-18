using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Enum;

namespace Main.Class
{
    public class Heroes
    {

        private string m_sName = "";
        private int m_iHp;
        private int m_iMana;
        private float m_fDamage;
        private float m_fResistance;
        private float m_fSpeed;
        private float m_fPrecision;
        private float m_fExp;
        private int m_iLevel;
        private Types m_cTypes;

        public Heroes(string sName, int iHp, int iMana, float fDamage, float fResistance, float fSpeed, float fPrecision, Types cType)
        {

            m_sName = sName;
            m_iHp = iHp;
            m_iMana = iMana;
            m_fDamage = fDamage;
            m_fResistance = fResistance;
            m_fSpeed = fSpeed;
            m_fPrecision = fPrecision;
            m_fExp = 0;
            m_iLevel = 0;
            m_cTypes = cType;
        
        }

        public string Name { get => m_sName; set => m_sName = value; }
        public int HP { get => m_iHp; set => m_iHp = value; }
        public int Mana { get => m_iMana; set => m_iMana = value; }
        public float Damage { get => m_fDamage; set => m_fDamage = value; }
        public float Resistance { get => m_fResistance; set => m_fResistance = value; }
        public float Speed { get => m_fSpeed; set => m_fSpeed = value; }
        public float Precision { get => m_fPrecision; set => m_fPrecision = value; }
        public float Exp { get => m_fExp; set => m_fExp = value; }
        public int Level { get => m_iLevel; set => m_iLevel = value; }
        public Types GetType { get => m_cTypes; }

    }
}
