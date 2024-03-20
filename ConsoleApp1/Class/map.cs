using Game.Character;
using Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game.Map
{
    public class Map
    {

        private List<int> m_lSpawnable = new List<int>();

        
        public string ChangeMap(Player oPlayer, Draw oDraw, string sNewMap)
        {
            switch (sNewMap)
            {
                case "map":
                    if (oPlayer.PosY < 0)
                    {
                        oPlayer.PosY = oDraw.GetHeight - 4;
                        return "map1";
                    }
                    return "map";
                    break;
                case "map1":
                    return "map1";
                    break;

                default:
                    return "";
                    break;
            }
        }
        //private void UpdateMap(int iIndice, string sMove)
        //{
            
        //    int move = m_lMap.FindIndex(chara => chara == '*');
        //    int iMovement;

        //    if (sMove == "down" || sMove == "right")
        //    {
        //        iMovement = move + iIndice;
        //    }
        //    else
        //    {
        //        iMovement = move - iIndice;
        //    }

        //    m_lMap.RemoveAt(move);
        //    m_lMap.Insert(move, ' ');
        //    m_lMap.RemoveAt(iMovement);
        //    m_lMap.Insert(iMovement, '*');

        //}
        //public void Move(string sCharPressed)
        //{

        //    Console.SetCursorPosition(0, 0);
        //    switch (sCharPressed)
        //    {
        //        case "up":
        //            UpdateMap(iSizeLine, "up");
        //            break;                    
        //        case "down":
        //            UpdateMap(iSizeLine, "down");
        //            break;
        //        case "left":
        //            UpdateMap(1, "left");
        //            break;
        //        case "right":
        //            UpdateMap(1, "right");
        //            break;
        //    }
        //}
    }
}
