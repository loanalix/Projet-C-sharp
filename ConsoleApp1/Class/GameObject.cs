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
        int m_iPosX;
        int m_iPosY;

        int m_pos1D;

        public int Pos1D { get => m_pos1D; set => m_pos1D = value; }
        public int posX { get => m_iPosX; set => m_iPosX = value; }
        public int posY { get => m_iPosY; set => m_iPosY = value; }
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
