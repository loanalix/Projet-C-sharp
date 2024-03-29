using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Main.Class
{
    public  class Dialog
    {
        #region Field
        static int m_iTimeToRead;
        static string m_sText;
        static int m_iWidthBox;
        static int m_iHeightBox;
        static bool m_bEndText;
        #endregion

        #region Property 
        public string GetText { get { return m_sText; } }
        #endregion
        #region Constructor
        public Dialog(string sDialog)
        {
            m_sText = sDialog;
            m_iTimeToRead = 0;
            m_iWidthBox = 46;
            m_iHeightBox = 6;
            m_bEndText = false;
        }
        #endregion

        public static void FillBlack(int x, int y, int width, int height)
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
        public static void DrawRectangle(int x, int y, int width, int height)
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
        

        public static void TimeToRead()
        {
            int Time = 2000;
            string world = m_sText;
            for (int j = 0; j < m_sText.Length - 1; j++)
            {
                if (world[j] == ' ')
                {
                    Time += 50;
                }
            }
            m_iTimeToRead = Time;
        }
        public void DrawDialog(Dialog oDialog)
        {

            DrawRectangle(Console.WindowWidth / 2 - m_iWidthBox/2, Console.WindowHeight - 9, m_iWidthBox, m_iHeightBox);
            
            int iTextPosX = Console.WindowWidth / 2 - m_iWidthBox / 2 + 1;
            int iTextPosY = Console.WindowHeight - m_iHeightBox - 2;
            int iRightBoxPos = Console.WindowWidth / 2 - m_iWidthBox / 2 + m_iWidthBox - 2;
            
            int index = 0;
            Console.SetCursorPosition(iTextPosX, iTextPosY);

            foreach (char letter in oDialog.GetText)
            {
                bool currentCharacterIsSpace = (letter == ' ');

                if(iTextPosY == Console.WindowHeight - 9 + m_iHeightBox - 1)
                {
                    Thread.Sleep(1500);
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
            Thread.Sleep(m_iTimeToRead);
            FillBlack(Console.WindowWidth / 2 - m_iWidthBox / 2, Console.WindowHeight - 9, m_iWidthBox, m_iHeightBox);
            SetTextEnd();
            //Music.BackGroundMusic("../../../Music/Route1.wav");
        }
        public bool SetTextEnd()
        {
            return !m_bEndText;
        }
    }
}
