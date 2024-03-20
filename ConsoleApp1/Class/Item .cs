using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Class
{
    public class Item : GameObject
    {
        public Item(string name) : base(name)
        {

        }


        public virtual void Use(Player player) 
        {
            Console.WriteLine($"L'objet {Name} a été utilisé.");
        }
    }


}
