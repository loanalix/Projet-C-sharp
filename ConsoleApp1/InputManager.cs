using Main.Class;

namespace Main.Class
{
    public class InputManager
    {
        ConsoleKeyInfo input;
        
        public ConsoleKeyInfo Input { get => input; }

        public void GetInput(Player m_oPlayer, Draw oDraw)
        {
            input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.UpArrow)
            {
                if (m_oPlayer.CheckCollid(oDraw, m_oPlayer.PosX, m_oPlayer.PosY-1 ))
                {
                    m_oPlayer.MoveUp();
                }
            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
                if (m_oPlayer.CheckCollid(oDraw, m_oPlayer.PosX, m_oPlayer.PosY + 1))
                {
                    m_oPlayer.MoveDown();

                }
            }
            else if (input.Key == ConsoleKey.RightArrow)
            {
                if (m_oPlayer.CheckCollid(oDraw, m_oPlayer.PosX + 1, m_oPlayer.PosY))
                {
                    m_oPlayer.MoveRight();

                }
            }
            else if (input.Key == ConsoleKey.LeftArrow)
            {
                if (m_oPlayer.CheckCollid(oDraw, m_oPlayer.PosX - 1, m_oPlayer.PosY))
                {
                    m_oPlayer.MoveLeft();

                }
            }

        }
    }
}