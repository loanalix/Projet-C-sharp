using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Class;
using Game;
using Game.Enum;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace Main.Class
{
    public class GameManager
    {
        WindowManager m_oWindowManager;
        Player m_oPlayer;
        Map m_oMap;
        InputManager m_oInputManager;
        FightManager m_oFightManager;
        Draw m_oDraw;
        Mob m_oMob;

        List<Map> m_lMaps;
        Map m_oCurrentMap;

        public enum GameState { start = 0, run = 1 };
        public enum DrawState { game = 0, fight = 1, menu = 2 }


        GameState m_eCurrentGameState;
        public DrawState m_eCurrentDrawState;
        bool m_bIsRunning; 

        public GameManager() {

            m_eCurrentGameState = GameState.start;
            m_eCurrentDrawState = DrawState.game;
            m_lMaps= new List<Map>();
        }

        public void GameLoop()
        {
            while (m_bIsRunning)
            {
                m_oWindowManager.SetCursor(0,0);
                m_oInputManager.GetInput(DrawState.game);
                string test = m_oCurrentMap.ChangeMap(m_oPlayer, m_oCurrentMap, m_oMob);
                m_oCurrentMap = m_lMaps.Find(obj => obj.GetName == test);
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
                    m_oInputManager = new InputManager();
                    m_oFightManager = new FightManager();
                    m_oMob = new Mob("ennemi",100,10,5.0f,20.0f,10,Types.Fire);
                    AddMaps("../../../txt/map.txt", "map");
                    AddMaps("../../../txt/rootBeginer.txt", "map1");
                    m_oCurrentMap = m_lMaps[0];
                    m_oDraw = m_oWindowManager.GetDraw;

                    Dictionary<string, Action> stateGame = new Dictionary<string, Action>()
                    {
                        {"UpArrow", ()=> m_oPlayer.MoveUp(m_oCurrentMap.GetWidth, m_oCurrentMap.GetMap)},
                        {"DownArrow", ()=> m_oPlayer.MoveDown(m_oCurrentMap.GetWidth, m_oCurrentMap.GetMap) },
                        {"RightArrow", ()=> m_oPlayer.MoveRight(m_oCurrentMap.GetWidth , m_oCurrentMap.GetMap) },
                        {"LeftArrow", ()=> m_oPlayer.MoveLeft(m_oCurrentMap.GetWidth, m_oCurrentMap.GetMap) }
                    };
                    m_oInputManager.AddState(DrawState.game, stateGame);                    

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
                    m_oWindowManager.Draw(m_oPlayer, m_oCurrentMap);
                    break;
                case DrawState.menu:
                    break;

                case DrawState.fight:
                    break;
            }

        }
        public void AddMaps(string sFileName, string sMapName)
        {
            Map map = new Map(sMapName);
            map.LoadMap(sFileName);
            m_lMaps.Add(map);
        }
    }

}
