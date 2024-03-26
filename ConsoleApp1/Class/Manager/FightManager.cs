using Tools;
using Game.Enum;
using Game.Class;

namespace Game.Class
{
    public class FightManager
    {

        #region Fields

        private Game.Class.Type type;
        private List<char> m_lMap = new List<char>();
        private List<char> m_lMapFight = new List<char>();
        private List<Attack> m_lAttack = new List<Attack>();
        private string hero;
        private int m_iPosX;
        private int m_iPosY;
        private Utils utils;
        private int apagnan = 0;
        //private int m_iWidth;
        private ConsoleKeyInfo input;

        private enum FightState { menu = 0, fight = 1 }
        private FightState m_state = 0;

        #endregion

        #region Property

        public ConsoleKeyInfo Input { get => input; }

        #endregion

        #region Methode

        public FightManager()
        {
            type = new Game.Class.Type();
            utils = new Utils();
            m_iPosX = 4;
            m_iPosY = 2;
        }

        public void LoadFightMenu()
        {
            StreamReader reader = File.OpenText("../../../txt/choseHero.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                char[] cChar = line.ToCharArray();
                for (int i = 0; i < cChar.Length; i++)
                {
                    m_lMap.Add(cChar[i]);
                }
            }
        }

        public void LoadFight()
        {
            StreamReader reader = File.OpenText("../../../txt/FightUI.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                char[] cChar = line.ToCharArray();
                for (int i = 0; i < cChar.Length; i++)
                {
                    m_lMapFight.Add(cChar[i]);
                }
            }
        }
        public void CreateAttacks(Mob mob)
            {
                // Non damage abilities
                m_lAttack.Add(new Attack("Aqua ring", Types.Flying, 0f, 0f, 15f, 30, 20, Attack.AttackType.Spell));
                m_lAttack.Add(new Attack("Stun Spore", Types.Grass, 0f, 0f, 0f, 15, 50, Attack.AttackType.Stun));
                m_lAttack.Add(new Attack("Withdraw", Types.Water, 0f, 15f, 0f, 30, 40, Attack.AttackType.Spell));
                m_lAttack.Add(new Attack("Dragon Dance", Types.Dragon, 15f, 0f, 0f, 30, 20, Attack.AttackType.Spell));
                m_lAttack.Add(new Attack("Fire shield", Types.Fire, 0f, 15f, 0f, 30, 20, Attack.AttackType.Spell));

                // Dragon
                m_lAttack.Add(new Attack("Breaking Swipe", Types.Dragon, 60f, 0f, 0f, 30, 40, Attack.AttackType.Attack));
                m_lAttack.Add(new Attack("Dragon Hammer", Types.Dragon, 90f, 0f, 0f, 40, 70, Attack.AttackType.Attack));
                m_lAttack.Add(new Attack("Dragon Claw", Types.Dragon, 80f, 0f, 0f, 35, 55, Attack.AttackType.Attack));

                m_lAttack.Add(new Attack("Dynamax Cannon", Types.Dragon, 100f, 0f, 0f, 100, 125, Attack.AttackType.Attack));

                // Grass
                m_lAttack.Add(new Attack("Trop Kick", Types.Grass, 70f, 0f, 0f, 30, 40, Attack.AttackType.Attack));
                m_lAttack.Add(new Attack("Grav Apple", Types.Grass, 40f, 7f, 0f, 30, 55, Attack.AttackType.Attack));
                m_lAttack.Add(new Attack("Power Whip", Types.Grass, 120f, 0f, 0f, 60, 90, Attack.AttackType.Attack));

                m_lAttack.Add(new Attack("Chronoblast", Types.Fire, 150f, 0f, 0f, 95, 125, Attack.AttackType.Special));

                // Fire
                m_lAttack.Add(new Attack("Flare Blitz", Types.Fire, 25f, 0f, 0f, 30, 30, Attack.AttackType.Attack));
                m_lAttack.Add(new Attack("Fire Lash", Types.Fire, 40f, 0f, 0f, 35, 45, Attack.AttackType.Attack));
                m_lAttack.Add(new Attack("Flame Charge", Types.Fire, 70f, 0f, 0f, 55, 65, Attack.AttackType.Attack));

                m_lAttack.Add(new Attack("Armor Cannon", Types.Fire, 120f, 15f, 0f, 100, 100, Attack.AttackType.Special));

                // Flying
                m_lAttack.Add(new Attack("Aerial Ace", Types.Flying, 20f, 0f, 0f, 100, 30, Attack.AttackType.Attack));
                m_lAttack.Add(new Attack("Wing Attack", Types.Flying, 45f, 0f, 0f, 100, 35, Attack.AttackType.Attack));
                m_lAttack.Add(new Attack("Dragon Ascent", Types.Flying, 80f, 15f, 0f, 100, 85, Attack.AttackType.Attack));

                m_lAttack.Add(new Attack("Air Slash", Types.Flying, 75f, 0f, 0f, 95, 85, Attack.AttackType.Special));

                // Water
                m_lAttack.Add(new Attack("Liquidation", Types.Water, 15f, 3f, 0f, 85, 25, Attack.AttackType.Attack));
                m_lAttack.Add(new Attack("Aqua tail", Types.Water, 90f, 0f, 0f, 70, 75, Attack.AttackType.Attack));
                m_lAttack.Add(new Attack("Triple Dive", Types.Water, 30f, 0f, 0f, 20, 95, Attack.AttackType.Attack));

                m_lAttack.Add(new Attack("Chilling Water", Types.Water, 50, 0f, 0f, 100, 45, Attack.AttackType.Special));

                for(int i = 0; i < m_lAttack.Count; i++)
                {
                    mob.AddAttacks(m_lAttack[i].GetAttackName);
                }
            }

        public void InitFightStuff(Mob mob)
        {
            CreateAttacks(mob);
        }

        public void FightSteps()
        {
            switch (m_state)
            {
                case FightState.menu:
                    Console.SetCursorPosition(0, 0);
                    FightMenu();
                    break;
                case FightState.fight:
                    Console.SetCursorPosition(0, 0);
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
                if (i == utils.ConvertTo1Dim(m_iPosX, m_iPosY, 21))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('*');
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }
            MenuInput();
        }

        public void Fight()
        {
            string line = new string(m_lMapFight.ToArray());

            line = line.Replace("{heroName}", hero);

            foreach (char c in line)
            {
                switch (c)
                {
                    case 'X':
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(' ');
                        break;
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

        public void MenuInput()
        {
            input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.UpArrow)
            {
                m_iPosY += utils.MoveUpOrLeft();
            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
                m_iPosY += utils.MoveDownOrRight();
            }
            else if (input.Key == ConsoleKey.RightArrow)
            {
                m_iPosX += utils.MoveDownOrRight();
            }
            else if (input.Key == ConsoleKey.LeftArrow)
            {
                m_iPosX += utils.MoveUpOrLeft();
            }
            else if (input.Key == ConsoleKey.Enter)
            {
                int selectedHero = utils.ConvertTo1Dim(m_iPosX, m_iPosY, 21);
                switch (selectedHero)
                {
                    case 25:
                        hero = "Salameche";
                        m_state = FightState.fight;
                        Console.Clear();
                        break;
                    case 46:
                        hero = "Caparuce";
                        m_state = FightState.fight;
                        Console.Clear();
                        break;
                    case 67:
                        hero = "Bulbizarre";
                        m_state = FightState.fight;
                        Console.Clear();
                        break;
                }
            }
        }

        public void CalculateWhoIsStarting(Mob h1, Mob h2)
        {
            if (h1 == null || h2 == null || h1 == h2) { throw new ArgumentException("Entity is null or Entities are the same"); }
            int iSpeedDiff = Math.Abs(h1.FinalSpeed - h2.FinalSpeed);

            double dAttackProbabilityH1 = (double)iSpeedDiff / 100;
            double dAttackProbabilityH2 = 1 - dAttackProbabilityH1;

            Random random = new Random();
            double dAttackerProbability = random.NextDouble();

            //Console.WriteLine(" ");
            //Console.WriteLine("dAttackerProbability => " + dAttackerProbability);
            //Console.WriteLine("h1 => " + dAttackProbabilityH1);
            //Console.WriteLine("h2 => " + dAttackProbabilityH2);
            Console.WriteLine("Combat Starter: " + (dAttackerProbability < dAttackProbabilityH1 ? h1.Name : h2.Name));
        }
        public void AttackOpponent(Mob h1, Mob h2)
        {
            float fDamage = type.AttackDamage(h1, h2);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Opponent Health before Attack: " + h2.HP);
            Console.WriteLine("Your Hero's Mana before Attack: " + h1.Mana + "\n");

            h2.HP -= (2 * fDamage - h2.Resistance) * 0.5f;
            h1.Mana -= h1.GetHeroAttackMana;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Opponent Health: " + h2.HP);
            Console.WriteLine("Your Hero's Mana: " + h1.Mana);
            Console.ForegroundColor = ConsoleColor.White;
        }

        #endregion

    }
}
