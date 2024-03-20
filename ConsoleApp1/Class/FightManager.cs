using Game.Enum;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Class;

namespace Game.Class
{
    public class FightManager
    {

        #region Field

        private Type type;

        #endregion

        #region Methode

        public FightManager()
        {
            type = new Type();
        }

        public void StartFight()
        {
            StreamReader reader = File.OpenText("../../../txt/choseHero.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                char[] characters = line.ToCharArray();

                for (int i = 0; i < characters.Length - 1; i++)
                {
                    char currentChar = characters[i];
                    char nextChar = characters[i + 1];

                    if (currentChar == ' ' && nextChar == 'X')
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(currentChar);
                        i++;
                    }
                    else if (currentChar == 'X' && nextChar == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(currentChar);
                        i++;
                    }
                    else if (currentChar == 'X' && nextChar == ' ')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(currentChar);
                        i++;
                    }
                    else if (currentChar == ' ' && nextChar == ' ')
                    {
                        Console.ResetColor();
                        Console.Write(currentChar);
                        i++;
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(currentChar);
                    }
                }

                // Afficher le dernier caractère de la ligne
                char lastChar = characters[characters.Length - 1];
                if (lastChar == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.Write(lastChar);

                // Réinitialiser la couleur après chaque ligne
                Console.ResetColor();
                Console.WriteLine();

                // appeler l'handle input pour tester la suite des bails
            }
        }



        public static void CalculateWhoIsStarting(Mob h1, Mob h2)
        {
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
