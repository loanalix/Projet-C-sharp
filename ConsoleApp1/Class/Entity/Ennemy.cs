using Game.Class;
using Game.Enum;
using Main.Class.Save;

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
            Ennemy pikachu = new Ennemy("pikachu", 5, 200, 2f, 0f, 100, Types.Flying);
            Ennemy bulbizarre = new Ennemy("Bulbizarre", 5, 200, 2f, 0f, 100, Types.Grass);
            Ennemy dracaufeu = new Ennemy("dracaufeu", 5, 200, 2f, 0f, 100, Types.Grass);
            Ennemy salameche = new Ennemy("Salameche", 5, 200, 2f, 0f, 100, Types.Fire);
            Ennemy rayquaza = new Ennemy("Rayquaza", 5, 200, 2f, 0f, 100, Types.Dragon);
            Ennemy artikodin = new Ennemy("Artikodin", 5, 200, 2f, 0f, 100, Types.Flying);
            Ennemy giratina = new Ennemy("Giratina", 5, 200, 2f, 0f, 100, Types.Dragon);
            Ennemy mewtwo = new Ennemy("Mewtwo", 5, 200, 2f, 0f, 100, Types.Grass);
            Ennemy lunala = new Ennemy("Lunala", 5, 200, 2f, 0f, 100, Types.Flying);
            Ennemy groudon = new Ennemy("Groudon", 5, 200, 2f, 0f, 100, Types.Fire);
            Ennemy kyogre = new Ennemy("Kyogre", 5, 200, 2f, 0f, 100, Types.Water);
        }

        public static EnnemyData GetEnnemyData()
        {
            EnnemyData ennemyData = new EnnemyData();
            ennemyData.m_lEnnemies = ennemies;

            return ennemyData;
        }
    }
}
