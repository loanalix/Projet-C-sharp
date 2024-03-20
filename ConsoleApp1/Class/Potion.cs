using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.UsableItem;

namespace Game.Brewing
{
    public class Potion : Item
    {
        public int HealingAmount { get; set; }

        public Potion(string name, int healingAmount) : base(name)
        {
            HealingAmount = healingAmount;
        }

        public override void Use(Player player)
        {
            Console.WriteLine($"L'objet {Name} a été utilisée par {player.Name} pour guérir de {HealingAmount} points de vie .");
        }
    }
}
