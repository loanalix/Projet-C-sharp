using Game.Enum;

namespace Game.Class
{
    public class FightManager
    {

        #region Fields

        private Game.Class.Type type;
        private List<char> m_lMap = new List<char>();
        private List<char> m_lMapFight = new List<char>();
        private List<char> m_lMapAttack = new List<char>();
        private List<Attack> m_lAttack = new List<Attack>();
        private List<Attack> normals = new List<Attack>();
        private List<Attack> spells = new List<Attack>();
        private List<Attack> special = new List<Attack>();
        private List<Attack> stuns = new List<Attack>();
        private List<Mob> allMobs = new List<Mob>();
        private Ennemy ennemy;
        private Heroes hero;
        private int m_iPosX;
        private int m_iPosY;
        private int leaveTries;
        private bool pokemonLoaded;
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
            pokemonLoaded = false;
            random = new Random();
        }

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
        public Heroes chosenHero(int i)
        {
            if (i == null) throw new ArgumentException("i is null");
            List<Heroes> hero = allMobs.OfType<Heroes>().ToList();
            return hero[i];
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
        public void InitFightStuff(List<Mob> mob)
        {
            if (mob == null) throw new ArgumentException("Mob is null");
            m_lAttack = Attack.AttackList();
            Ennemy.CreateEnnemies();
            InitializeAttacks(mob);
            pokemonLoaded = true;
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
            float leave = CalculateFlee(hero, ennemy, leaveTries);
            float leaveProbability = leave * 100 / 255;
            int randomChance = random.Next(0, 100);
            leaveTries++;
            return randomChance < leaveProbability;
        }
        public void DrawMob()
        {

            hero.Draw(false);

            ennemy.Draw(true);

        }

        public void FightSteps()
        {
            if(pokemonLoaded == false) InitFightStuff(allMobs);
            switch (m_state)
            {
                case FightState.menu:
                    Console.SetCursorPosition(0, 0);
                    FightMenu();
                    break;
                case FightState.fight:
                    GameManager.StartFight();
                    Fight();
                    break;
            }
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
            //FightInputs();
        }
        public void FightInputs()
        {
            input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.D1)
            {
                if(m_inFightState == FightState.waitting)
                {
                    m_inFightState = FightState.attack;
                }
                else
                {
                    hero.PerformAttackTo(ennemy, hero.GetHeroSpellAttack.GetAttackName);
                    m_inFightState = FightState.waitting;
                }
            }
            else if (input.Key == ConsoleKey.D2)
            {
                if (m_inFightState == FightState.waitting)
                {
                    Console.WriteLine("selected Inventaire");
                }
                else
                {
                    hero.PerformAttackTo(ennemy, hero.GetHeroStunAttack.GetAttackName);
                    m_inFightState = FightState.waitting;
                }
            }
            else if (input.Key == ConsoleKey.D3)
            {
                if (m_inFightState == FightState.waitting)
                {
                    if (attemptToFlee())
                    {
                        Console.WriteLine("Flee success");
                        pokemonLoaded = false;
                    }
                    else
                    {
                        Console.WriteLine("Flee failed");
                        return;
                    }
                }
                else
                {
                    hero.PerformAttackTo(ennemy, hero.GetHeroNormalAttack.GetAttackName);
                    m_inFightState = FightState.waitting;
                }
            }
            else if(input.Key == ConsoleKey.D4)
            {
                if (m_inFightState == FightState.waitting) return;
                hero.PerformAttackTo(ennemy, hero.GetHeroSpecialAttack.GetAttackName);
                m_inFightState = FightState.waitting;
            }
            else if(input.Key == ConsoleKey.Escape)
            {
                if (m_inFightState == FightState.waitting) return;
                m_inFightState = FightState.waitting;
            }
            else return;
        }
        public void ChoseMenuElement(int element)
        {
            switch(element)
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
                        Fight();
                    }
                    break;
                case 2:
                    if (m_inFightState == FightState.waitting)
                    {
                        Console.WriteLine("selected Inventaire");
                    }
                    else
                    {
                        hero.PerformAttackTo(ennemy, hero.GetHeroStunAttack.GetAttackName);
                        m_inFightState = FightState.waitting;
                        Fight();
                    }
                    break;
                case 3:
                    if (m_inFightState == FightState.waitting)
                    {
                        if (attemptToFlee())
                        {
                            Console.WriteLine("Flee success");
                            pokemonLoaded = false;
                        }
                        else
                        {
                            Console.WriteLine("Flee failed");
                            return;
                        }
                    }
                    else
                    {
                        hero.PerformAttackTo(ennemy, hero.GetHeroNormalAttack.GetAttackName);
                        m_inFightState = FightState.waitting;
                        Fight();
                    }
                    break;
                case 4:
                    if (m_inFightState == FightState.waitting) return;
                    hero.PerformAttackTo(ennemy, hero.GetHeroSpecialAttack.GetAttackName);
                    m_inFightState = FightState.waitting;
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
                    TakeAnEnnemy();
                    m_state = FightState.fight;
                    NewPokemon(hero.Name);
                    NewPokemon(ennemy.Name);
                    Console.Clear();
                    break;
                case 46:
                    hero = chosenHero(1);
                    TakeAnEnnemy();
                    m_state = FightState.fight;
                    NewPokemon(hero.Name);
                    NewPokemon(ennemy.Name);
                    Console.Clear();
                    break;
                case 67:
                    hero = chosenHero(2);
                    TakeAnEnnemy();
                    m_state = FightState.fight;
                    NewPokemon(hero.Name);
                    NewPokemon(ennemy.Name);
                    Console.Clear();
                    break;
            }
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
            Console.WriteLine("Combat Starter: " + (dAttackerProbability < dAttackProbabilityH1 ? h1.Name : opponent.Name));
        }
        public void AttackOpponent(Mob h1, Mob h2)
        {
            if (h1 == null || h2 == null || h1 == h2) { throw new ArgumentException("Entity is null or Entities are the same"); }
            type.UseAttack(h1, h2);
        }

        #endregion

    }
}
