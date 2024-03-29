using Game.Enum;
using Main.Class.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Game.Class
{
    public class Attack
    {

        #region Fields

        public static List<Attack> m_lAttack = new List<Attack>();

        public enum AttackClass { Attack = 0, Spell = 1, Stun = 2, Special = 3 };

        private string m_sAttackName;
        private Types m_cAttackTypes;
        private float m_fAttackDamage;
        private float m_fResistance;
        private int m_iSpeed;
        private float m_fHp;
        private AttackClass m_attackType;
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
        public AttackClass GetAttackClass { get => m_attackType; }
        
        public static List<Attack> AttackList { get => m_lAttack; }

        #endregion

        #region Methode
        public Attack()
        {

        }
        public Attack(string sAttackName, Types cType, float fDamage, float fResistance, float fHp, int iSpeed, int iMana, AttackClass attackType)
        {
            m_sAttackName = sAttackName;
            m_cAttackTypes = cType;
            m_fAttackDamage = fDamage;
            m_fResistance = fResistance;
            m_fHp = fHp;
            m_iSpeed = iSpeed;
            m_iAttackMana = iMana;
            m_attackType = attackType;

            m_lAttack.Add(this);
        }
        public Attack(AttackData hero)
        {
            m_sAttackName = hero.m_sAttackName;
            m_cAttackTypes = hero.m_cAttackTypes;
            m_fAttackDamage = hero.m_fAttackDamage;
            m_fResistance = hero.m_fResistance;
            m_fHp = hero.m_fHp;
            m_iSpeed = hero.m_iSpeed;
            m_iAttackMana = hero.m_iAttackMana;
            m_attackType = hero.m_attackClass;

            m_lAttack.Add(this);
        }

        public static void CreateAttacks()
        {
            // Non damage abilities
            new Attack("Stun Spore", Types.Grass, 0f, 0f, 0f, 15, 50, AttackClass.Stun);
            new Attack("Head Knock", Types.Dragon, 0f, 0f, 0f, 15, 50, AttackClass.Stun);
            new Attack("Overheated", Types.Fire, 0f, 0f, 0f, 15, 50, AttackClass.Stun);
            new Attack("Drink the cup", Types.Water, 0f, 0f, 0f, 15, 50, AttackClass.Stun);
            new Attack("Windstorm", Types.Flying, 0f, 0f, 0f, 15, 50, AttackClass.Stun);

            new Attack("Aqua ring", Types.Flying, 0f, 0f, 15f, 30, 20, AttackClass.Spell);
            new Attack("Withdraw", Types.Water, 0f, 15f, 0f, 30, 40, AttackClass.Spell);
            new Attack("Dragon Dance", Types.Dragon, 15f, 0f, 0f, 30, 20, AttackClass.Spell);
            new Attack("Fire shield", Types.Fire, 0f, 15f, 0f, 30, 20, AttackClass.Spell);
            new Attack("Roots of power", Types.Grass, 10f, 5f, 0f, 30, 35, AttackClass.Spell);

            // Dragon
            new Attack("Breaking Swipe", Types.Dragon, 60f, 0f, 0f, 30, 40, AttackClass.Attack);
            new Attack("Dragon Hammer", Types.Dragon, 90f, 0f, 0f, 40, 70, AttackClass.Attack);
            new Attack("Dragon Claw", Types.Dragon, 80f, 0f, 0f, 35, 55, AttackClass.Attack);

            new Attack("Dynamax Cannon", Types.Dragon, 100f, 0f, 0f, 100, 125, AttackClass.Special);

            // Grass
            new Attack("Trop Kick", Types.Grass, 70f, 0f, 0f, 30, 40, AttackClass.Attack);
            new Attack("Grav Apple", Types.Grass, 40f, 7f, 0f, 30, 55, AttackClass.Attack);
            new Attack("Power Whip", Types.Grass, 120f, 0f, 0f, 60, 90, AttackClass.Attack);

            new Attack("Chronoblast", Types.Fire, 150f, 0f, 0f, 95, 125, AttackClass.Special);

            // Fire
            new Attack("Flare Blitz", Types.Fire, 25f, 0f, 0f, 30, 30, AttackClass.Attack);
            new Attack("Fire Lash", Types.Fire, 40f, 0f, 0f, 35, 45, AttackClass.Attack);
            new Attack("Flame Charge", Types.Fire, 70f, 0f, 0f, 55, 65, AttackClass.Attack);

            new Attack("Armor Cannon", Types.Fire, 120f, 15f, 0f, 100, 100, AttackClass.Special);

            // Flying
            new Attack("Aerial Ace", Types.Flying, 20f, 0f, 0f, 100, 30, AttackClass.Attack);
            new Attack("Wing Attack", Types.Flying, 45f, 0f, 0f, 100, 35, AttackClass.Attack);
            new Attack("Dragon Ascent", Types.Flying, 80f, 15f, 0f, 100, 85, AttackClass.Attack);

            new Attack("Air Slash", Types.Flying, 75f, 0f, 0f, 95, 85, AttackClass.Special);

            // Water
            new Attack("Liquidation", Types.Water, 15f, 3f, 0f, 85, 25, AttackClass.Attack);
            new Attack("Aqua tail", Types.Water, 90f, 0f, 0f, 70, 75, AttackClass.Attack);
            new Attack("Triple Dive", Types.Water, 30f, 0f, 0f, 20, 95, AttackClass.Attack);

            new Attack("Chilling Water", Types.Water, 50, 0f, 0f, 100, 45, AttackClass.Special);
        }

        public AttackData GetAttackData()
        {
            AttackData attack = new AttackData();
            attack.m_iAttackMana = GetAttackMana;
            attack.m_fAttackDamage = GetAttackDamage;
            attack.m_cAttackTypes = GetAttackType;
            attack.m_sAttackName = GetAttackName;
            attack.m_iSpeed = GetAttackSpeed;
            attack.m_fResistance = GetAttackResistance;
            attack.m_fHp = GetAttackHP;
            attack.m_attackClass = GetAttackClass;
            return attack;

        }
        #endregion

    }
}
