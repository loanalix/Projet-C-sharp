using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Class;

namespace Game.Class
{
    internal class AttackBoost : Item 
    {
        #region Property
        public int AttackIncress {  get; set; }
        #endregion

        #region Methode
        public AttackBoost(string name , int attackIncress) : base(name) 
        {
            AttackIncress = attackIncress;
        }

        #region //----Use----//
        public override void Use (Player player, Mob target) 
        {
            Console.WriteLine($"L'objet {Name} a été utilisée pour aumenter de {AttackIncress} attaque.");
        }
        #endregion

        #endregion
    }


}
