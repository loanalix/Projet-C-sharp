using Game.Class;
using Drawing;

namespace Game.Class
{
    public class InputManager : GameManager
    {
        #region Fields
        ConsoleKeyInfo input;

        public Dictionary<DrawState, Dictionary<string, Action>> stateMappings;
        #endregion

        #region Property
        public ConsoleKeyInfo Input { get => input; }
        #endregion

        #region Methode

        #endregion

        #region Constructor
        public InputManager()
        {
            stateMappings = new Dictionary<DrawState, Dictionary<string, Action>>();
        }
        #endregion

        #region Method
        public void GetInput(DrawState CurrentState)
        {
            while(Console.KeyAvailable)
            { 
                Console.ReadKey(false);
            }

            input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.UpArrow) ProcessInput(CurrentState, "UpArrow");

            else if (input.Key == ConsoleKey.DownArrow) ProcessInput(CurrentState, "DownArrow");

            else if (input.Key == ConsoleKey.RightArrow) ProcessInput(CurrentState, "RightArrow");

            else if (input.Key == ConsoleKey.LeftArrow) ProcessInput(CurrentState, "LeftArrow");
            
            else if (input.Key == ConsoleKey.M) ProcessInput(CurrentState, "m");

            else if (input.Key == ConsoleKey.Escape) ProcessInput(CurrentState, "Escape");
            
            else if (input.Key == ConsoleKey.Enter) ProcessInput(CurrentState, "Enter");


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
        #endregion
    }
}