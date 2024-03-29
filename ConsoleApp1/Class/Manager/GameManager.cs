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
        List<Dialog> m_loDialogs;
        GameState m_eCurrentGameState;
        static DrawState m_eCurrentDrawState;
        bool m_bIsRunning;
        bool m_bToggleMiniMap;
        bool m_bLoad;
        #endregion;

        #region Property
        public enum GameState {startMenu = 0, menu = 1, start = 2, run = 3 }
        public enum DrawState {menu = 0, game = 1, fight = 2, option = 3, inventory = 4, pokemon = 5, dialog = 6, miniMap = 7, inFight = 8 }

        public DrawState GetSetDrawState { get => m_eCurrentDrawState; set => m_eCurrentDrawState = value; }
        public GameState GetSetGameState { get => m_eCurrentGameState; set => m_eCurrentGameState = value; }
        #endregion

        #region Constructor
        public GameManager()
        {
            m_bLoad = false;
            m_oCurrentMap = null;
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
                    m_lMaps = new List<Map>();

                    //Music.BackGroundMusic("../../../Music/Titre.wav");

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
                        m_oInputManager.ProcessInput(m_eCurrentDrawState);
                    }

                    Game();
                    break;

                case GameState.start:

                    Console.Clear();
                    if (m_bLoad)
                    {
                        InitInstancesLoad();
                    }
                    else
                    {
                        InitInstances();
                        CreateMaps();
                        
                        char[] spawnable = new char[] { 'p' };
                        m_lMaps[0].Object = m_oItemsManager.SpawnObject(m_lMaps[0], spawnable, 4);
                        char[] map1Spawnable = new char[] { 'p', 'g' };
                        m_lMaps[1].Object = m_oItemsManager.SpawnObject(m_lMaps[1], map1Spawnable, 4);
                        SetCurrentMap();
                        Attack.CreateAttacks();
                        Heroes.CreateHeroes();
                    }
                    LoadAllMap();
                    m_bToggleMiniMap = false;


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
            //Music.BackGroundMusic("../../../Music/Route1.wav");
            while (m_bIsRunning)
            {
                DrawScene();
                m_oInputManager.ProcessInput(m_eCurrentDrawState);
                //m_oInputManager.GetInput(m_eCurrentDrawState);
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
                    NewDialogs();
                    m_oWindowManager.Draw(m_oPlayer, m_oCurrentMap);
                    m_loDialogs[0].DrawDialog(m_loDialogs[0]);
                    if (m_loDialogs[0].SetTextEnd()) m_eCurrentDrawState = DrawState.game;
                    break;
                case DrawState.miniMap:
                    m_oMinimap.DrawMiniMap(m_oMinimap);
                    break;
                case DrawState.inventory:
                    Console.Clear();
                    m_oWindowManager.Draw(m_oPlayer, m_oCurrentMap);
                    m_oInventory.AfficherInventaire();
                    break;
                case DrawState.pokemon:
                    Console.Clear();
                    m_oWindowManager.Draw(m_oPlayer, m_oCurrentMap);
                    DrawPokemonOption();
                    break;
                case DrawState.fight:
                    
                    Console.Clear();
                    m_oFightManager.FightSteps();
                    break;
            }

        }

        #region Option
        public void DrawPokemonOption()
        {
            Console.SetCursorPosition(0, 0);
            foreach (Heroes heros in Heroes.GetHeroes)
            {
                Console.WriteLine($"- {heros.Name}");
            }

        }
        #endregion

        #region Init's Function
        public void InitInstances()
        {
            m_oItemsManager = new ItemsManager();
            m_oInventory = new Inventory();
            m_oPlayer = new Player(m_oItemsManager, m_oInventory);
            m_oFightManager = new FightManager();
            m_oFightManager = new FightManager();
            m_oOption = new Option(m_oInventory);
            m_oSave = new SaveManager();
            m_loDialogs = new List<Dialog>();
            m_dMapsInfo = new Dictionary<string, string>()
                    {
                        {"../../../txt/map.txt", "map"},
                        {"../../../txt/rootBeginer.txt", "map1" },
                        {"../../../txt/choseHero.txt", "fightMenu"},
                        {"../../../txt/FightUI.txt", "fightUI" },
                        {"../../../txt/attackUI.txt", "attackUI" },
                    };

            m_oMinimap = new Map("minimap");
        }

        public void InitInstancesLoad()
        {
            m_oItemsManager = new ItemsManager();
            m_oFightManager = new FightManager();
            m_oFightManager = new FightManager();
            m_oOption = new Option(m_oInventory);
            m_oSave = new SaveManager();
            m_loDialogs = new List<Dialog>();
            m_dMapsInfo = new Dictionary<string, string>()
                    {
                        {"../../../txt/map.txt", "map"},
                        {"../../../txt/rootBeginer.txt", "map1" },
                        {"../../../txt/choseHero.txt", "fightMenu"},
                        {"../../../txt/FightUI.txt", "fightUI" },
                        {"../../../txt/attackUI.txt", "attackUI" },
                    };

            m_oMinimap = new Map("minimap");
        }
        #endregion

        #region start's Function
        public static void StartFight()
        {
            //Music.BackGroundMusic("../../../Music/Combat.wav");
            //Permet de déclencher les fights
            if (m_eCurrentDrawState == DrawState.game)
            {
                m_eCurrentDrawState = DrawState.fight;
            } 
            else
            {
                m_eCurrentDrawState = DrawState.inFight;
            }
        }

        public static void StartDialog()
        {
            //Permet de déclencher les dialogues
            m_eCurrentDrawState = DrawState.dialog;
        }
        #endregion

        #region Map's Function

        public void SetCurrentMap()
        {
            m_oCurrentMap = m_lMaps[0];
        }
        public void SetCurrentMap(MapData oCurrentMap)
        {
            m_oCurrentMap = m_lMaps.Find(map => map.GetName == oCurrentMap.m_sName);
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
        public void AddMaps(MapData oMap)
        {
            Map map = new Map(oMap);
            m_lMaps.Add(map);   
        }
        #endregion

        #region Dialog's Function
        public void NewDialogs()
        {
            string sPnj = "Connaissez-vous william le yordle ? Faites attention à lui, il a une capacité à être extrêmement" +
                       " cringe faisant fuir les gens ou les corrompant à la williamite aïgue";
            AddDialogs(sPnj);
        }
        public void AddDialogs(string sText)
        {
            Dialog dialog = new Dialog(sText);
            m_loDialogs.Add(dialog);
        }
        #endregion

        #region Toggles State Function
        public void ToggleMenu()
        {
            switch (m_eCurrentDrawState)
            {
                case DrawState.game:
                    //case DrawState.fight:
                    m_eCurrentDrawState = DrawState.option;
                    break;
                case DrawState.option:
                    m_eCurrentDrawState = DrawState.inventory;
                    break;
                case DrawState.inventory:
                    m_eCurrentDrawState = DrawState.game;
                    break;
                case DrawState.pokemon:
                    m_eCurrentDrawState = DrawState.game;
                    break;
            }
        }
        public void ToggleMiniMap()
        {
            //On vérifie si la minimap peut être ouverte ou non
            m_bToggleMiniMap = !m_bToggleMiniMap;
            if (m_bToggleMiniMap) m_eCurrentDrawState = DrawState.miniMap;
            else m_eCurrentDrawState = DrawState.game;
        }
        #endregion

        #region Input's Function
        public void LoadInputState()
        {
            //On creer un dictionnaire par state pour l'input manager
            Dictionary<ConsoleKey, Action> stateMenu = new Dictionary<ConsoleKey, Action>()
                    {
                        {ConsoleKey.UpArrow, ()=> m_oMenu.SelectOptionUp()},
                        {ConsoleKey.DownArrow, ()=> m_oMenu.SelectOptionDown()},
                        {ConsoleKey.Enter, ()=> m_oMenu.SelectOptionEnter(this) },
                    };
            m_oInputManager.AddState(DrawState.menu, stateMenu);

            Dictionary<ConsoleKey, Action> stateGame = new Dictionary<ConsoleKey, Action>()
                    {
                        {ConsoleKey.UpArrow, ()=> m_oPlayer.MoveUp(m_oCurrentMap.GetWidth, m_oCurrentMap)},
                        {ConsoleKey.DownArrow, ()=> m_oPlayer.MoveDown(m_oCurrentMap.GetWidth, m_oCurrentMap) },
                        {ConsoleKey.RightArrow, ()=> m_oPlayer.MoveRight(m_oCurrentMap.GetWidth , m_oCurrentMap) },
                        {ConsoleKey.LeftArrow, ()=> m_oPlayer.MoveLeft(m_oCurrentMap.GetWidth, m_oCurrentMap) },
                        {ConsoleKey.M, ()=> ToggleMiniMap()},
                        {ConsoleKey.Escape, ()=> ToggleMenu() },
                    };

            m_oInputManager.AddState(DrawState.game, stateGame);

            Dictionary<ConsoleKey, Action> stateOption = new Dictionary<ConsoleKey, Action>()
                    {
                        {ConsoleKey.UpArrow, ()=> m_oOption.SelectOptionUp()},
                        {ConsoleKey.DownArrow, ()=> m_oOption.SelectOptionDown()},
                        {ConsoleKey.Enter, ()=> m_oOption.SelectOptionEnter(this) },
                        {ConsoleKey.Escape, ()=> ToggleMenu() },

                    };
            m_oInputManager.AddState(DrawState.option, stateOption);

            Dictionary<ConsoleKey, Action> stateInventory = new Dictionary<ConsoleKey, Action>()
                    {
                        {ConsoleKey.Escape, ()=> ToggleMenu() },

                    };
            m_oInputManager.AddState(DrawState.inventory, stateInventory);

            Dictionary<ConsoleKey, Action> statePokemon = new Dictionary<ConsoleKey, Action>()
                    {
                        {ConsoleKey.Escape, ()=> ToggleMenu() },

                    };
            m_oInputManager.AddState(DrawState.pokemon, statePokemon);

            Dictionary<ConsoleKey, Action> stateDialog = new Dictionary<ConsoleKey, Action>()
                    {
                        {ConsoleKey.UpArrow, ()=> m_oOption.SelectOptionUp()},
                        {ConsoleKey.DownArrow, ()=> m_oOption.SelectOptionDown()},
                        {ConsoleKey.Enter, ()=> m_oOption.SelectOptionEnter(this) },
                        {ConsoleKey.Escape, ()=> ToggleMenu() },

                    };
            m_oInputManager.AddState(DrawState.dialog, stateDialog);

            Dictionary<ConsoleKey, Action> stateFight = new Dictionary<ConsoleKey, Action>()
                    {
                        {ConsoleKey.UpArrow, ()=> m_oFightManager.MoveUpward()},
                        {ConsoleKey.DownArrow, ()=> m_oFightManager.MoveDownward()},
                        {ConsoleKey.Enter, ()=> m_oFightManager.Enter() },
                        {ConsoleKey.Escape, ()=> ToggleMenu() }
                    };
            m_oInputManager.AddState(DrawState.fight, stateFight);

            Dictionary<ConsoleKey, Action> stateMiniMap = new Dictionary<ConsoleKey, Action>()
                    {
                        {ConsoleKey.M,()=> ToggleMiniMap()},
                    };

            m_oInputManager.AddState(DrawState.miniMap, stateMiniMap);

            Dictionary<ConsoleKey, Action> stateInFight = new Dictionary<ConsoleKey, Action>()
            {
                { ConsoleKey.D1, ()=> m_oFightManager.ChoseMenuElement(1) },
                { ConsoleKey.D2, ()=> m_oFightManager.ChoseMenuElement(2) },
                { ConsoleKey.D3, ()=> m_oFightManager.ChoseMenuElement(3) },
                { ConsoleKey.D4, ()=> m_oFightManager.ChoseMenuElement(4) },
                { ConsoleKey.Escape, ()=> m_oFightManager.ChoseMenuElement(5) },
            };
            m_oInputManager.AddState(DrawState.inFight, stateInFight);
        }
        #endregion

        #region Pokemon / Attack
        public void AddPokemon(HeroesData oHero)
        {
            Heroes hero = new Heroes(oHero);
        }
        public void AddAttack(AttackData oAttack)
        {
            Attack attack = new Attack(oAttack);
        }
        #endregion

        #region Save's Function 
        public void Save()
        {
            MapData m_oCurrentMapData = new MapData() ;
            m_oCurrentMapData = m_oCurrentMap.GetMapData();
            List<MapData> mapData = new List<MapData>();
            List<HeroesData> heroesDatas = new List<HeroesData>();
            List<AttackData> attackDatas = new List<AttackData>();
            foreach (Attack attack in Attack.AttackList)
            {
                attackDatas.Add(attack.GetAttackData());

            }
            foreach (Heroes hero in Heroes.GetHeroes)
            {
                heroesDatas.Add(hero.GetHeroesData());
            }
            foreach (Map map in m_lMaps)
            {
                mapData.Add(map.GetMapData());
            };

            GameData gameData = new GameData(m_oPlayer.GetPlayerData(),  mapData, heroesDatas,attackDatas, m_oCurrentMapData, m_eCurrentGameState, m_eCurrentDrawState);

            SaveManager.Save(gameData, "save.json");
        }
        public void LoadSave()
        {
            m_bLoad = true;
            GameData loadData = SaveManager.Load("save.json");
            m_oInventory = new Inventory(loadData.m_splayer.m_inventory);
            m_oPlayer = new Player(loadData.m_splayer, m_oInventory);
            for(int i = 0; i < loadData.m_lAttackData.Count; i++)
            {
                AddAttack(loadData.m_lAttackData[i]);
            }
            for(int i = 0; i < loadData.m_lHeroesData.Count; i++) 
            {
                AddPokemon(loadData.m_lHeroesData[i]);
            }
            for(int i = 0; i < loadData.m_lMapsData.Count; i++)
            {
                AddMaps(loadData.m_lMapsData[i]);
            }
            m_oCurrentMap = new Map(loadData.m_oCurrentMapData);
            m_eCurrentGameState = GameState.start;
        }
        #endregion

        #endregion
    }

}
