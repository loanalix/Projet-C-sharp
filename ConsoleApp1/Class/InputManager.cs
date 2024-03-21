using Game.Character;
using Drawing;
using static Main.Class.GameManager;

namespace Game.InputController
{
    public class InputManager
    {
        ConsoleKeyInfo input;
        public Dictionary<DrawState, Dictionary<string, Action>> stateMappings;
        public ConsoleKeyInfo Input { get => input; }

        public InputManager()
        {
            stateMappings = new Dictionary<DrawState, Dictionary<string, Action>>();
        }
        public void GetInput(Player m_oPlayer, Draw oDraw, string currentMap)
        {
            input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.UpArrow)
            {
                m_oPlayer.MoveUp(oDraw, currentMap);
            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
               
                m_oPlayer.MoveDown(oDraw, currentMap);

            }
            else if (input.Key == ConsoleKey.RightArrow)
            {
                
                m_oPlayer.MoveRight(oDraw, currentMap);

            }
            else if (input.Key == ConsoleKey.LeftArrow)
            {
               
                m_oPlayer.MoveLeft(oDraw, currentMap);

            }

        }
        public void AddState(DrawState stateName, Dictionary<string, Action> keyMappings)
        {
            stateMappings[stateName] = keyMappings;
        }

        public void ProcessInput(DrawState stateName, string key)
        {
            if (stateMappings.ContainsKey(stateName) && stateMappings[stateName].ContainsKey(key))
            {
                stateMappings[stateName][key]?.Invoke();
            }
            else
            {
                Console.WriteLine($"Aucune action associée à la touche {key} dans l'état {stateName}.");
            }
        }
    }
}