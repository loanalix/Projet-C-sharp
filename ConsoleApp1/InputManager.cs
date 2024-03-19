namespace Main.Class
{
    public class InputManager
    {
        ConsoleKeyInfo input;
        
        public ConsoleKeyInfo Input { get => input; }

        public void GetInput(player m_oPlayer)
        {
            input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.UpArrow)
            {
                m_oPlayer.MoveUp();
            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
                m_oPlayer.MoveDown();
            }
            else if (input.Key == ConsoleKey.RightArrow)
            {
                m_oPlayer.MoveRight();
            }
            else if (input.Key == ConsoleKey.LeftArrow)
            {
                m_oPlayer.MoveLeft();
            }

        }
    }
}