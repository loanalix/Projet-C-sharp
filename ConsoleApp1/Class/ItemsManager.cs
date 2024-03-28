using Game.Class;

namespace Game.Class
{
    public class ItemsManager
    {
        Random rand;
        List<GameObject> m_lItems;
        public ItemsManager()
        {
            rand = new Random();
            m_lItems= new List<GameObject>();
        }
        public int[] SpawnObject(Map oMap, char[] spawnChar, int iNumberObject)
        {
            //On fait spawn des objets aléatoirement parmis une list de string
            int[] iObject = new int[iNumberObject];
            string[] itemsName = new string[6] { "Potion de soin", "Potion de vitesse" , "Potion d'attaque" , "Hyper Potion" , "Potion de défense", "Potion de mana"};

            //La list dessous renvoie les cases sur lesquelles un objet peu spawn;
            List<int> spawnObject = oMap.SpawnableObject(oMap, spawnChar);
            int[] coord = new int[2];
            for (int i = 0; i < iNumberObject; i++)
            {
                int randomObject = rand.Next(0, itemsName.Length);
                Item item = new Item(itemsName[randomObject]);

                int randomIndex = rand.Next(0, spawnObject.Count);
                int chooseNumber = spawnObject[randomIndex];

                coord = Maths.ConvertCoordTo2D(oMap.GetWidth, chooseNumber);
                item.posX = coord[0];
                item.posY = coord[1];
                item.Pos1D = chooseNumber;

                spawnObject.RemoveAt(randomIndex);
                iObject[i] = chooseNumber;

                m_lItems.Add(item);

            }
            return iObject;
        }

        public GameObject FindItem(int iPos)
        {
            return m_lItems.Find(x => x.Pos1D == iPos);
        }
        public int[] RemoveObject(int[] iObject, int iPos)
        {
            //Lorsque le joueur ramasse l'objets on le supprime de la liste Object
            int indexToDelete = Array.IndexOf(iObject, iPos);
            int[] newObjects = new int[iObject.Length - 1];

            if (indexToDelete != -1)
            {
                Array.Copy(iObject, 0, newObjects, 0, indexToDelete);
                Array.Copy(iObject, indexToDelete + 1, newObjects, indexToDelete, iObject.Length - indexToDelete - 1);
            }
                
            return newObjects;
        }
    }
}
