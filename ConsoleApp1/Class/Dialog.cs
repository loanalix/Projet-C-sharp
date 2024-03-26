using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Main.Class
{
    public class Dialog
    {
        #region Field
        List<string> m_lText;
        List<int> m_lTimeToRead;
        int m_iSizeBox;
        #endregion
        #region Constructor
        public Dialog()
        {
            m_lText = new List<string>();
            m_lTimeToRead = new List<int>();
            m_iSizeBox = 20;
        }
        #endregion
        public void AddText(string text)
        {
            m_lText.Add(text);
        }

        public void TimeToRead()
        {
            for(int i = 0; i < m_lText.Count; i++)
            {
                int Time = 2000;
                string world = m_lText[i];
                for (int j = 0; j < m_lText[i].Length - 1; j++)
                {
                    if (world[j] == ' ')
                    {
                        Time += 500;
                    }
                }
                m_lTimeToRead.Add(Time);
            }
        }
        public void EffacerChaine(int longueurChaine)
        {
            // Retourner le curseur en arrière
            Console.SetCursorPosition(Console.CursorLeft - longueurChaine, Console.WindowHeight - 6);
            Console.Write(new string(' ', longueurChaine));
            Console.SetCursorPosition(Console.CursorLeft - longueurChaine, Console.WindowHeight - 6);
        }
        public void DrawDialog()
        {
            for(int i = 0; i< m_lText.Count; i++)
            {
                int iSize = m_iSizeBox;
                iSize -= m_lText[i].Length;

                Console.SetCursorPosition(Console.WindowWidth/2, Console.WindowHeight - 6);
                Console.Write(m_lText[i]);
                for(int j = 0; j< iSize; j++)
                {
                    Console.Write(' ');
                    if(j== iSize - 1)
                    {
                        Console.WriteLine();
                    }
                }
                string dessin = new string(' ', m_iSizeBox); // Répéter le caractère 20 fois

                Console.WriteLine(dessin);
                Console.WriteLine(dessin);
                Console.WriteLine(dessin);



                TimeToRead();
                Thread.Sleep(m_lTimeToRead[i]);
                EffacerChaine(m_lText[i].Length);

            }
        }
    }
}
