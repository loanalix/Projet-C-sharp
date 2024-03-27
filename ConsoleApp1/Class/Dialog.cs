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
        int m_iWidthBox;
        int m_iHeightBox;
        bool m_bEndText;
        #endregion
        #region Constructor
        public Dialog()
        {
            m_lText = new List<string>();
            m_lTimeToRead = new List<int>();
            m_iSizeBox = 20;
            m_iWidthBox = 46;
            m_iHeightBox = 6;
            m_bEndText = false;
        }
        #endregion

        public void FillBlack(int x, int y, int width, int height)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            for (int k = y + 1; k < y + height - 1; k++)
            {
                for (int i = x + 1; i < x + width - 1; i++)
                {
                    Console.SetCursorPosition(i, k);
                    Console.Write(' ');
                }
            }
        }
        public void DrawRectangle(int x, int y, int width, int height)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("╔");
            Console.SetCursorPosition(x + width - 1, y);
            Console.Write("╗");
            Console.SetCursorPosition(x, y + height - 1);
            Console.Write("╚");
            Console.SetCursorPosition(x + width - 1, y + height - 1);
            Console.Write("╝");

            for (int i = x + 1;  i < x + width - 1; i++) 
            {
                Console.SetCursorPosition(i, y);
                Console.Write("═");
                Console.SetCursorPosition(i, y + height - 1);
                Console.Write("═");
            }
            FillBlack(x, y, width, height);


            for (int i = y + 1; i < y + height - 1; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write("║");
                Console.SetCursorPosition(x + width - 1, i);
                Console.Write("║");
            }
        }
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
                        Time += 50;
                    }
                }
                m_lTimeToRead.Add(Time);
            }
        }

        public void DrawDialog(string sSpeaker)
        {
            DrawRectangle(Console.WindowWidth / 2 - m_iWidthBox/2, Console.WindowHeight - 9, m_iWidthBox, m_iHeightBox);
            int iTextPosX = Console.WindowWidth / 2 - m_iWidthBox / 2 + 1;
            int iTextPosY = Console.WindowHeight - m_iHeightBox - 2;
            int iRightBoxPos = Console.WindowWidth / 2 - m_iWidthBox / 2 + m_iWidthBox - 2;
            //Console.WriteLine($"[{sSpeaker}]:");
            for (int i = 0; i < m_lText.Count; i++)
            {
                int index = 0;
                Console.SetCursorPosition(iTextPosX, iTextPosY);

                foreach (char letter in m_lText[i])
                {
                    bool currentCharacterIsSpace = (letter == ' ');

                    if(iTextPosY == Console.WindowHeight - 9 + m_iHeightBox - 1)
                    {
                        FillBlack(Console.WindowWidth / 2 - m_iWidthBox / 2, Console.WindowHeight - 9, m_iWidthBox, m_iHeightBox);
                        iTextPosX = Console.WindowWidth / 2 - m_iWidthBox / 2 + 1;
                        iTextPosY = Console.WindowHeight - m_iHeightBox - 2;
                        Console.SetCursorPosition(iTextPosX, iTextPosY);
                    }
                    Console.Write(letter);

                    if (currentCharacterIsSpace && iTextPosX + index > iRightBoxPos)
                    {
                        iTextPosY++;
                        Console.WriteLine();
                        iTextPosX = Console.WindowWidth / 2 - m_iWidthBox / 2 + 1;
                        Console.SetCursorPosition(iTextPosX, iTextPosY);
                        index = 0;
                        continue;
                    }

                    Thread.Sleep(40);
                    iTextPosX++;
                    index++;
                }

                TimeToRead();
                Thread.Sleep(m_lTimeToRead[i]);
                FillBlack(Console.WindowWidth / 2 - m_iWidthBox / 2, Console.WindowHeight - 9, m_iWidthBox, m_iHeightBox);
                iTextPosX = Console.WindowWidth / 2 - m_iWidthBox / 2 + 1;
                iTextPosY = Console.WindowHeight - m_iHeightBox - 2;
            }
            SetTextEnd();

        }
        public bool SetTextEnd()
        {
            return !m_bEndText;
        }
    }
}
