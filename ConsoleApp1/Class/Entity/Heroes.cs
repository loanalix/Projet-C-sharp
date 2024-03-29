using Game.Class;
using Game.Enum;
using Main.Class.Save;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System;

namespace Game.Class
{
    public class Heroes : Mob
    {

        private static List<Heroes> heroes = new List<Heroes>();

        public static List<Heroes> GetHeroes { get => heroes; }

        public Heroes(string sName, int iHp, int iMana, float fDamage, float fResistance, int iSpeed, Types cTypes) : base(sName, iHp, iMana, fDamage, fResistance, iSpeed, cTypes)
        {
           heroes.Add(this);
        }
        public Heroes(HeroesData hero) : base(hero.m_sName, (int)hero.m_iHp, hero.m_iMana, hero.m_fDamage, hero.m_fResistance, hero.m_iSpeed, hero.m_cType)
        {
            Heroes heros = new Heroes(hero.m_sName,(int)hero.m_iHp, hero.m_iMana,hero.m_fDamage, hero.m_fResistance, hero.m_iSpeed, hero.m_cType);
            AddNormalAttack(hero.m_NormalAttacks);
            AddSpecialAttack(hero.m_SpecialAttacks);
            AddSpellAttack(hero.m_SpellAttacks);
            AddStunAttack(hero.m_StunAttacks);
            GetHeroAttack = hero.m_cAttack;
            GetHeroAttackName = hero.m_sAtackName;
            GetHeroAttackType = hero.m_cAttackType;
            GetHeroAttackDamage = hero.m_fAttackDamage;
            GetHeroAttackMana = hero.m_iAttackMana;
            GetHeroAttackResistance = hero.m_fAttackResistance;
            GetHeroAttackHP = hero.m_fAttackHP;
            heroes.Add(heros);
        }
        //public Heroes(HeroesData heros)
        //{
        //    //foreach (Hero in heros.heroes) ;
        //}
        public static void CreateHeroes()
        {
            Heroes dialga = new Heroes("Dialga", 1200, 200, 75f, 70f, 70, Types.Dragon);
            Heroes zekrom = new Heroes("Zekrom", 1300, 210, 80f, 76f, 45, Types.Dragon);
            Heroes darkrai = new Heroes("Darkrai", 850, 90, 100f, 45f, 45, Types.Flying);

            dialga.AddAttacks("Dragon Claw");
            dialga.AddAttacks("Dynamax Cannon");
            dialga.AddAttacks("Aqua ring");
            dialga.AddAttacks("Head Knock");

            zekrom.AddAttacks("Dragon Hammer");
            zekrom.AddAttacks("Dynamax Cannon");
            zekrom.AddAttacks("Fire shield");
            zekrom.AddAttacks("Overheated");

            darkrai.AddAttacks("Dragon Ascent");
            darkrai.AddAttacks("Air Slash");
            darkrai.AddAttacks("Roots of power");
            darkrai.AddAttacks("Windstorm");
        }
        
        public HeroesData GetHeroesData()
        {
            HeroesData hero = new HeroesData();
            hero.m_cAttack = GetHeroAttack;
            hero.m_sAtackName = GetHeroAttackName;
            hero.m_cAttackType = GetHeroAttackType;
            hero.m_fAttackDamage = GetHeroAttackDamage;
            hero.m_iAttackMana = GetHeroAttackMana;
            hero.m_fAttackResistance = GetHeroAttackResistance;
            hero.m_iAttackSpeed = GetHeroAttackSpeed;
            hero.m_fAttackHP = GetHeroAttackHP;
            hero.GetHeroAttackClass = GetHeroAttackClass;
            hero.m_StunAttacks = GetHeroStunAttack;
            hero.m_SpellAttacks = GetHeroSpellAttack;
            hero.m_SpecialAttacks = GetHeroSpecialAttack;
            hero.m_NormalAttacks = GetHeroNormalAttack;
            hero.m_sName = Name;
            hero.m_iHp = HP;
            hero.m_fDamage = Damage;
            hero.m_fResistance =  Resistance;
            hero.m_iMana = Mana;
            hero.m_cType = GetEntityType;
            hero.m_iSpeed = Speed;
            return hero;
        }
    }
}
