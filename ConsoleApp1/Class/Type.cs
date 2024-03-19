using Main.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Class
{
    public class Type
    {
        private static float m_fMultiplier = 1f;

        private static void Multiplier(Heroes h1, Heroes h2)
        {
            if(h1.GetType == h2.GetType)
            {
                h1.Damage = h1.Damage * m_fMultiplier;
            } 
            else if(h1.GetType == Types.Fire && h2.GetType == Types.Grass)
            {
                h1.Damage = h1.Damage * (m_fMultiplier * 2f);
            }
            else if(h1.GetType == Types.Fire && h2.GetType == Types.Water)
            {
                h1.Damage = h1.Damage * (m_fMultiplier * 0.5f);
            }
            else if(h1.GetType == Types.Grass && h2.GetType == Types.Fire)
            {
                h1.Damage = h1.Damage * (m_fMultiplier * 0.5f);
            }            
            else if(h1.GetType == Types.Grass && h2.GetType == Types.Water)
            {
                h1.Damage = h1.Damage * (m_fMultiplier * 2f);
            }
            else if(h1.GetType == Types.Grass && h2.GetType == Types.Flying)
            {
                h1.Damage = h1.Damage * (m_fMultiplier * 0.5f);
            }
            else if(h1.GetType == Types.Water && h2.GetType == Types.Fire)
            {
                h1.Damage = h1.Damage * (m_fMultiplier * 2f);
            }
            else if(h1.GetType == Types.Water && h2.GetType == Types.Grass)
            {
                h1.Damage = h1.Damage * (m_fMultiplier * 0.5f);
            }
            else if(h1.GetType == Types.Flying && h2.GetType == Types.Grass)
            {
                h1.Damage = h1.Damage * (m_fMultiplier * 2f);
            }
            else if(h1.GetType == Types.Dragon)
            {
                h1.Damage = h1.Damage * (m_fMultiplier * 2f);
            }
            else
            {
                h1.Damage = h1.Damage * m_fMultiplier;
            }
        }

        public static void Weaknesses(Heroes h1, Heroes h2)
        {

            Multiplier(h1, h2);
            Multiplier(h2, h1);

        }

    }
}
