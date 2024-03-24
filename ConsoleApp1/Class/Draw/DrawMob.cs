using Game.Class;

namespace Drawing
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

        public void MobDraw(Player oPlayer, string asciiArt)
        {
            // Divise le dessin ASCII en lignes
            string[] lines = asciiArt.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // Réinitialise mapLines pour effacer les données précédentes
            mapLine = new List<string>();

            // Ajoute chaque ligne à la liste mapLines
            foreach (string line in lines)
            {
                mapLine.Add(line);
            }

            // Parcours de chaque ligne de la carte
            foreach (string line in mapLine)
            {
                // Affichage de chaque caractère de la ligne
                foreach (char c in line)
                {
                    // Affichage du caractère
                    if (oPlayer != null && c == 'P')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('P');
                    }
                    else
                    {
                        if (c != '/')
                        {
                            Console.Write(c);
                        }
                    }
                }

                // Passer à la ligne suivante après avoir dessiné une ligne
                Console.WriteLine();
            }
        }
    }
}