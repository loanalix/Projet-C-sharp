using Main.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Class
{
    public class FightManager
    {

        private Type type;

        public FightManager()
        {
            type = new Type();
        }

        public static void CalculateWhoIsStarting(Heroes h1, Heroes h2)
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

        public void AttackOpponent(Heroes h1, Heroes h2)
        {
            float fDamage = type.AttackDamage(h1, h2);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Opponent Health before Attack: " + h2.HP);
            Console.WriteLine("Your Hero's Mana before Attack: " + h1.Mana + "\n");

            h2.HP -= fDamage;
            h1.Mana -= h1.GetHeroAttackMana;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Opponent Health: " + h2.HP);
            Console.WriteLine("Your Hero's Mana: " + h1.Mana);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
