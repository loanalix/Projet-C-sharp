using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Class
{
    public class player
    {

        private string m_sName = "";

        public player(string sName)
        {

            m_sName = sName;

        }

        public string Name { get => m_sName; private set => m_sName = value; }

    }
}
