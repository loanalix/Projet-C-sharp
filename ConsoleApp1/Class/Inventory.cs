using Game.Class;
using Main.Class;
using Main.Class.Save;

namespace Game.Class
{
    
    public  class Inventory
    {
        #region Field
        private List<GameObject> items;
        #endregion

        #region Methode
        public Inventory()
        {
            items = new List<GameObject>();
        }
        #region //-----------AddItem-----------//
        public void AddItem(GameObject item)
        {
            items.Add(item);

            Dialog.SetDialog($"'{item.Name}' a été ajouté à votre inventaire.");
            Dialog.DrawDialog(" ");
            Console.Clear();
        }
        #endregion


        #region //--------UseItem-------//
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
        #endregion


        #region//------AfficherInventaire-----//
        public void AfficherInventaire()
        {
            Console.SetCursorPosition(0,0);
            if (items.Count == 0)
            {
                Console.WriteLine("L'inventaire est vide.");
                Console.WriteLine("                      ");
                Console.WriteLine("                      ");
                Console.WriteLine("                      ");

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
        #endregion


        public InventoryData GetInventoryData()
        {
            InventoryData data = new InventoryData();
            data.m_lItems = items;
            return data;
        }
        #endregion
    }
}
