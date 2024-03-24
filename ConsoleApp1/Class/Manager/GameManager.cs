using Game.Class;
using Game.Enum;
using Drawing;

namespace Game.Class
{
    public class GameManager
    {
        WindowManager m_oWindowManager;
        Player m_oPlayer;
        Map m_oMap;
        InputManager m_oInputManager;
        FightManager m_oFightManager;
        Inventory m_oInventory;
        Menu m_oMenu;
        Draw m_oDraw;
        Mob m_oMob;
        List<Map> m_lMaps;
        Map m_oCurrentMap;

        string[] m_sMenuOptions;

        public enum GameState { start = 0, run = 1 };
        public enum DrawState { game = 0, fight = 1, menu = 2, inventory = 3 }

        GameState m_eCurrentGameState;
        DrawState m_eCurrentDrawState;

        public DrawState GetSetDrawState { get => m_eCurrentDrawState; set => m_eCurrentDrawState = value; }

        bool m_bIsRunning;
        int m_iSelectedOption;
        public GameManager()
        {

            m_eCurrentGameState = GameState.start;
            m_eCurrentDrawState = DrawState.game;
            m_lMaps = new List<Map>();
        }

        public void GameLoop()
        {
            while (m_bIsRunning)
            {
                m_oWindowManager.SetCursor(0, 0);
                m_oInputManager.GetInput(m_eCurrentDrawState);
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
                    m_oInventory = new Inventory();
                    m_oMenu = new Menu(m_oInventory);
                    AddMaps("../../../txt/map.txt", "map");
                    AddMaps("../../../txt/rootBeginer.txt", "map1");
                    m_oCurrentMap = m_lMaps[0];
                    m_oDraw = m_oWindowManager.GetDraw;

                    Dictionary<string, Action> stateGame = new Dictionary<string, Action>()
                    {
                        {"UpArrow", ()=> m_oPlayer.MoveUp(m_oCurrentMap.GetWidth, m_oCurrentMap.GetMap)},
                        {"DownArrow", ()=> m_oPlayer.MoveDown(m_oCurrentMap.GetWidth, m_oCurrentMap.GetMap) },
                        {"RightArrow", ()=> m_oPlayer.MoveRight(m_oCurrentMap.GetWidth , m_oCurrentMap.GetMap) },
                        {"LeftArrow", ()=> m_oPlayer.MoveLeft(m_oCurrentMap.GetWidth, m_oCurrentMap.GetMap) },
                        {"Escape", ()=> ToggleMenu() },
                    };

                    m_oInputManager.AddState(DrawState.game, stateGame);

                    Dictionary<string, Action> stateMenu = new Dictionary<string, Action>()
                    {
                        {"UpArrow", ()=> m_oMenu.SelectOptionUp()},
                        {"DownArrow", ()=> m_oMenu.SelectOptionDown()},
                        {"Enter", ()=> m_oMenu.SelectOptionEnter(this) },
                        //{"LeftArrow", ()=> m_oPlayer.MoveLeft(m_oCurrentMap.GetWidth, m_oCurrentMap.GetMap) },
                        {"Escape", ()=> ToggleMenu() },

                    };
                    m_oInputManager.AddState(DrawState.menu, stateMenu);

                    Dictionary<string, Action> stateInventory = new Dictionary<string, Action>()
                    {
                        //{"UpArrow", ()=> m_oMenu.SelectOptionUp()},
                        //{"DownArrow", ()=> m_oMenu.SelectOptionDown()},
                        //{"Enter", ()=> m_oMenu.SelectOptionEnter(this) },
                        ////{"LeftArrow", ()=> m_oPlayer.MoveLeft(m_oCurrentMap.GetWidth, m_oCurrentMap.GetMap) },
                        {"Escape", ()=> ToggleMenu() },

                    };
                    m_oInputManager.AddState(DrawState.inventory, stateInventory);

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
                    m_oWindowManager.Draw(m_oPlayer, m_oCurrentMap);
                    m_oMenu.DrawMenu();
                    break;
                case DrawState.inventory:
                    Console.Clear();
                    m_oWindowManager.Draw(m_oPlayer, m_oCurrentMap);
                    m_oInventory.AfficherInventaire();
                    break;
                case DrawState.fight:
                    break;
            }

        }
        public void ToggleMenu()
        {
            switch (m_eCurrentDrawState)
            {
                case DrawState.game:
                    m_eCurrentDrawState = DrawState.menu;
                    break;
                case DrawState.menu:
                    m_eCurrentDrawState = DrawState.inventory;
                    break;
                case DrawState.inventory:
                    m_eCurrentDrawState = DrawState.game;
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
