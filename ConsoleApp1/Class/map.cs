using Game.Class;
using Drawing;
using System.Transactions;
using Main.Class.Save;

namespace Game.Class
{
   
    public class Map
    {
        #region Fields

        public List<char> m_lMap;
        List<int> m_lSpawn;
        Draw m_oDraw;
        Random rand;

        string m_sName;
        int m_iWidth;
        int m_iHeight;
        int[] m_iObjects;

        #endregion

        #region Property
        public Draw oDraw { get => m_oDraw; set => m_oDraw = value; }

        public int[] Object { get => m_iObjects; set => m_iObjects = value; }
        public List<char> GetMap { get => m_lMap; }
        public List<int> GetSpawn { get => m_lSpawn; }
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
            rand = new Random();

        }
        #endregion  

        #region Method
        public string ChangeMap(Player oPlayer, List<Map> sMap, string sName)
        {
            //Ici on gère le changement de map
            switch (sMap.Find(x=>x.m_sName == sName).GetName)
            {
                case "map":

                    if (GetMap[Maths.ConvertTo1Dim(oPlayer.PosX, oPlayer.PosY, GetWidth)] == 'a')
                    {
                        oPlayer.PosY = GetHeight - 4;
                        spawnEnnemies(sMap[1]);
                        return "map1";
                    }
                    return "map";
                case "map1":
                    if (GetMap[Maths.ConvertTo1Dim(oPlayer.PosX, oPlayer.PosY, GetWidth)] == 'a')
                    {
                        oPlayer.PosY = 1;
                        return "map";
                    }
                    return "map1";
                case "fightMenu":
                    if (GetMap[Maths.ConvertTo1Dim(oPlayer.PosX, oPlayer.PosY, GetWidth)] == 's')
                    {
                        Console.WriteLine("combat!!!! ehbgerghyuiegyhuierhuiygeruhigeruigh");
                        return null;
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

        public List<int> SpawnableObject(Map oMap, char[] spawnChar)
        {
            List<int> objects = new List<int>();
            List<char> map = oMap.GetMap;
            for (int i = 0; i < map.Count; i++)
            {
                for(int j = 0; j < spawnChar.Length; j++)
                {
                    if (map[i] == spawnChar[j])
                    {
                        objects.Add(i);
                    }
                }
            }
            return objects;
        }
        public void spawnEnnemies(Map oMap)
        {
            oMap.GetGrass();
            List<int> spawn = oMap.GetSpawn;
            List<char> Map = oMap.GetMap;

            for (int i = 0; i < 35; i++)
            {
                int randomIndex = rand.Next(0, spawn.Count);
                int chooseNumber = spawn[randomIndex];
                spawn.RemoveAt(randomIndex);
                Map[chooseNumber] = 's';
            }

        }
        public void DrawMiniMap(Map oMap)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            List<char> lMap = oMap.GetMap;
            for (int i = 0; i < lMap.Count; i++)
            {
                switch (lMap[i])
                {
                    case 'v':
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 'g':
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    case 'b':
                        Console.BackgroundColor = ConsoleColor.Blue;
                        break;
                    case 'w':
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 'h':
                        Console.BackgroundColor = ConsoleColor.White;
                        break;
                    case 'p':
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        break;
                    case 'o':
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case ' ':
                        Console.ResetColor();
                        break;
                    case '/':
                        Console.ResetColor();
                        Console.WriteLine();
                        break;
                }
                if (lMap[i] != '/')
                {
                    Console.Write(' ');
                }

            }
        }
        public MapData GetMapData()
        {
            MapData mapData = new MapData();
            mapData.m_lMap = m_lMap;
            mapData.m_lSpawn = m_lSpawn;
            mapData.m_sName = m_sName;
            mapData.m_iObjects = m_iObjects;
            mapData.m_iWidth = m_iWidth;
            mapData.m_iHeight = m_iHeight;

            return mapData;
        }

    }
}
