using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Class
{
    internal class PotionMana : Item 
    {
        public int  ManaHeal { get; set; }

        public PotionMana(string name , int manaHeal) : base(name)
        {
            ManaHeal = manaHeal;
        }

        public override void Use(Player player) 
        {
            Console.WriteLine($"L'objet {Name} a été utilisée pour re donner {ManaHeal} points de mana.");
        }
    }
}
