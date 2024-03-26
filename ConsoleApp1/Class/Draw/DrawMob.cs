using Game.Class;

namespace Drawing
{
    public class DrawMob
    {
        private int m_iWidth;
        private int m_iHeight;


        private List<string> mapLine;
        private List<string> mapMob; 
        public List<string> Line { get { return mapLine; } }
        public int GetWidth { get => m_iWidth; }
        public int GetHeight { get => m_iHeight; }

        public void LoadMob(string sFileName)
        {
            mapLine = new List<string>();

            StreamReader reader = File.OpenText(sFileName);
            string line;
            int fileHeight = 0;

            while ((line = reader.ReadLine()) != null)
            {
                m_iWidth = line.Length;
                mapLine.Add(line);
                fileHeight++;
            }
             
            reader.Close();
        }
        public void SaveMob(string sFileName) 
        {
            mapMob = new List<string>();


        }

        public void MobDraw(string mob1, string mob2 )
        {
            string[] lines1 = mob1.Split('\n');
            string[] lines2 = mob2.Split("\n");  

            int maxLenght = Math.Max(lines1.Length, lines2.Length);


            for (int i = 0; i < mapLine.Count ; i++)
            {
                //Console.SetCursorPosition(0, 0);
                Console.WriteLine(mapLine[i]);
            }

            //for (int y = 0 ; y < m_iWidth; y++) 
            //{
            //    Console.SetCursorPosition(m_iWidth + 1, y);
            //}


        }
    }
}