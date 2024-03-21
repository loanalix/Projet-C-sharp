using Game.Character;
using Drawing;

namespace Game.InputController
{
    public class InputManager
    {
        ConsoleKeyInfo input;
        
        public ConsoleKeyInfo Input { get => input; }

        public void GetInput(Player m_oPlayer, Draw oDraw, string currentMap)
        {
            input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.UpArrow)
            {
                if (m_oPlayer.CheckCollide(oDraw, m_oPlayer.PosX, m_oPlayer.PosY-1, currentMap))
                {
                    m_oPlayer.MoveUp();
                }
            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
                if (m_oPlayer.CheckCollide(oDraw, m_oPlayer.PosX, m_oPlayer.PosY + 1, currentMap))
                {
                    m_oPlayer.MoveDown();

                }
            }
            else if (input.Key == ConsoleKey.RightArrow)
            {
                if (m_oPlayer.CheckCollide(oDraw, m_oPlayer.PosX + 1, m_oPlayer.PosY, currentMap))
                {
                    m_oPlayer.MoveRight();

                }
            }
            else if (input.Key == ConsoleKey.LeftArrow)
            {
                if (m_oPlayer.CheckCollide(oDraw, m_oPlayer.PosX - 1, m_oPlayer.PosY, currentMap))
                {
                    m_oPlayer.MoveLeft();

                }
            }

        }
    }
}