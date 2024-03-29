using Game.Enum;
using Game.Class;
using Main.Class.Save;
using System.Reflection;
using System.ComponentModel;

namespace Game.Class
{
    public class Mob
    {
        #region Fields

        #region Mob stats
        private string m_sName;
        private int m_iMaxHp;
        private float m_iHp;
        private int m_iMana;
        private int m_iMaxMana;
        private float m_fDamage;
        private float m_fResistance;
        private int m_iSpeed;
        private int m_iIVSpeed;
        private int m_iFinalSpeed;
        private float m_fPrecision;
        private float m_fExp;
        private int m_iLevel;
        private Types m_cTypes;
        private FightManager fightManager;
        private bool m_bIsStun;
        #endregion

        #region Mob attack stats

        private Attack m_cAttack;
        private string m_sAttackName;
        private Types m_cAttackType;
        private float m_fAttackDamage;
        private int m_iAttackMana;
        private float m_fAttackResistance;
        private int m_iAttackSpeed;
        private float m_fAttackHP;
        private Attack.AttackClass m_eAttackClass;

        private List<Attack> m_lNormalAttacks = new List<Attack>();
        private List<Attack> m_lSpellAttacks = new List<Attack>();
        private List<Attack> m_lStunAttacks = new List<Attack>();
        private List<Attack> m_lSpecialAttacks = new List<Attack>();
        #endregion

        private int m_iWidth;
        private int m_iHeight;
        Random random = new Random();

        //private static List<Attack> m_lAttack = new List<Attack>();
        private static List<Mob> m_lAllMobs = new List<Mob>();
        private List<string> mapLine;

        Random rand;

        #endregion

        #region Property

        #region Mob stats Properties
        public string Name { get => m_sName; set => m_sName = value; }
        public int HPMax { get => m_iMaxHp; }
        public float HP { get => m_iHp; set => m_iHp = value; }
        public float MaxHP { get => m_iMaxHp; }
        public int Mana { get => m_iMana; set => m_iMana = value; }
        public int MaxMana { get => m_iMaxMana; }
        public float Damage { get => m_fDamage; set => m_fDamage = value; }
        public float Resistance { get => m_fResistance; set => m_fResistance = value; }
        public int Speed { get => m_iSpeed; set => m_iSpeed = value; }
        public int IVSpeed { get => m_iIVSpeed; set => m_iIVSpeed = value; }
        public int FinalSpeed { get => m_iFinalSpeed; set => m_iFinalSpeed = value; }
        public float Precision { get => m_fPrecision; set => m_fPrecision = value; }
        public float Exp { get => m_fExp; set => m_fExp = value; }
        public int Level { get => m_iLevel; set => m_iLevel = value; }
        public Types GetEntityType { get => m_cTypes; }
        public bool GetStunState { get => m_bIsStun; }
        #endregion

        #region Mob attack stats Properties
        public Attack GetHeroAttack { get => m_cAttack; set => m_cAttack = value;  }
        public string GetHeroAttackName { get => m_sAttackName; set => m_sAttackName = value; }
        public Types GetHeroAttackType { get => m_cAttackType; set => m_cAttackType = value; }
        public float GetHeroAttackDamage { get => m_fAttackDamage; set => m_fAttackDamage = value; }
        public int GetHeroAttackMana { get => m_iAttackMana; set => m_iAttackMana = value; }
        public float GetHeroAttackResistance { get => m_fAttackResistance; set => m_fAttackResistance = value; }
        public int GetHeroAttackSpeed { get => m_iAttackSpeed; set => m_iAttackSpeed = value; }
        public float GetHeroAttackHP { get => m_fAttackHP; set => m_fAttackHP = value; }
        public Attack.AttackClass GetHeroAttackClass { get => m_eAttackClass; }
        public Attack GetHeroNormalAttack { get => m_lNormalAttacks[0]; }
        public Attack GetHeroSpellAttack { get => m_lSpellAttacks[0]; }
        public Attack GetHeroStunAttack { get => m_lStunAttacks[0]; }
        public Attack GetHeroSpecialAttack { get => m_lSpecialAttacks[0]; }
        #endregion

        public List<string> Line { get { return mapLine; } }
        public int GetWidth { get => m_iWidth; }
        public int GetHeight { get => m_iHeight; }
        public static List<Mob> GetAllMobs { get => m_lAllMobs; } 
        #endregion

        #region Events

        public event Action onDamage;
        public event Action onChangedResistance;
        public event Action onRegeneration;
        public event Action onChangeDamage;
        public event Action onChangedMana;
        public event Action onChangedSpeed;
        public event Action onChangedPrecision;
        public event Action onChangedExp;
        public event Action onChangedLevel;
        public event Action onChangedIVSpeed;

        #endregion

        #region Methods

        public Mob(string sName, int iHp, int iMana, float fDamage, float fResistance, int iSpeed, Types cType)
        {

            m_sName = sName;
            m_iHp = iHp;
            m_iMaxHp = iHp;
            m_iMana = iMana;
            m_iMaxMana = iMana;
            m_fDamage = fDamage;
            m_fResistance = fResistance;
            m_iSpeed = iSpeed;
            m_iFinalSpeed = iSpeed + m_iIVSpeed;
            m_fPrecision = 100f;
            m_fExp = 0f;
            m_iLevel = 1;
            m_cTypes = cType;
            fightManager = new FightManager();
            m_iIVSpeed = 0;
            rand = new Random();
            m_lAllMobs.Add(this);
        }

        public void Stun()
        {
            if(m_bIsStun == false)
            {
                m_bIsStun = true;
            } 
            else
            {
                m_bIsStun = false;
            }
        }

        public void AddNormalAttack(Attack oAttack)
        {
            m_lNormalAttacks.Add(oAttack);
        }
        public void AddSpellAttack(Attack oAttack)
        {
            m_lSpellAttacks.Add(oAttack);
        }
        public void AddStunAttack(Attack oAttack)
        {
            m_lStunAttacks.Add(oAttack);
        }
        public void AddSpecialAttack(Attack oAttack)
        {
            m_lSpecialAttacks.Add(oAttack);
        }
        public void GenerateIVSpeed()
        {
            int randomIVSpeed = random.Next(1, 101);
            m_iIVSpeed = randomIVSpeed;
            m_iFinalSpeed = m_iSpeed + m_iIVSpeed;
        }
        public void Draw(bool shift)
        {
            if (shift == null) throw new ArgumentException("shift is null");
            for (int i = 0; i < mapLine.Count; i++)
            {
                if(shift) Console.SetCursorPosition(55, i);

                Console.WriteLine(mapLine[i]);
            }

        }
        public void ResetStats(bool bIncrementLevel)
        {
            m_iMana = m_iMaxMana;
            m_iHp = m_iMaxHp;
            if(bIncrementLevel == true) m_iLevel++;
        }
        public void LoadMob(string sFileName)
        {
            if (sFileName == null || sFileName == "") throw new ArgumentException("sFileName is null or empty");
            mapLine = new List<string>();

            StreamReader reader = System.IO.File.OpenText(sFileName);
            string line;
            int fileHeight = 0;

            while ((line = reader.ReadLine()) != null)
            {
                m_iWidth = line.Length;
                mapLine.Add(line);
                fileHeight++;
            }

            reader.Close();
        }
        public MobData GetMobData(string sFileName)
        {
            MobData mobData = new MobData();

            return mobData;

        }

        #region Update method
        public void TakeDamage(float fDamage)
        {
            if(fDamage > m_iHp)
            {
                m_iHp = 0;
            }
            else
            {
                m_iHp -= fDamage;
            }
            onDamage?.Invoke();
        }
        public void UpdateMana(int iMana)
        {
            float total = m_iMana + iMana;
            if(iMana < 0)
            {
                if(total <= 0)
                {
                    m_iMana = 0;
                }
                else
                {
                    m_iMana += iMana;
                }
            }
            else if(iMana > 0)
            {
                if(total > m_iMaxMana)
                {
                    m_iMana = m_iMaxMana;
                }
                else
                {
                    m_iMana += iMana;
                }
            }
            else return;
            onChangedMana?.Invoke();
        }
        public void UpdateHP(float fHP)
        {
            float total = m_iHp + fHP;
            if (fHP < 0)
            {
                if (total > m_iHp)
                {
                    m_iHp = 0;
                }
                else
                {
                    m_iHp -= fHP;
                }
            }
            else if (fHP > 0)
            {
                if (total > m_iMaxHp)
                {
                    m_iHp = m_iMaxHp;
                }
                else
                {
                    m_iHp += fHP;
                }
            }
            else return;
            onRegeneration?.Invoke();
        }
        public void UpdateResistance(float fResistance)
        {
            if (fResistance < 0)
            {
                m_fResistance -= fResistance;
            }
            else if (fResistance > 0)
            {
                m_fResistance += fResistance;
            }
            else return;
            Console.WriteLine("New resistance: " + m_fResistance);
            onChangedResistance?.Invoke();
        }
        public void UpdateDamage(float fDamage)
        {
            if (fDamage < 0)
            {
                m_fDamage -= fDamage;
            }
            else if (fDamage > 0)
            {
                m_fDamage += fDamage;
            }
            else return;
            onChangeDamage?.Invoke();
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
        #endregion

        #region Attacks
        public void GetAttackProperties(string sAttackName)
        {
            if (sAttackName == null)
            {
                throw new ArgumentException("Argument is null", "sAttackName");
            }
            else
            {
                if (GetAttack(sAttackName) == null) { throw new KeyNotFoundException("sAttackName is an unvalid attack"); }
                Attack attack = GetAttack(sAttackName);
                Console.WriteLine("Attack Name: " + attack.GetAttackName);
                Console.WriteLine("Attack Type: " + attack.GetAttackType);
                Console.WriteLine("Attack Damage: " + attack.GetAttackDamage);
                Console.WriteLine("Attack Mana: " + attack.GetAttackMana);
                Console.WriteLine("Attack Resistance: " + attack.GetAttackResistance);
                Console.WriteLine("Attack Speed: " + attack.GetAttackSpeed);
                Console.WriteLine("Attack Hp: " + attack.GetAttackHP);
                Console.WriteLine("Attack Class: " + attack.GetAttackClass);
                Console.WriteLine("\n");
            }
        }

        public void AddAttacks(string sAttackName)
        {
            if (GetAttack(sAttackName) == null) { throw new KeyNotFoundException("sAttackName is an unvalid attack"); }
            Attack attack = GetAttack(sAttackName);
            if (attack != null)
            {
                switch(attack.GetAttackClass)
                {
                    case Attack.AttackClass.Attack:
                        m_lNormalAttacks.Add(attack);
                        break;
                    case Attack.AttackClass.Spell:
                        m_lSpellAttacks.Add(attack);
                        break;
                    case Attack.AttackClass.Stun:
                        m_lStunAttacks.Add(attack);
                        break;
                    case Attack.AttackClass.Special:
                        m_lSpecialAttacks.Add(attack);
                        break;
                    default:
                        break;
                }
            }
            else { throw new ArgumentException("Argument is null", "sAttackName"); }
        }

        private Attack GetAttack(string sAttackName)
        {
            if (sAttackName == null) { throw new ArgumentException("Argument is null", "sAttackName"); }
            Attack attack = Attack.m_lAttack.FirstOrDefault(a => a.GetAttackName == sAttackName);
            return attack;
        }

        public void PerformAttackTo(Mob op, string sAttackName)
        {
            if (op == null || sAttackName == null) { throw new ArgumentException("Argument is null"); }
            if(GetAttack(sAttackName) == null) { throw new KeyNotFoundException("sAttackName is an unvalid attack"); }
            Attack attack = GetAttack(sAttackName);
            m_cAttack = attack;
            m_cAttackType = attack.GetAttackType;
            m_fAttackDamage = attack.GetAttackDamage;
            m_sAttackName = attack.GetAttackName;
            m_fAttackResistance = attack.GetAttackResistance;
            m_fAttackHP = attack.GetAttackHP;
            m_eAttackClass = attack.GetAttackClass;
            m_iAttackSpeed = attack.GetAttackSpeed;
            m_iAttackMana = attack.GetAttackMana;
            fightManager.AttackOpponent(this, op);
        }

        
        public MobData GetMobData()
        {
            MobData mobData = new MobData();
            //mobData.m_sName = Name;
            //mobData.m_iMaxHp = HPMax;
            //mobData.m_iHp = HP;
            //mobData.m_iMana = Mana;
            //mobData.m_fDamage = Damage;
            //mobData.m_fResistance = Resistance;
            //mobData.m_iSpeed = Speed;
            //mobData.m_iIVSpeed = IVSpeed;
            //mobData.m_iFinalSpeed = FinalSpeed ;
            //mobData.m_fPrecision = Precision;
            //mobData.m_fExp = Exp;
            //mobData. m_iLevel = Level ;
            //mobData.m_cTypes = GetType;
            //mobData.m_bIsStun = GetStun;

            //mobData.m_sAttackName = GetHeroAttackName;
            //mobData.m_cAttackType = GetHeroAttackType;
            //mobData.m_fAttackDamage = HeroAttackDamage;
            //mobData.m_iAttackMana = GetHeroAttackMana;
            mobData.m_lAllMobs = m_lAllMobs;
            mobData.ennemy = Ennemy.GetEnnemyData();
            return mobData;

        }

        #endregion

        #endregion
    }
}
