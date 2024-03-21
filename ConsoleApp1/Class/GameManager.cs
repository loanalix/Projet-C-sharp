using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawing;
using Game;
using Game.Character;
using Game.Map;
using Game.InputController;
using Game.FightController;
using Game.Entity;
using Game.Enum;
using Game.Brewing;
using Game.Inventory;
using System.Globalization;

namespace Main.Class
{
    internal class GameManager
    {
        WindowManager m_oWindowManager;
        Player m_oPlayer;
        Map m_oMap;
        InputManager m_oInputManager;
        FightManager m_oFightManager;
        Draw m_oDraw;
        string m_sCurrentMap;

        public enum GameState { start = 0, run = 1 };
        public enum DrawState { game = 0, fight = 1, menu = 2 }


        GameState m_eCurrentGameState;
        DrawState m_eCurrentDrawState;
        bool m_bIsRunning; 

        public GameManager() {

            m_eCurrentGameState = GameState.start;
            m_eCurrentDrawState = DrawState.game;
        }

        public void GameLoop()
        {
            while (m_bIsRunning)
            {
                m_oWindowManager.SetCursor();
                m_oInputManager.GetInput(m_oPlayer,m_oWindowManager.GetDraw, m_sCurrentMap);

                m_sCurrentMap = m_oMap.ChangeMap(m_oPlayer, m_sCurrentMap);
                DrawScene();
            }
            
        }
       
        public void Game()
        {
            switch (m_eCurrentGameState)
            {
                case GameState.start:

                    m_oWindowManager = new WindowManager();
                    m_oPlayer = new Player();
                    m_oMap = new Map(); 
                    m_oInputManager = new InputManager();
                    m_oFightManager = new FightManager();
                    m_oMap.oDraw = m_oWindowManager.GetDraw;
                    m_oDraw = m_oWindowManager.GetDraw;
                    m_sCurrentMap = "map";

                    Dictionary<string, Action> stateRun = new Dictionary<string, Action>()
                    {
                        {"UpArrow", ()=> m_oPlayer.MoveUp(m_oDraw, m_sCurrentMap)},
                        {"DownArrow", ()=> m_oPlayer.MoveDown(m_oDraw, m_sCurrentMap) },
                        {"RightArrow", ()=> m_oPlayer.MoveRight(m_oDraw, m_sCurrentMap) },
                        {"LeftArrow", ()=> m_oPlayer.MoveLeft(m_oDraw, m_sCurrentMap) }
                    };
                    InputManager.AddState
                    m_oDraw.LoadMap("../../../txt/map.txt", "map");
                    m_oDraw.LoadMap("../../../txt/rootBeginer.txt", "map1");

                    m_oWindowManager.SetCursorVisibility(false);
                    m_bIsRunning = true;

                    m_eCurrentGameState = GameState.run;
                    Game();
                    break;

                case GameState.run:
                    DrawScene();
                    GameLoop();
                    break;
            }
        }

        public void DrawScene()
        {
            switch (m_eCurrentDrawState)
            {
                case DrawState.game:
                    m_oWindowManager.Draw(m_oPlayer, m_sCurrentMap);
                    break;
                case DrawState.menu:
                    break;

                case DrawState.fight:
                    break;
            }

        }
    }

}
