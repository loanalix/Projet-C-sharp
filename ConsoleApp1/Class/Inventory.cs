﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Object;
using Game.UsableItem;

namespace Game.Inventory
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
            items.Add (item);
            Console.WriteLine($"'{item.Name}' a été ajouté à l'inventaire.");
        }

        public void UseItem(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                if (items[index] is Item usableItem)
                {
                    usableItem.Use();
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
    }
}