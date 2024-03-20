using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Object
{
    public class GameObject
    {
        public string Name { get; set; } 

        public GameObject(string name) 
        {
            Name = name;        
        }

    }
}
