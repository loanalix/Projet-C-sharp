using Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Character;
using System.Dynamic;

namespace Game
{
    internal class WindowManager
    {
        Draw m_oDraw;

        public Draw GetDraw {  get { return m_oDraw; } }
        public WindowManager() {
            m_oDraw = new Draw();
        }

        public void SetCursor()
        {
            Console.SetCursorPosition(0, 0);
        }
        public void SetCursorVisibility(bool isVisible)
        {
            Console.CursorVisible = isVisible;
        }
        public void Draw(Player oPlayer, string sCurrentMap)
        {
            m_oDraw.DrawMap(oPlayer,m_oDraw.GetMap[sCurrentMap]);
        }

    }
}
