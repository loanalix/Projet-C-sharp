using Game.Character;
using Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game.Class
{
    public class Map
    {
        #region Fields
        private List<int> m_lSpawnable;
        Random rand;
        Draw m_oDraw;
        #endregion

        #region Property
        public Draw oDraw { get=>m_oDraw; set => m_oDraw = value; }

        #endregion

        #region Constructor
        public Map() {

            m_lSpawnable = new List<int>();
            rand = new Random();
        }
        #endregion

        #region Method
        public string ChangeMap(Player oPlayer, string sNewMap)
        {
            switch (sNewMap)
            {
                case "map":
                    
                    if (m_oDraw.GetMap[sNewMap][oPlayer.ConvertTo1Dim(oPlayer.PosX, oPlayer.PosY, m_oDraw.GetWidth)] == 'a')
                    {
                        oPlayer.PosY = m_oDraw.GetHeight - 4;
                        spawnEnnemies("map1");
                        return "map1";
                    }
                    return "map";
                case "map1":
                    if(m_oDraw.GetMap[sNewMap][oPlayer.ConvertTo1Dim(oPlayer.PosX, oPlayer.PosY, m_oDraw.GetWidth)] == 'a')
                    {
                        oPlayer.PosY = 1;
                        return "map";
                    }
                    return "map1";

                default:
                    return "";
            }
        }

        public void spawnEnnemies(string sMap)
        {
            m_oDraw.GetGrass(sMap);
            List<int> spawn = m_oDraw.GetSpawn;
            List<char> Map = m_oDraw.GetMap[sMap];

            for (int i= 0; i < 15; i++)
            {
                int randomIndex = rand.Next(0, spawn.Count);
                int chooseNumber = spawn[randomIndex];
                spawn.RemoveAt(randomIndex);
                Map[chooseNumber] = 's';
            }
            
        }
        #endregion
    }
}
