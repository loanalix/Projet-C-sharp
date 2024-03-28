﻿using Game.Class;
using Game.Enum;
using Main.Class.Save;

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
        
        public static HeroesData GetHeroesData()
        {
            HeroesData hero = new HeroesData();
            HeroesData.heroes = heroes;
            return hero;
        }
    }
}
