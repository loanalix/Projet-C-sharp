using Game.Class;
using Game.Enum;

namespace Game.Class
{
    public class Heroes : Mob
    {

        List<Heroes> heroes = new List<Heroes>();

        public static List<Heroes> GetHeroes { get => heroes; }

        public Heroes(string sName, int iHp, int iMana, float fDamage, float fResistance, int iSpeed, Types cTypes) : base(sName, iHp, iMana, fDamage, fResistance, iSpeed, cTypes)
        {
           heroes.Add(this);
        }

    }
}
