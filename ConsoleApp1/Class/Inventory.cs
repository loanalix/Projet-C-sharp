using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Class;

namespace Game.Class
{
    public  class Inventory
    {
        private List<GameObject> items; 

        public Inventory()
        {
            items = new List<GameObject>();
        }

        public void AddItem(GameObject item)
        { 
            items.Add(item);
            Console.WriteLine($"'{item.Name}' a été ajouté à votre inventaire.");
        }

        public void UseItem( Player player , Mob target, int index)
        {
            if (index >= 0 && index < items.Count)
            {
                if (items[index] is Item usableItem)
                {
                    usableItem.Use(player, target);
                    items.RemoveAt(index);
                }
                else 
                {
                    Console.WriteLine("Cet objet ne peut pas être utilisé.");
                }
            }
            else 
            { 
                Console.WriteLine("Index d'objet invalide."); 
            }
        }
        public void AfficherInventaire()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("L'inventaire est vide.");
            }
            else
            {
                Console.WriteLine("Contenu de l'inventaire :");
                foreach (GameObject item in items)
                {
                    Console.WriteLine($"- {item.Name}");
                }
            }
        }
    }
}
