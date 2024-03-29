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

    }
}
