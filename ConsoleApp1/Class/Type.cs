using Game.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Entity;

namespace Game.Element
{
    public class Type
    {
        #region Fields

        private float m_fMultiplier = 1f;

        #endregion

        #region Methode

        public float AttackDamage(Mob h1, Mob h2)
        {

            if(h1.GetHeroAttackType == h2.GetType)
            {
                return h1.HeroAttackDamage *=  m_fMultiplier;
            } 
            else if(h1.GetHeroAttackType == Types.Fire && h2.GetType == Types.Grass)
            {
                return h1.HeroAttackDamage *= (m_fMultiplier * 2f);
            }
            else if(h1.GetHeroAttackType == Types.Fire && h2.GetType == Types.Water)
            {
                return h1.HeroAttackDamage *= (m_fMultiplier * 0.5f);
            }
            else if(h1.GetHeroAttackType == Types.Grass && h2.GetType == Types.Fire)
            {
                return h1.HeroAttackDamage *= (m_fMultiplier * 0.5f);
            }            
            else if(h1.GetHeroAttackType == Types.Grass && h2.GetType == Types.Water)
            {
                return h1.HeroAttackDamage *= (m_fMultiplier * 2f);
            }
            else if(h1.GetHeroAttackType == Types.Grass && h2.GetType == Types.Flying)
            {
                return h1.HeroAttackDamage *= (m_fMultiplier * 0.5f);
            }
            else if(h1.GetHeroAttackType == Types.Water && h2.GetType == Types.Fire)
            {
                return h1.HeroAttackDamage *= (m_fMultiplier * 2f);
            }
            else if(h1.GetHeroAttackType == Types.Water && h2.GetType == Types.Grass)
            {
                return h1.HeroAttackDamage *= (m_fMultiplier * 0.5f);
            }
            else if(h1.GetHeroAttackType == Types.Flying && h2.GetType == Types.Grass)
            {
                return h1.HeroAttackDamage *= (m_fMultiplier * 2f);
            }
            else if(h1.GetHeroAttackType == Types.Dragon)
            {
                return h1.HeroAttackDamage *= (m_fMultiplier * 2f);
            }
            else
            {
                return h1.HeroAttackDamage = h1.HeroAttackDamage * m_fMultiplier;
            }
        }

        #endregion

    }
}
