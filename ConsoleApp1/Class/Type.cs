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

        private void StunAttack(Mob opponent)
        {
            if (opponent.GetStunState == false)
            {
                opponent.Stun();
            }
            else
            {
                Console.WriteLine(opponent.Name + " is already stun, use another attack.");
                return;
            }
        }
        private float DamageOpponent(Mob h1, Mob opponent)
        {
           return(table.FirstOrDefault(i => h1.GetHeroAttackType == i.Item1 && opponent.GetHeroAttackType == i.Item2)?.Item3 ?? 1f) * h1.GetHeroAttackDamage * m_fMultiplier;
        }
        private void CalculateDamage(float fDamage, Mob h1, Mob opponent)
        {
            float fDamageDealt = (2 * fDamage - opponent.Resistance) * 0.5f;
            int iManaCost = h1.GetHeroAttack.GetAttackMana;
            opponent.TakeDamage(fDamageDealt);
            h1.UpdateMana(iManaCost);
        }

        private void SpellEffects(Mob h1, Mob opponent)
        {
            int iMana = h1.GetHeroAttackMana;
            float fRegeneration = h1.GetHeroAttackHP;
            float fResistance = h1.GetHeroAttackResistance;
            float fDamage = h1.GetHeroAttackDamage;

            h1.UpdateHP(fRegeneration);
            h1.UpdateResistance(fResistance);
            h1.UpdateDamage(fDamage);
            h1.UpdateMana(-iMana);
        }

        public void UseAttack(Mob h1, Mob opponent)
        {
            if(h1.GetHeroAttackClass == Attack.AttackClass.Attack || h1.GetHeroAttackClass == Attack.AttackClass.Special)
            {
                float fDamage = DamageOpponent(h1, opponent);
                CalculateDamage(fDamage, h1, opponent);
            }
            else if(h1.GetHeroAttackClass == Attack.AttackClass.Stun)
            {
                StunAttack(opponent);
            }
            else if(h1.GetHeroAttackClass == Attack.AttackClass.Spell)
            {
                SpellEffects(h1, opponent);
            }
        }

        #endregion

    }
}
