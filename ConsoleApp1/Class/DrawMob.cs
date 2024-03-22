using Game.Class;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Game.Class
{
    public class DrawMob
    {

        private int iWidth;
        private List<string> mapLine;

        public List<string> Line { get { return mapLine; } }

        public void LoadMob(string sFileName)
        {
            mapLine = new List<string>();

            StreamReader reader = File.OpenText(sFileName);
            string line;


            while ((line = reader.ReadLine()) != null)
            {
                mapLine.Add(line);
            }
            reader.Close();
        }

        public void MobDraw(string asciiArt)
        {
            for (int i = 0 ; i < mapLine.Count; i++) 
            {

            }



        }
    }
}