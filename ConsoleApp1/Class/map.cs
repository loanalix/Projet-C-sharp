using Game.Class;
using Drawing;
using Tools;

namespace Game.Class
{
    public class Map
    {
        #region Fields

        public List<char> m_lMap;
        List<int> m_lSpawn;
        Draw m_oDraw;

        string m_sName;
        int m_iWidth;
        int m_iHeight;
        Utils utils;
        #endregion

        #region Property
        public Draw oDraw { get=>m_oDraw; set => m_oDraw = value; }

        public List<char> GetMap { get => m_lMap; }
        public List<int> GetSpawn{ get => m_lSpawn; }
        public int GetWidth { get => m_iWidth; }
        public int GetHeight { get => m_iHeight; }
        #endregion
        public string GetName { get => m_sName; }

        #region Constructor
        public Map(string sName)
        {

            m_lMap = new List<char>();
            m_lSpawn = new List<int>();
            m_iWidth = 0;
            m_iHeight = 0;
            m_sName = sName;
            utils = new Utils();
        }
        #endregion  

        #region Method
        public string ChangeMap(Player oPlayer, Map oMap, Mob oMob)
        {
            switch (oMap.m_sName)
            {
                case "map":
                    
                    if (GetMap[utils.ConvertTo1Dim(oPlayer.PosX, oPlayer.PosY, GetWidth)] == 'a')
                    {
                        oPlayer.PosY = GetHeight - 4;
                        oMob.spawnEnnemies(this, "map1");
                        return "map1";
                    }
                    return "map";
                case "map1":
                    if(GetMap[utils.ConvertTo1Dim(oPlayer.PosX, oPlayer.PosY, GetWidth)] == 'a')
                    {
                        oPlayer.PosY = 1;
                        return "map";
                    }
                    return "map1";
                case "startFight":
                    if (GetMap[utils.ConvertTo1Dim(oPlayer.PosX, oPlayer.PosY, GetWidth)] == 's')
                    {
                        return "startFight";
                    }
                    return "map1";

                default:
                    return "";
            }
        }

        public void LoadMap(string sFileName)
        {
            StreamReader reader = File.OpenText(sFileName);
            string line;
            int fileHeight = 0;

            while ((line = reader.ReadLine()) != null)
            {
                m_iWidth = line.Length;
                char[] cChar = line.ToCharArray();
                for (int i = 0; i < cChar.Length; i++)
                {
                    m_lMap.Add(cChar[i]);
                }
                fileHeight++;
            }
            m_iHeight = fileHeight;

        }
        public void GetGrass()
        {
            for (int i = 0; i < m_lMap.Count; i++)
            {
                if (m_lMap[i] == 'g')
                {
                    m_lSpawn.Add(i);
                }
            }
        }
        #endregion
    }
}
