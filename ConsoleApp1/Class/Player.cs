using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Class
{
    public class player
    {

        string m_sName = "";

        public player()
        {

            m_sName = "player0";

        }

        public string Name { get => m_sName; set => m_sName = value; }

    }
}
