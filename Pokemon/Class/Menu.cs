﻿using Game.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Game.Class.GameManager;

namespace Main.Class
{
    public class Menu
    {
        #region Fields
        List<char> m_lMenu;
        int m_iWidth;
        int m_iHeight;
        int m_iSelectedOption;
        string[] m_sChoices;
        #endregion

        #region Property
        public int GetWidth { get => m_iWidth; }
        public int GetHeight { get => m_iHeight; }

        #endregion
        #region Constructor 
        public Menu() 
        {
            m_lMenu = new List<char>();
            m_iWidth = 0;
            m_iHeight = 0;
            m_iSelectedOption = 0;
            m_sChoices = new string[3] { "Nouvelle Partie       ", "Charger une partie      ", "Quitter      " };
        }
        #endregion
        public void SelectOptionUp()
        {
            m_iSelectedOption = Math.Max(0, m_iSelectedOption - 1);
             //Music.PlayMusic("../../../Music/Button.wav"));
           
        }
        public void SelectOptionDown()
        {
            m_iSelectedOption = Math.Min(m_sChoices.Length - 1, m_iSelectedOption + 1);
            //Music.PlayMusic("../../../Music/Button.wav"));

        }
        public void SelectOptionEnter(GameManager oManager)
        {
            switch (m_iSelectedOption)
            {
                case 0:
                    oManager.GetSetGameState = GameState.start;
                    break;
                case 1:
                    oManager.LoadSave();
                    break;
                case 2:
                    Music.PlayMusic("../../../Music/Button.wav");
                    Environment.Exit(0);
                    break;
            }
        }

        public void LoadMenu(string sFileName)
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
                    m_lMenu.Add(cChar[i]);
                }
                fileHeight++;
            }
            m_iHeight = fileHeight;
        }

        public void DrawMenu()
        {
            int PosY = 0;
            for (int i = 0; i < m_lMenu.Count; i++)
            {
                
                switch (m_lMenu[i])
                {
                    case 'b':
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        break;
                    case ' ':
                        Console.ResetColor();
                        break;
                    case '~':
                        Console.BackgroundColor= ConsoleColor.DarkYellow;
                        break;
                    case '/':
                        Console.ResetColor();
                        Console.WriteLine();
                        break;
                }
                if (m_lMenu[i] != '/')
                {
                   
                    Console.Write(' ');
                }
                else { PosY++; Console.SetCursorPosition(13, PosY); }
            }
            for (int i = 0; i < m_sChoices.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight - 5 + i);
                if (i == m_iSelectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                
                Console.WriteLine(m_sChoices[i]);

            }
        }
    }
}