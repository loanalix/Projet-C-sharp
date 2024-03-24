using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Class;

namespace Game.Class
{
    public class Potion : Item
    {
        public int HealingAmount { get; set; }

        public Potion(string name, int healingAmount) : base(name)
        {
            HealingAmount = healingAmount;
        }

        public override void Use(Player player , Mob target )
        {
            Console.WriteLine($"La potion {Name} a été utilisée par {player.Name} sur {target.Name} pour guérir de {HealingAmount} points de vie.");
        }
    }
}
