using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Class
{
    internal class AttackBoost : Item 
    {
        public int AttackIncress {  get; set; }


        public AttackBoost(string name , int attackIncress) : base(name) 
        {
            AttackIncress = attackIncress;
        }

        public override void Use (Player player) 
        {
            Console.WriteLine($"L'objet {Name} a été utilisée pour aumenter de {AttackIncress} attaque.");
        }

    }


}
