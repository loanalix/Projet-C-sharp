using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Class;

namespace Game.Class
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
