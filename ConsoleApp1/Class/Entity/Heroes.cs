using Game.Class;
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
            Heroes dialga = new Heroes("Dialga", 1, 200, 75f, 70f, 70, Types.Dragon); // 1200
            Heroes zekrom = new Heroes("Zekrom", 1, 210, 80f, 76f, 45, Types.Dragon); // 1300
            Heroes darkrai = new Heroes("Darkrai", 1, 90, 100f, 45f, 45, Types.Flying); // 850

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
