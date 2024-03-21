using Game.Enum;
using Game.Entity;
using Drawing;
using Game.Character;
using Game.Element;

namespace Game.FightController
{
    public class FightManager
    {

        #region Field

        private Game.Element.Type type;
        private List<char> m_lMap = new List<char>();
        private int m_iPosX;
        private int m_iPosY;
        //private int m_iWidth;
        private ConsoleKeyInfo input;

        #endregion

        #region Property

        public ConsoleKeyInfo Input { get => input; }

        #endregion

        #region Methode

        public FightManager()
        {
            type = new Game.Element.Type();
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

        public void StartFight()
        {
            for (int i = 0; i < m_lMap.Count; i++)
            {
                switch(m_lMap[i])
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
                if(i == Tools.Utils.ConvertTo1Dim(m_iPosX, m_iPosY, 21))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('*');
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void MenuInput()
        {

            input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.UpArrow)
            {
                m_iPosY += Tools.Utils.MoveUpOrLeft();
            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
                m_iPosY += Tools.Utils.MoveDownOrRight();
            }
            else if (input.Key == ConsoleKey.RightArrow)
            {
                m_iPosX += Tools.Utils.MoveDownOrRight();
            }
            else if (input.Key == ConsoleKey.LeftArrow)
            {
                m_iPosX += Tools.Utils.MoveUpOrLeft();
            }
            else if (input.Key == ConsoleKey.Enter)
            {
                int selectedHero = Tools.Utils.ConvertTo1Dim(m_iPosX, m_iPosY, 21);
                switch(selectedHero)
                {
                    case 25:
                        Console.WriteLine("You've selected Salameche");
                        break;
                    case 46:
                        Console.WriteLine("You've selected Bulbizarre");
                        break;
                    case 67:
                        Console.WriteLine("You've selected Carapuce");
                        break;
                }
            }
        }


        public void CalculateWhoIsStarting(Mob h1, Mob h2)
        {
            if(h1 == null || h2 == null || h1 == h2) { throw new ArgumentException("Entity is null or Entities are the same"); }
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
