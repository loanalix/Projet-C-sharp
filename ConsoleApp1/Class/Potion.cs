using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Class
{
    public class Potion : UsableItem
    {
        public int HealingAmount { get; set; }

        public Potion(string name, int healingAmount) : base(name)
        {
            HealingAmount = healingAmount;
        }

        public override void Use()
        {
            Console.WriteLine($"La potion {Name} a été utilisée pour guérir de {HealingAmount} points de vie.");
        }
    }
}
