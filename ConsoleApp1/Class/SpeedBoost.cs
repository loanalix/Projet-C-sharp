using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Class
{
    public class SpeedBoost: UsableItem
    {
        public int SpeedIncress { get; set; }

        public SpeedBoost(string name , int speedIncress): base(name) 
        {
            SpeedIncress = speedIncress; 
        }

        public override void Use()
        {
            Console.WriteLine($"L'objet {Name} a été utilisée pour boosté de {SpeedIncress} points de vitesse.");
        }

    }
}
