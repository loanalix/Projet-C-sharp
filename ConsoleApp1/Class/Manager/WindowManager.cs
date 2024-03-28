using Game.Class;
using Drawing;

namespace Game.Class
{
    internal class WindowManager
    {
        Draw m_oDraw;

        public Draw GetDraw { get { return m_oDraw; } }
        public WindowManager()
        {
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
            SetCursor(0, 0);

            m_oDraw.DrawMap(oPlayer, oMap);
        }

    }
}
