﻿using Game.Class;
using Game.Enum;
using Drawing;
using Main.Class;
using System.Runtime.InteropServices.ObjectiveC;
using Main.Class.Save;

namespace Game.Class
{
    
    public class GameManager
    {
        WindowManager m_oWindowManager;
        Player m_oPlayer;
        InputManager m_oInputManager;
        FightManager m_oFightManager;
        Inventory m_oInventory;
        Menu m_oMenu;
        List<Map> m_lMaps;
        Map m_oCurrentMap;
        Mob m_oMob;
        ItemsManager m_oItemsManager;
        Dialog m_oDialog;
        SaveManager m_oSave;
        public enum GameState { start = 0, run = 1 };
        public enum DrawState { game = 0, fight = 1, menu = 2, inventory = 3, dialog = 4 }

        GameState m_eCurrentGameState;
        static DrawState m_eCurrentDrawState;
        public DrawState GetSetDrawState { get => m_eCurrentDrawState; set => m_eCurrentDrawState = value; }

        bool m_bIsRunning;
        int m_iSelectedOption;
        public GameManager()
        {
            m_eCurrentGameState = GameState.start;
            m_eCurrentDrawState = DrawState.game;
            m_oFightManager = new FightManager();
            m_lMaps = new List<Map>();
            m_lMob = new List<string>();
        }

        public void GameLoop()
        {
            while (m_bIsRunning)
            {
                m_oWindowManager.SetCursor(0, 0);
                m_oInputManager.GetInput(m_eCurrentDrawState);
                string test = m_oCurrentMap.ChangeMap(m_oPlayer, m_lMaps, m_oCurrentMap.GetName);
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
                    m_oItemsManager = new ItemsManager();
                    m_oInventory = new Inventory();
                    m_oPlayer = new Player(m_oItemsManager, m_oInventory);
                    m_oInputManager = new InputManager();
                    m_oFightManager = new FightManager();
                    m_oMenu = new Menu(m_oInventory);
                    m_oDialog = new Dialog();
                    m_oSave = new SaveManager();

                    AddMaps("../../../txt/map.txt", "map");
                    AddMaps("../../../txt/rootBeginer.txt", "map1");
                    AddMaps("../../../txt/choseHero.txt", "fightMenu");
                    AddMaps("../../../txt/FightUI.txt", "fightUI");
                    m_oFightManager.LoadMaps(m_lMaps, "fightMenu");
                    m_oFightManager.LoadMaps(m_lMaps, "fightUI");

                    char[] spawnable = new char[] { 'p' };
                    m_lMaps[0].Object = m_oItemsManager.SpawnObject(m_lMaps[0], spawnable);
                    char[] map1Spawnable = new char[] { 'p', 'g' };
                    m_lMaps[1].Object = m_oItemsManager.SpawnObject(m_lMaps[1], map1Spawnable);

                    m_oCurrentMap = m_lMaps[0];

                    Dictionary<string, Action> stateGame = new Dictionary<string, Action>()
                    {
                        {"UpArrow", ()=> m_oPlayer.MoveUp(m_oCurrentMap.GetWidth, m_oCurrentMap)},
                        {"DownArrow", ()=> m_oPlayer.MoveDown(m_oCurrentMap.GetWidth, m_oCurrentMap) },
                        {"RightArrow", ()=> m_oPlayer.MoveRight(m_oCurrentMap.GetWidth , m_oCurrentMap) },
                        {"LeftArrow", ()=> m_oPlayer.MoveLeft(m_oCurrentMap.GetWidth, m_oCurrentMap) },
                        {"Escape", ()=> ToggleMenu() },
                    };

                    m_oInputManager.AddState(DrawState.game, stateGame);

                    Dictionary<string, Action> stateMenu = new Dictionary<string, Action>()
                    {
                        {"UpArrow", ()=> m_oMenu.SelectOptionUp()},
                        {"DownArrow", ()=> m_oMenu.SelectOptionDown()},
                        {"Enter", ()=> m_oMenu.SelectOptionEnter(this) },
                        {"Escape", ()=> ToggleMenu() },

                    };
                    m_oInputManager.AddState(DrawState.menu, stateMenu);

                    Dictionary<string, Action> stateInventory = new Dictionary<string, Action>()
                    {
                        {"Escape", ()=> ToggleMenu() },

                    };
                    m_oInputManager.AddState(DrawState.inventory, stateInventory);

                    Dictionary<string, Action> stateDialog = new Dictionary<string, Action>()
                    {
                        {"UpArrow", ()=> m_oMenu.SelectOptionUp()},
                        {"DownArrow", ()=> m_oMenu.SelectOptionDown()},
                        {"Enter", ()=> m_oMenu.SelectOptionEnter(this) },
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
                case DrawState.dialog:
                    m_oWindowManager.Draw(m_oPlayer, m_oCurrentMap);
                    string test = "Connaissez-vous william le yordle ? Faites attention à lui, il a une capacité à être extrêmement cringe faisant fuir les gens ou les corrompant à la williamite aïgue";
                    Dialog.SetDialog(test);
                    Dialog.DrawDialog("Loan");
                    if (Dialog.SetTextEnd()) m_eCurrentDrawState = DrawState.game;
                    
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
        
        public void ToggleMenu()
        {
            switch (m_eCurrentDrawState)
            {
                case DrawState.game:
                //case DrawState.fight:
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

        public static void StartFight()
        {
            m_eCurrentDrawState = DrawState.fight;
        }

        public void NewPokemon (string sName )
        { 

            

        }

        public static void StartDialog()
        {
            m_eCurrentDrawState = DrawState.dialog;
        }
        public void AddMaps(string sFileName, string sMapName)
        {
            Map map = new Map(sMapName);
            map.LoadMap(sFileName);
            m_lMaps.Add(map);
        }

        public void Save()
        {
            List<MapData> mapData = new List<MapData>();
            foreach(Map map in m_lMaps)
            {
                mapData.Add(map.GetMapData());
            };

            GameData gameData = new GameData(m_oPlayer.GetPlayerData(), mapData);
            
        }
    }

}
