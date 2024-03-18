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
        #region Fields

        private string m_sName = "";
        private int m_iHp;
        private int m_iMana;
        private float m_fDamage;
        private float m_fResistance;
        private int m_iSpeed;
        private int m_iIVSpeed = 0;
        private int m_iFinalSpeed;
        private float m_fPrecision;
        private float m_fExp;
        private int m_iLevel;
        private Types m_cTypes;

        #endregion

        #region Property

        public string Name { get => m_sName; set => m_sName = value; }
        public int HP { get => m_iHp; set => m_iHp = value; }
        public int Mana { get => m_iMana; set => m_iMana = value; }
        public float Damage { get => m_fDamage; set => m_fDamage = value; }
        public float Resistance { get => m_fResistance; set => m_fResistance = value; }
        public int Speed { get => m_iSpeed; set => m_iSpeed = value; }
        public int IVSpeed { get => m_iIVSpeed; set => m_iIVSpeed = value; }
        public int FinalSpeed { get => m_iFinalSpeed; set => m_iFinalSpeed = value; }
        public float Precision { get => m_fPrecision; set => m_fPrecision = value; }
        public float Exp { get => m_fExp; set => m_fExp = value; }
        public int Level { get => m_iLevel; set => m_iLevel = value; }
        public Types GetType { get => m_cTypes; }

        #endregion

        #region Events

        public event Action onDamage;
        public event Action onChangedResistance;
        public event Action onChangedMana;
        public event Action onChangedSpeed;
        public event Action onChangedPrecision;
        public event Action onChangedExp;
        public event Action onChangedLevel;
        public event Action onChangedIVSpeed;

        #endregion

        #region Methods

        public Heroes(string sName, int iHp, int iMana, float fDamage, float fResistance, int iSpeed, float fPrecision, Types cType)
        {

            m_sName = sName;
            m_iHp = iHp;
            m_iMana = iMana;
            m_fDamage = fDamage;
            m_fResistance = fResistance;
            m_iSpeed = iSpeed;
            m_iFinalSpeed = iSpeed + m_iIVSpeed;
            m_fPrecision = fPrecision;
            m_fExp = 0;
            m_iLevel = 0;
            m_cTypes = cType;

        }

        public void TakeDamage(float fDamage)
        {
            m_iHp -= (int)fDamage;
            onDamage?.Invoke();
        }
        public void UpdateMana(int iMana)
        {
            m_iMana += iMana;
            onChangedMana?.Invoke();
        }
        public void UpdateResistance(float fResistance)
        {
            m_fResistance += fResistance;
            onChangedResistance?.Invoke();
        }
        public void UpdateSpeed(int iSpeed)
        {
            m_iSpeed += iSpeed;
            onChangedSpeed?.Invoke();

        }
        public void UpdatePrecision(float fPrecision)
        {
            m_fPrecision += fPrecision;
            onChangedPrecision?.Invoke();
        }
        public void UpdateExp(float fExp)
        {
            m_fExp += fExp;
            onChangedExp?.Invoke();
        }
        public void UpdateLevel(int iLevel)
        {
            m_iLevel += iLevel;
            onChangedLevel?.Invoke();
        }
        public void UpdateIVSpeed(int iIVSpeed)
        {
            m_iIVSpeed += iIVSpeed;
            onChangedIVSpeed?.Invoke();
        }

        public void GenerateIVSpeed()
        {
            Random random = new Random();
            int randomIVSpeed = random.Next(1, 101);
            m_iIVSpeed = randomIVSpeed;
            m_iFinalSpeed = m_iSpeed + m_iIVSpeed;
        }

        public static void CalculateWhoIsStarting(Heroes h1, Heroes h2)
        {
            int iSpeedDiff = Math.Abs(h1.FinalSpeed - h2.FinalSpeed);

            double dAttackProbabilityH1 = (double)iSpeedDiff / 100;
            double dAttackProbabilityH2 = 1 - dAttackProbabilityH1;

            Random random = new Random();
            double dAttackerProbability = random.NextDouble();

            Console.WriteLine(" ");
            Console.WriteLine("dAttackerProbability => " + dAttackerProbability);
            Console.WriteLine("h1 => " + dAttackProbabilityH1);
            Console.WriteLine("h2 => " + dAttackProbabilityH2);
            Console.WriteLine("Combat Starter: " + (dAttackerProbability < dAttackProbabilityH1 ? h1.Name : h2.Name));
        }

        #endregion
    }
}
