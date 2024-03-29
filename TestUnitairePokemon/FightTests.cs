using Game.Class;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace TestProject1
{
    public class FightTests
    {
        [Test]
        [TestCase("Dialga", "Dialga")]
        [TestCase("Zekrom", "Zekrom")]
        [TestCase("Darkrai", "Darkrai")]
        public void GetHero(string s1, string expected)
        {
            Attack.CreateAttacks();

            Heroes.CreateHeroes();

            Heroes hero = Mob.GetHeroByName(s1);
            string result = hero.Name;
            Assert.That(result, Is.EqualTo(expected));

            //Ennemy ennemy = Mob.GetEnnemyByName(s2);
            //Console.WriteLine("Pitié t'as trouvé le hero (spoiler c pikachu de base): " + hero.Name);
            //Console.WriteLine("Pitié t'as trouvé le ennemy (spoiler c Salameche de base): " + ennemy.Name);

            //Heroes heroes = Heroes.GetHeroes.Where(x => x.Name == s1);

            //Ennemy opponent = Ennemy.GetEnnemies.Where(x => x.Name == s2).ToList();

            //.AddAttacks(attacks1toS2);

            //h1.PerformAttackTo(opponent, attacks1toS2);
            //Assert.That(result, Is.EqualTo(healthexpected));

        }

        [Test]
        [TestCase("Giratina", "Giratina")]
        [TestCase("Rayquaza", "Rayquaza")]
        [TestCase("Mewtwo", "Mewtwo")]
        public void GetEnnemy(string s1, string expected)
        {
            Ennemy.CreateEnnemies();

            Ennemy ennemy = Mob.GetEnnemyByName(s1);
            string result = ennemy.Name;
            Assert.That (result, Is.EqualTo(expected));
        }


        [Test]
        [TestCase("", "", "", 10)]

        public void Damage(string s1, string s2, string s1Attacks2, int expectedHealth) 
        {
            Attack.CreateAttacks();
            Heroes.CreateHeroes();
            Ennemy.CreateEnnemies();

            Heroes hero = Mob.GetHeroByName(s1);
            Ennemy ennemy = Mob.GetEnnemyByName(s2);

            for (int i = 0; i < Attack.m_lAttack.Count ; i++) 
            {
                ennemy.AddAttacks(Attack.m_lAttack[i].GetAttackName);
            }

            hero.PerformAttackTo(ennemy, s1Attacks2);
        } 
    }
}
