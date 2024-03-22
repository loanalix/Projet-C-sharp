using Game.Class;
using static Main.Class.GameManager;

namespace Game.Class
{
    public class InputManager
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
            input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.UpArrow)
            {
                ProcessInput(CurrentState, "UpArrow");
            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
                ProcessInput(CurrentState, "DownArrow");

            }
            else if (input.Key == ConsoleKey.RightArrow)
            {  
                ProcessInput(CurrentState, "RightArrow");

            }
            else if (input.Key == ConsoleKey.LeftArrow)
            {

                ProcessInput(CurrentState, "LeftArrow");

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
        #endregion
    }
}