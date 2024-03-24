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
        #region Property
        public string Name { get; set; }
        #endregion

        #region Methode 
        public GameObject(string name) 
        {
            Name = name;        
        }
        #endregion
    }
}
