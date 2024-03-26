using Game.Class;
using Game.Enum;

namespace Game.Class
{
    public class Type
    {
        #region Fields

        private float m_fMultiplier;

        #endregion

        #region Methode

        public Type()
        {
            m_fMultiplier = 1f;
        }

        List<Tuple<Types, Types, float>> table = new List<Tuple<Types, Types, float>>()
        {
            new Tuple<Types, Types, float>(Types.Fire, Types.Grass, 2f),
            new Tuple<Types, Types, float>(Types.Fire, Types.Water, 0.5f),
            new Tuple<Types, Types, float>(Types.Grass, Types.Fire, 0.5f),
            new Tuple<Types, Types, float>(Types.Grass, Types.Water, 2f),
            new Tuple<Types, Types, float>(Types.Grass, Types.Flying, 0.5f),
            new Tuple<Types, Types, float>(Types.Water, Types.Fire, 2f),
            new Tuple<Types, Types, float>(Types.Water, Types.Grass, 0.5f),
            new Tuple<Types, Types, float>(Types.Flying, Types.Grass, 2f),
            new Tuple<Types, Types, float>(Types.Dragon, Types.Grass, 2f),
            new Tuple<Types, Types, float>(Types.Dragon, Types.Fire, 2f),
            new Tuple<Types, Types, float>(Types.Dragon, Types.Flying, 2f),
            new Tuple<Types, Types, float>(Types.Dragon, Types.Water, 2f),
            new Tuple<Types, Types, float>(Types.Dragon, Types.Dragon, 2f),
        };



        public float AttackDamage(Mob h1, Mob h2)
        {
            return (table.FirstOrDefault(i => h1.GetHeroAttackType == i.Item1 && h2.GetHeroAttackType == i.Item2)?.Item3 ?? 1f) * h1.HeroAttackDamage * m_fMultiplier;
        }

        #endregion

    }
}
