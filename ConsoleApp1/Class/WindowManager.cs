
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Class;
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

        public void SetCursor(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
        }
        public void SetCursorVisibility(bool isVisible)
        {
            Console.CursorVisible = isVisible;
        }
        public void Draw(Player oPlayer, Map oMap)
        {
            m_oDraw.DrawMap(oPlayer,oMap.GetMap);
        }

    }
}
