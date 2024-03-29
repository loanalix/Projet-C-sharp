using Game.Class;

namespace Game.Class
{
    public class Option : GameManager
    {
        #region Fields
        private Inventory m_oInventory;
        int m_iSelectedOption;
        string[] m_sMenuOptions;
        #endregion

        #region Property
        public Option (Inventory inventory)
        {
            m_iSelectedOption = 0;
            m_sMenuOptions = new string[4] { "Potion       ","Pokémon      ", "Sauvegarder  ", "Quitter      " };
            m_oInventory = inventory;
        }
        #endregion

        #region Methode 

        #region //----Affiche---//
        public void DrawOption()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < m_sMenuOptions.Length; i++)
            {
                if (i == m_iSelectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(m_sMenuOptions[i]);

            }
        }
        #endregion
        public void SelectOptionUp()
        {
            m_iSelectedOption = Math.Max(0, m_iSelectedOption - 1);
        }
        public void SelectOptionDown()
        {
            m_iSelectedOption = Math.Min(m_sMenuOptions.Length - 1, m_iSelectedOption + 1);
        }
        public void SelectOptionEnter(GameManager oManager)
        {
            switch (m_iSelectedOption)
            {
                case 0:
                    oManager.GetSetDrawState = DrawState.inventory;
                    break;
                case 1:
                    oManager.GetSetDrawState = DrawState.pokemon;
                    break;
                case 2:
                    oManager.Save();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }

            Console.WriteLine($"Vous avez sélectionnée {m_iSelectedOption}");
        }

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
