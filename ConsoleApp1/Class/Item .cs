﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Class;

namespace Game.Class
{
    public class Item : GameObject
    {
        public Item(string name) : base(name)
        {

        }


        public virtual void Use(Player player , Mob target ) 
        {
            Console.WriteLine($"L'objet {Name} a été utilisé sur {target.Name}.");
        }
    }


}
