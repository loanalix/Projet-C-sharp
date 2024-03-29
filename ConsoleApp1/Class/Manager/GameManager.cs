using Game.Enum;
using Drawing;
using Main.Class;
using System.Runtime.InteropServices.ObjectiveC;
using Main.Class.Save;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Main.Class.Manager;

namespace Game.Class
{

    public class GameManager
    {
        #region Fields
        WindowManager m_oWindowManager;
        Player m_oPlayer;
        InputManager m_oInputManager;
        FightManager m_oFightManager;
        Inventory m_oInventory;
        Option m_oOption;
        List<Map> m_lMaps;
        Menu m_oMenu;
        Map m_oMinimap;
        Map m_oCurrentMap;
        Mob m_oMob;
        ItemsManager m_oItemsManager;
        Dialog m_oDialog;
        SaveManager m_oSave;
        Dictionary<string, string> m_dMapsInfo;
        GameState m_eCurrentGameState;
        static DrawState m_eCurrentDrawState;
        bool m_bIsRunning;
        bool m_bToggleMiniMap;
        public bool test;
        #endregion;

        #region Property
        public enum GameState {startMenu = 0, menu = 1, start = 2, run = 3 }
        public enum DrawState {menu = 0, game = 1, fight = 2, option = 3, inventory = 4, dialog = 5, miniMap = 6, inFight = 7 }

        public DrawState GetSetDrawState { get => m_eCurrentDrawState; set => m_eCurrentDrawState = value; }
        public GameState GetSetGameState { get => m_eCurrentGameState; set => m_eCurrentGameState = value; }
        #endregion

        #region Constructor
        public GameManager()
        {
            m_eCurrentGameState = GameState.startMenu;
            m_eCurrentDrawState = DrawState.game;
        }
        #endregion

        #region Methods
        public void Game()
        {
            //Ici on gère en fonction de l'état de la partie si il faut initier des variables ou les utiliser
            switch (m_eCurrentGameState)
            {
                case GameState.startMenu:
                    m_oMenu = new Menu();
                    m_oInputManager = new InputManager();
                    m_oWindowManager = new WindowManager();

                    m_oMenu.LoadMenu("../../../txt/Menu.txt");
                    
                    LoadInputState();

                    m_eCurrentGameState = GameState.menu;
                    m_oWindowManager.SetCursorVisibility(false);
                    Game();
                    break;
                case GameState.menu:
                    m_eCurrentDrawState = DrawState.menu;
                    while(m_eCurrentGameState == GameState.menu)
                    {
                        DrawScene();
                        m_oInputManager.GetInput(m_eCurrentDrawState);
                    }

                    Game();
                    break;

                case GameState.start:

                    Console.Clear();
                    m_oItemsManager = new ItemsManager();
                    m_oInventory = new Inventory();
                    m_oPlayer = new Player(m_oItemsManager, m_oInventory);
                    m_oFightManager = new FightManager();
                    m_lMaps = new List<Map>();
                    m_oFightManager = new FightManager();
                    m_oOption = new Option(m_oInventory);
                    m_oDialog = new Dialog();
                    m_oSave = new SaveManager();
                    m_dMapsInfo = new Dictionary<string, string>()
                    {
                        {"../../../txt/map.txt", "map"},
                        {"../../../txt/rootBeginer.txt", "map1" },
                        {"../../../txt/choseHero.txt", "fightMenu"},
                        {"../../../txt/FightUI.txt", "fightUI" },
                        {"../../../txt/attackUI.txt", "attackUI" },
                    };
                    
                    m_oMinimap = new Map("minimap");

                    Attack.CreateAttacks();
                    Heroes.CreateHeroes();
                    Ennemy.CreateEnnemies();
                    string test = "Connaissez-vous william le yordle ? Faites attention à lui, il a une capacité à être extrêmement" +
                        " cringe faisant fuir les gens ou les corrompant à la williamite aïgue";
                    Dialog.SetDialog(test);

                    CreateMaps();

                    LoadAllMap();

                    char[] spawnable = new char[] { 'p' };
                    m_lMaps[0].Object = m_oItemsManager.SpawnObject(m_lMaps[0], spawnable,4);
                    char[] map1Spawnable = new char[] { 'p', 'g' };
                    m_lMaps[1].Object = m_oItemsManager.SpawnObject(m_lMaps[1], map1Spawnable, 4);

                    m_bToggleMiniMap = false;

                    m_oCurrentMap = m_lMaps[0];

                    m_oWindowManager.SetCursorVisibility(false);
                    m_bIsRunning = true;

                    m_eCurrentGameState = GameState.run;
                    Game();
                    break;

                case GameState.run:
                    GameLoop();
                    break;
            }
        }
        public void GameLoop()
        {
            while (m_bIsRunning)
            {
                DrawScene();
                m_oInputManager.GetInput(m_eCurrentDrawState);
                string sCurrentMap = m_oCurrentMap.ChangeMap(m_oPlayer, m_lMaps, m_oCurrentMap.GetName);
                m_oCurrentMap = m_lMaps.Find(obj => obj.GetName == sCurrentMap);
            }

        }
        public void DrawScene()
        {
            //Ici on gère en fonction des différents états ce qu'il faut render à l'écran
            switch (m_eCurrentDrawState)
            {
                case DrawState.menu:
                    m_oMenu.DrawMenu();
                    break;
                case DrawState.game:
                    m_oWindowManager.Draw(m_oPlayer, m_oCurrentMap);
                    break;
                case DrawState.option:
                    m_oWindowManager.Draw(m_oPlayer, m_oCurrentMap);
                    m_oOption.DrawOption();
                    break;
                case DrawState.dialog:
                    m_oWindowManager.Draw(m_oPlayer, m_oCurrentMap);
                    Dialog.DrawDialog();
                    if (Dialog.SetTextEnd()) m_eCurrentDrawState = DrawState.game;
                    break;
                case DrawState.miniMap:
                    m_oMinimap.DrawMiniMap(m_oMinimap);
                    break;
                case DrawState.inventory:
                    Console.Clear();
                    m_oWindowManager.Draw(m_oPlayer, m_oCurrentMap);
                    m_oInventory.AfficherInventaire();
                    break;
                case DrawState.fight:
                    Console.Clear();
                    m_oFightManager.FightSteps();
                    break;
            }

        }
        
        public static void ToggleMenu()
        {
            switch (m_eCurrentDrawState)
            {
                case DrawState.game:
                    m_eCurrentDrawState = DrawState.option;
                    break;
                case DrawState.inFight:
                case DrawState.option:
                    m_eCurrentDrawState = DrawState.inventory;
                    break;
                case DrawState.inventory:
                    m_eCurrentDrawState = DrawState.game;
                    break;
            }
        }
        public static void StartFight(bool bIsPokeDead)
        {
            //Permet de déclencher les fights
            if (bIsPokeDead == true)
            {
                m_eCurrentDrawState = DrawState.fight;
            }
            else if (m_eCurrentDrawState == DrawState.game)
            {
                m_eCurrentDrawState = DrawState.fight;
            } 
            else if(m_eCurrentDrawState == DrawState.fight)
            {
                m_eCurrentDrawState = DrawState.inFight;
            }
            else
            {
                m_eCurrentDrawState = DrawState.game;
            }
        }

        public static void StartDialog()
        {
            //Permet de déclencher les dialogues
            m_eCurrentDrawState = DrawState.dialog;
        }
        public void LoadAllMap()
        {
            //On load les affichages des fights
            m_oFightManager.LoadMaps(m_lMaps, "fightMenu");
            m_oFightManager.LoadMaps(m_lMaps, "fightUI");
            m_oFightManager.LoadMaps(m_lMaps, "attackUI");


            //On load l'affichage de la minimap
            m_oMinimap.LoadMap("../../../txt/minimap.txt");
        }
        public void CreateMaps()
        {
            //Pour chaque element du dictionnaire on appel addMaps pour toute les maps
            foreach (KeyValuePair<string, string> entry in m_dMapsInfo)
            {
                AddMaps(entry.Key, entry.Value);
            }
        }
        public void AddMaps(string sFileName, string sMapName)
        {
            Map map = new Map(sMapName);
            map.LoadMap(sFileName);
            m_lMaps.Add(map);
        }

        public void ToggleMiniMap()
        {
            //On vérifie si la minimap peut être ouverte ou non
            m_bToggleMiniMap = !m_bToggleMiniMap;
            if (m_bToggleMiniMap) m_eCurrentDrawState = DrawState.miniMap;
            else m_eCurrentDrawState = DrawState.game;
        }

        public void LoadInputState()
        {
            //On creer un dictionnaire par state pour l'input manager
            Dictionary<string, Action> stateMenu = new Dictionary<string, Action>()
                    {
                        {"UpArrow", ()=> m_oMenu.SelectOptionUp()},
                        {"DownArrow", ()=> m_oMenu.SelectOptionDown()},
                        {"Enter", ()=> m_oMenu.SelectOptionEnter(this) },
                    };
            m_oInputManager.AddState(DrawState.menu, stateMenu);

            Dictionary<string, Action> stateGame = new Dictionary<string, Action>()
                    {
                        {"UpArrow", ()=> m_oPlayer.MoveUp(m_oCurrentMap.GetWidth, m_oCurrentMap)},
                        {"DownArrow", ()=> m_oPlayer.MoveDown(m_oCurrentMap.GetWidth, m_oCurrentMap) },
                        {"RightArrow", ()=> m_oPlayer.MoveRight(m_oCurrentMap.GetWidth , m_oCurrentMap) },
                        {"LeftArrow", ()=> m_oPlayer.MoveLeft(m_oCurrentMap.GetWidth, m_oCurrentMap) },
                        {"m",()=> ToggleMiniMap()},
                        {"Escape", ()=> ToggleMenu() },
                    };

            m_oInputManager.AddState(DrawState.game, stateGame);

            Dictionary<string, Action> stateOption = new Dictionary<string, Action>()
                    {
                        {"UpArrow", ()=> m_oOption.SelectOptionUp()},
                        {"DownArrow", ()=> m_oOption.SelectOptionDown()},
                        {"Enter", ()=> m_oOption.SelectOptionEnter(this) },
                        {"Escape", ()=> ToggleMenu() },

                    };
            m_oInputManager.AddState(DrawState.option, stateOption);

            Dictionary<string, Action> stateInventory = new Dictionary<string, Action>()
                    {
                        {"Escape", ()=> ToggleMenu() },

                    };
            m_oInputManager.AddState(DrawState.inventory, stateInventory);

            Dictionary<string, Action> stateDialog = new Dictionary<string, Action>()
                    {
                        {"UpArrow", ()=> m_oOption.SelectOptionUp()},
                        {"DownArrow", ()=> m_oOption.SelectOptionDown()},
                        {"Enter", ()=> m_oOption.SelectOptionEnter(this) },
                        {"Escape", ()=> ToggleMenu() },

                    };
            m_oInputManager.AddState(DrawState.dialog, stateDialog);

            Dictionary<string, Action> stateFight = new Dictionary<string, Action>()
                    {
                        {"UpArrow", ()=> m_oFightManager.MoveUpward()},
                        {"DownArrow", ()=> m_oFightManager.MoveDownward()},
                        {"Enter", ()=> m_oFightManager.Enter() },
                        {"Escape", ()=> ToggleMenu() }
                    };
            m_oInputManager.AddState(DrawState.fight, stateFight);

            Dictionary<string, Action> stateMiniMap = new Dictionary<string, Action>()
                    {
                        {"m",()=> ToggleMiniMap()},
                    };

            m_oInputManager.AddState(DrawState.miniMap, stateMiniMap);

            Dictionary<string, Action> stateInFight = new Dictionary<string, Action>()
            {
                { "D1", ()=> m_oFightManager.ChoseMenuElement(1) },
                { "D2", ()=> m_oFightManager.ChoseMenuElement(2) },
                { "D3", ()=> m_oFightManager.ChoseMenuElement(3) },
                { "D4", ()=> m_oFightManager.ChoseMenuElement(4) },
                { "Escape", ()=> m_oFightManager.ChoseMenuElement(5) },
            };
            m_oInputManager.AddState(DrawState.inFight, stateInFight);
        }
        public void Save()
        {
            List<MapData> mapData = new List<MapData>();
            foreach (Map map in m_lMaps)
            {
                mapData.Add(map.GetMapData());
            };

            GameData gameData = new GameData(m_oPlayer.GetPlayerData(), mapData, m_eCurrentGameState, m_eCurrentDrawState);

        }


        #endregion
    }

}
