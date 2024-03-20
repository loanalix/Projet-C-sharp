using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Class
{
    public class Player
    {

        string m_sName = "";

        public Player()
        {

            m_sName = "player0";

        }

        public string Name { get => m_sName; set => m_sName = value; }

    }
}
