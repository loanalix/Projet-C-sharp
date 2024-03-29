using System.Security.Cryptography;
using Game.Enum;

namespace Game.Class
{
    public class FightManager
    {

        #region Fields

        private Game.Class.Type type;
        #region int
        private int m_iPosX;
        private int m_iPosY;
        private int m_iLeaveTries;
        private int m_iTurns;
        private int m_iFightStarter;
        #endregion
        #region bool
        private bool m_bPokemonLoad;
        private bool m_bUseFunction;
        private bool m_bFightOnGoing;
        private bool m_bAnyHeroAlive;
        #endregion
        #region List
        private List<char> m_lMap = new List<char>();
        private List<char> m_lMapFight = new List<char>();
        private List<char> m_lMapAttack = new List<char>();
        private List<Attack> m_lAttack = new List<Attack>();
        private List<Attack> normals = new List<Attack>();
        private List<Attack> spells = new List<Attack>();
        private List<Attack> special = new List<Attack>();
        private List<Attack> stuns = new List<Attack>();
        private List<Mob> allMobs = new List<Mob>();
        #endregion
        private Ennemy ennemy;
        private Heroes hero;
        private ConsoleKeyInfo input;
        private Random random;

        private enum FightState { menu = 0, fight = 1, waitting = 2, attack = 3 }
        private FightState m_state = 0;
        private FightState m_inFightState = FightState.waitting;

        public List<Mob> GetAllMobs { get => allMobs; }

        #endregion

        #region Property

        public ConsoleKeyInfo Input { get => input; }

        #endregion

        #region Methode

        public FightManager()
        {
            type = new Game.Class.Type();
            allMobs = Mob.GetAllMobs;
            m_iPosX = 4;
            m_iPosY = 2;
            m_bPokemonLoad = false;
            m_bFightOnGoing = false;
            m_iFightStarter = 0;
            random = new Random();
        }

        public void FightSteps()
        {
            if(m_bPokemonLoad == false) InitFightStuff(allMobs);
            switch (m_state)
            {
                case FightState.menu:
                    Console.SetCursorPosition(0, 0);
                    FightMenu();
                    break;
                case FightState.fight:
                    GameManager.StartFight(false);
                    Fight();
                    break;
            }
        }
        #region Fight Draw
        public void LoadMaps(List<Map> map, string sMapName)
        {
            if (map == null || sMapName == null) throw new ArgumentException("map or sMapName is null or undefined");
            switch (map.Find(x => x.GetName == sMapName).GetName)
            {
                case "fightMenu":
                    List<char> menu = map[2].GetMap;
                    m_lMap = menu;
                    break;
                case "fightUI":
                    List<char> fUI = map[3].GetMap;
                    m_lMapFight = fUI;
                    break;
                case "attackUI":
                    List<char> aUI = map[4].GetMap;
                    m_lMapAttack = aUI;
                    break;
                default:
                    break;
            }
        }
        public void DrawMob()
        {

            hero.Draw(false);

            ennemy.Draw(true);

        }
        public string replaceString(List<char> mRef)
        {
            string line = new string(mRef.ToArray());
            if (mRef == m_lMapFight)
            {
                line = line.Replace("{heroName}", hero.Name);
                line = line.Replace("{CurrentHP}", hero.HP.ToString());
                line = line.Replace("{MaxHp}", hero.MaxHP.ToString());
                line = line.Replace("{levelH}", hero.Level.ToString());
                line = line.Replace("{CurrentMana}", hero.Mana.ToString());
                line = line.Replace("{MaxMana}", hero.MaxMana.ToString());

                line = line.Replace("{MaxHpO}", ennemy.MaxHP.ToString());
                line = line.Replace("{CurrentHPO}", ennemy.HP.ToString());
                line = line.Replace("{EnnemyName}", ennemy.Name);
                line = line.Replace("{MaxManaO}", ennemy.MaxMana.ToString());
                line = line.Replace("{CurrentManaO}", ennemy.Mana.ToString());
                line = line.Replace("{levelO}", ennemy.Level.ToString());
            }
            else if (mRef == m_lMapAttack)
            {
                line = line.Replace("{Spell}", hero.GetHeroSpellAttack.GetAttackName);
                line = line.Replace("{Stun}", hero.GetHeroStunAttack.GetAttackName);
                line = line.Replace("{Attack}", hero.GetHeroNormalAttack.GetAttackName);
                line = line.Replace("{Special}", hero.GetHeroSpecialAttack.GetAttackName);
            }
            else if(mRef.Any())
            {
                throw new ArgumentException("List<char> list is null or undefined");
            }

            return line;
        }
        public void FightMenu()
        {
            for (int i = 0; i < m_lMap.Count; i++)
            {
                switch (m_lMap[i])
                {
                    case 'X':
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(' ');
                        break;
                    case ' ':
                        Console.ResetColor();
                        Console.Write(' ');
                        break;
                    case '/':
                        Console.ResetColor();
                        Console.WriteLine();
                        break;
                    default:
                        Console.Write(m_lMap[i]);
                        break;
                }
                if (i == Maths.ConvertTo1Dim(m_iPosX, m_iPosY, 21))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('*');
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        public void Fight()
        {
            void Draw(List<char> map)
            {
                if (map == null) throw new ArgumentException("map is null or undefined");
                foreach (char c in replaceString(map))
                {
                    switch (c)
                    {
                        case '/':
                            Console.ResetColor();
                            Console.WriteLine();
                            break;
                        default:
                            Console.Write(c);
                            break;
                    }
                }
            }

            Console.Clear();
            DrawMob();
            if(m_inFightState == FightState.waitting)
            {
                Draw(m_lMapFight);
            }
            else if(m_inFightState == FightState.attack)
            {
                Draw(m_lMapAttack);
            }
            if(m_bUseFunction == true) CalculateWhoIsStarting(hero, ennemy);
            if (m_iFightStarter == 0)
            {
                Console.WriteLine("Your turn!");
                Console.WriteLine("Press 1, 2 or 3 to fight!");
            }
            else Console.WriteLine("Ennemy's turn" + "\n" + "Press any key to continue");

            if(hero.HP == 0)
            {
                ennemy.ResetStats(true);
                ResetFightState();
                Console.Clear();
                GameManager.StartFight(true);
                FightSteps();
            }
            else if(ennemy.HP == 0)
            {
                ennemy.ResetStats(false);
                hero.ResetStats(true);
                ResetFightState();
                GameManager.StartFight(false);
            }
        }
        #endregion
        #region Fight Logic
        public void InitializeAttacks(List<Mob> mob)
        {
            if (mob == null) throw new ArgumentException("List<Mob> mob is null or undefined");
            foreach (Attack attack in m_lAttack)
            {
                switch(attack.GetAttackClass)
                {
                    case Attack.AttackClass.Attack:
                        normals.Add(attack);
                        break;
                    case Attack.AttackClass.Special:
                        special.Add(attack);
                        break;
                    case Attack.AttackClass.Stun:
                        stuns.Add(attack);
                        break;
                    case Attack.AttackClass.Spell:
                        spells.Add(attack);
                        break;
                    default:
                        break;
                }
            }

            random = new Random();
            var mobIndex = mob.Select(m => m.GetEntityType).ToList();
            List<Attack> filteredNormalAttacks = normals.Where(attack => mobIndex.Contains(attack.GetAttackType)).ToList();
            List<Attack> filteredsSpellAttacks = spells.Where(attack => mobIndex.Contains(attack.GetAttackType)).ToList();
            List<Attack> filteredStunAttacks = stuns.Where(attack => mobIndex.Contains(attack.GetAttackType)).ToList();
            List<Attack> filteredSpecialAttacks = special.Where(attack => mobIndex.Contains(attack.GetAttackType)).ToList();

            Attack selectedNormalAttackOne = filteredNormalAttacks[random.Next(filteredNormalAttacks.Count)];
            Attack selectedNormalSpecial = filteredSpecialAttacks[random.Next(filteredSpecialAttacks.Count)];
            Attack selectedSpell = filteredsSpellAttacks[random.Next(filteredsSpellAttacks.Count)];
            Attack selectedStun = filteredStunAttacks[random.Next(filteredStunAttacks.Count)];

            foreach (Mob m in mob)
            {
                if (m is Ennemy)
                {
                    m.AddAttacks(selectedNormalAttackOne.GetAttackName);
                    m.AddAttacks(selectedNormalSpecial.GetAttackName);
                    m.AddAttacks(selectedSpell.GetAttackName);
                    m.AddAttacks(selectedStun.GetAttackName);
                }
                else return;
            }
        }
        public void TakeAnEnnemy()
        {
            List<Ennemy> ennemies = allMobs.OfType<Ennemy>().ToList();
            int chosenEnnemy = random.Next(0, ennemies.Count);
            ennemy = ennemies[chosenEnnemy];
        }
        public void ChangeTurn()
        {
            m_iFightStarter = (m_iFightStarter == 0) ? 1 : 0;
            m_iTurns++;
            if(m_iTurns == 2)
            {
                m_iTurns = 0;
                HandleRounds();
            }
        }
        public void HandleRounds()
        {
            hero.UpdateMana(35);
            ennemy.UpdateMana(35);
        }
        public void IA_PerformAttack()
        {
            int chosenAttack = random.Next(0, m_lAttack.Count);
            ennemy.PerformAttackTo(hero, m_lAttack[chosenAttack].GetAttackName);
            ChangeTurn();
            Fight();
            Console.WriteLine(ennemy.Name + " used: " + m_lAttack[chosenAttack].GetAttackName);
        }
        public Heroes chosenHero(int i)
        {
            if (i == null) throw new ArgumentException("i is null");
            List<Heroes> hero = allMobs.OfType<Heroes>().ToList();
            return hero[i];
        }
        public void CheckIfHeroesIsAlive(Heroes hero)
        {
            m_bAnyHeroAlive = false;
            foreach(Heroes h in Heroes.GetHeroes)
            {
                if(h.HP > 0)
                {
                    m_bAnyHeroAlive = true;
                    break;
                }
            }

            if(m_bAnyHeroAlive == false)
            {
                Console.Clear();
                Console.WriteLine("All your pokemons are dead, you lose GG");
                Thread.Sleep(1500);
                Environment.Exit(0);
            }

            if (hero.HP == 0)
            {
                Console.WriteLine("This pokemon is dead, chose another one");
                return;
            }
            else if (m_bFightOnGoing == true)
            {
                m_state = FightState.fight;
                NewPokemon(hero.Name);
                NewPokemon(ennemy.Name);
            }
            else
            {
                TakeAnEnnemy();
                m_state = FightState.fight;
                NewPokemon(hero.Name);
                NewPokemon(ennemy.Name);
                m_bFightOnGoing = true;
            }
            Console.Clear();
        }
        public void ResetFightState()
        {
            m_state = FightState.menu;
        }
        public void InitFightStuff(List<Mob> mob)
        {
            if (mob == null) throw new ArgumentException("Mob is null");
            m_lAttack = Attack.AttackList;
            InitializeAttacks(mob);
            m_bPokemonLoad = true;
        }
        private void NewPokemon(string sName)
        {
            if (sName == null) throw new ArgumentException("sName can't be null");
            Mob poke = GetAllMobs.Find(heros => heros.Name == sName);
            poke.LoadMob("../../../txt/pokemon/" + sName + ".txt");
        }
        private float CalculateFlee(Mob h1, Mob opponent, int tries)
        {
            return ((h1.Speed * 128 / opponent.Speed) + 30 * tries) % 256;
        }
        private bool attemptToFlee()
        {
            float leave = CalculateFlee(hero, ennemy, m_iLeaveTries);
            float leaveProbability = leave * 100 / 255;
            int randomChance = random.Next(0, 100);
            m_iLeaveTries++;
            return randomChance < leaveProbability;
        }
        public void CalculateWhoIsStarting(Mob h1, Mob opponent)
        {
            if (h1 == null || opponent == null || h1 == opponent) { throw new ArgumentException("Entity is null or Entities are the same"); }
            h1.GenerateIVSpeed();
            opponent.GenerateIVSpeed();
            int iSpeedDiff = Math.Abs(h1.FinalSpeed - opponent.FinalSpeed);

            double dAttackProbabilityH1 = (double)iSpeedDiff / 100;
            double dAttackProbabilityH2 = 1 - dAttackProbabilityH1;

            Random random = new Random();
            double dAttackerProbability = random.NextDouble();

            //Console.WriteLine(" ");
            //Console.WriteLine("dAttackerProbability => " + dAttackerProbability);
            //Console.WriteLine("h1 => " + dAttackProbabilityH1);
            //Console.WriteLine("h2 => " + dAttackProbabilityH2);
            if (dAttackerProbability < dAttackProbabilityH1)
            {
                m_iFightStarter = 0;
            }
            else
            {
                m_iFightStarter = 1;
            }
            m_bUseFunction = false;
        }
        public void AttackOpponent(Mob h1, Mob h2)
        {
            if (h1 == null || h2 == null || h1 == h2) { throw new ArgumentException("Entity is null or Entities are the same"); }
            type.UseAttack(h1, h2);
        }
        #endregion
        #region Fight Menu Logic
        public void ChoseMenuElement(int element)
        {
            if (m_iFightStarter == 1)
            {
                if(ennemy.GetStunState == true)
                {
                    ennemy.Stun();
                    ChangeTurn();
                }
                else
                {
                    IA_PerformAttack();
                }
            }
            else
            {
                if (hero.GetStunState == true)
                {
                    hero.Stun();
                    ChangeTurn();
                }
                else
                {
                    switch (element)
                    {
                        case 1:
                            if (m_inFightState == FightState.waitting)
                            {
                                m_inFightState = FightState.attack;
                                Fight();
                            }
                            else
                            {
                                hero.PerformAttackTo(ennemy, hero.GetHeroSpellAttack.GetAttackName);
                                m_inFightState = FightState.waitting;
                                ChangeTurn();
                                Fight();
                            }
                            break;
                        case 2:
                            if (m_inFightState == FightState.waitting)
                            {
                                Console.WriteLine("Inventaire opened");
                                //GameManager.ToggleMenu();
                            }
                            else
                            {
                                hero.PerformAttackTo(ennemy, hero.GetHeroStunAttack.GetAttackName);
                                m_inFightState = FightState.waitting;
                                ChangeTurn();
                                Fight();
                            }
                            break;
                        case 3:
                            if (m_inFightState == FightState.waitting)
                            {
                                if (attemptToFlee())
                                {
                                    Console.WriteLine("Flee success");
                                    ResetFightState();
                                    GameManager.StartFight(false);
                                }
                                else
                                {
                                    Console.WriteLine("Flee failed");
                                    ChangeTurn();
                                    return;
                                }
                            }
                            else
                            {
                                hero.PerformAttackTo(ennemy, hero.GetHeroNormalAttack.GetAttackName);
                                m_inFightState = FightState.waitting;
                                ChangeTurn();
                                Fight();
                            }
                            break;
                        case 4:
                            if (m_inFightState == FightState.waitting) return;
                            hero.PerformAttackTo(ennemy, hero.GetHeroSpecialAttack.GetAttackName);
                            m_inFightState = FightState.waitting;
                            ChangeTurn();
                            Fight();
                            break;
                        case 5:
                            if (m_inFightState == FightState.waitting) return;
                            m_inFightState = FightState.waitting;
                            Fight();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void MoveUpward()
        {
            if(m_iPosY - 1 == 0)
            {
                return;
            } 
            else
            {
                m_iPosY += Maths.MoveUpOrLeft();
            }
        }

        public void MoveDownward()
        {
            if (m_iPosY + 1 == 4)
            {
                return;
            }
            else
            {
                m_iPosY += Maths.MoveDownOrRight();
            }
        }

        public void Enter()
        {
            int selectedHero = Maths.ConvertTo1Dim(m_iPosX, m_iPosY, 21);
            switch (selectedHero)
            {
                case 25:
                    hero = chosenHero(0);
                    CheckIfHeroesIsAlive(hero);
                    break;
                case 46:
                    hero = chosenHero(1);
                    CheckIfHeroesIsAlive(hero);
                    break;
                case 67:
                    hero = chosenHero(2);
                    CheckIfHeroesIsAlive(hero);
                    break;
            }
        }
        #endregion

        #endregion
    }
}