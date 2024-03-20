using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Class
{
    public class UsableItem : GameObject
    {
        public UsableItem(string name) : base(name)
        {

        }


        public virtual void Use(Heroes h) 
        {
            Console.WriteLine($"L'objet {Name} a été utilisé.");
        }
    }


}
