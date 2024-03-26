using Game.Class;
using Game.Enum;

namespace Game.Class
{
    public class Ennemy : Mob
    {

        List<Ennemy> ennemies = new List<Ennemy>();

        public Ennemy(string sName, int iHp, int iMana, float fDamage, float fResistance, int iSpeed, Types cTypes) : base(sName, iHp, iMana, fDamage, fResistance, iSpeed, cTypes)
        {
            ennemies.Add(this);
        }

    }
}
