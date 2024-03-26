using Game.Class;

namespace Game.Class
{
    internal class PotionMana : Item
    {
        public int ManaHeal { get; set; }

        public PotionMana(string name, int manaHeal) : base(name)
        {
            ManaHeal = manaHeal;
        }

        public override void Use(Player player, Mob target)
        {
            Console.WriteLine($"L'objet {Name} a été utilisée pour re donner {ManaHeal} points de mana.");
        }
    }
}
