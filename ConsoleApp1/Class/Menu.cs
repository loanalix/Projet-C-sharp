using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Class;

namespace Game.Class
{
    public class Menu
    {
        #region Fields
        private Inventory m_Inventory;
        #endregion

        #region Property
        public Menu (Inventory inventory)
        {
            m_Inventory = inventory;
        }
        #endregion

        #region Methode 

        #region //----Affiche---//
        public void Affiche() 
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Inventaire");
            Console.WriteLine("2. Équipe");
            Console.WriteLine("3. Options");
            Console.WriteLine("4. Quitter");
        }
        #endregion

        #region //----TraiterChoix---//
        public void TraiterChoix(int choix)
        {
            switch (choix)
            {
                case 1:
                    AfficherInventaire(); 
                    break;
                case 2:
                    AfficherEquipe();
                    break;
                case 3:
                    AfficherOptions();
                    break;
                case 4:
                    Console.WriteLine("Fermeture du menu.");
                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }
        }
        #endregion

        #region //----AfficherInventaire---//
        private void AfficherInventaire()
        {
            Console.WriteLine("Affichage de l'inventaire...");
            m_Inventory.AfficherInventaire();
        }
        #endregion

        #region //----AfficherEquipe---//
        private void AfficherEquipe()
        {
            Console.WriteLine("Affichage de l'équipe...");
        }
        #endregion

        #region //----AfficherOptions---//
        private void AfficherOptions()
        {
            Console.WriteLine("Affichage des options...");
         
        }
        #endregion

        #endregion
    }
}
