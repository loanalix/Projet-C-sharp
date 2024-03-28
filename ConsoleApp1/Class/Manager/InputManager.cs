using Game.Class;
using Drawing;

namespace Game.Class
{
    public class InputManager : GameManager
    {
        #region Fields
        ConsoleKeyInfo input;

        public Dictionary<DrawState, Dictionary<ConsoleKey, Action>> stateMappings;
        #endregion

        #region Property
        public ConsoleKeyInfo Input { get => input; }
        #endregion

        #region Methode

        #endregion

        #region Constructor
        public InputManager()
        {
            stateMappings = new Dictionary<DrawState, Dictionary<ConsoleKey, Action>>();
        }
        #endregion

        #region Method
        public void AddState(DrawState stateName, Dictionary<ConsoleKey, Action> keyMappings)
        {
            stateMappings[stateName] = keyMappings;
        }

        public void ProcessInput(DrawState stateName)
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
            ConsoleKey key = Console.ReadKey(true).Key;

            if (stateMappings.ContainsKey(stateName) && stateMappings[stateName].ContainsKey(key))
            {
                stateMappings[stateName][key]?.Invoke();
            }
            
        }
        #endregion
    }
}