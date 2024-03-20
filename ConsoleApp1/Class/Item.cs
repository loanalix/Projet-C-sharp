using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Object;

namespace Game.UsableItem
{
    public class Item : GameObject
    {
        public Item(string name) : base(name)
        {

        }


        public virtual void Use() 
        {
            Console.WriteLine($"L'objet {Name} a été utilisé.");
        }
    }


}
