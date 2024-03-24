using Game.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
        public int[] SpawnObject(Map oMap, char[] spawnChar)
        {

            int[] iObject = new int[6];
            string[] itemsName = new string[6] { "Potion de soin", "Potion de vitesse" , "Potion d'attaque" , "Hyper Potion" , "Potion de défense", "Potion de mana"};
            List<int> spawnObject = oMap.SpawnableObject(oMap, spawnChar);
            int[] coord = new int[2];
            for (int i = 0; i < 6; i++)
            {
                Item item = new Item(itemsName[i]);
                int randomIndex = rand.Next(0, spawnObject.Count);
                int chooseNumber = spawnObject[randomIndex];
                coord = Maths.ConvertCoordTo2D(oMap.GetWidth, chooseNumber);
                item.posX = coord[0];
                item.posY = coord[1];
                spawnObject.RemoveAt(randomIndex);
                item.Pos1D = chooseNumber;
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
