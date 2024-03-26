using Game.Class;
using Game.Enum;

namespace Game.Class
{
    public class Ennemy : Mob
    {

        static List<Ennemy> ennemies = new List<Ennemy>();

        public static List<Ennemy> GetEnnemies { get => ennemies; } 

        public Ennemy(string sName, int iHp, int iMana, float fDamage, float fResistance, int iSpeed, Types cTypes) : base(sName, iHp, iMana, fDamage, fResistance, iSpeed, cTypes)
        {
            ennemies.Add(this);
        }

        public static void CreateEnnemies()
        {
            Ennemy pikachu = new Ennemy("Pikachu", 150, 20, 2f, 0f, 100, Types.Flying);
            Ennemy bulbizarre = new Ennemy("Bulbizarre", 150, 20, 2f, 0f, 100, Types.Grass);
            Ennemy salameche = new Ennemy("Salameche", 150, 20, 2f, 0f, 100, Types.Fire);
            Ennemy rayquaza = new Ennemy("Rayquaza", 150, 20, 2f, 0f, 100, Types.Dragon);
            Ennemy artikodin = new Ennemy("Artikodin", 150, 20, 2f, 0f, 100, Types.Flying);
            Ennemy giratina = new Ennemy("Giratina", 150, 20, 2f, 0f, 100, Types.Flying);
            Ennemy mewtwo = new Ennemy("Mewtwo", 150, 20, 2f, 0f, 100, Types.Grass);
            Ennemy lunala = new Ennemy("Lunala", 150, 20, 2f, 0f, 100, Types.Flying);
            Ennemy groudon = new Ennemy("Groudon", 150, 20, 2f, 0f, 100, Types.Fire);
        }

    }
}
