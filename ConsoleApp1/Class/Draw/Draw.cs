using Game.Class;

namespace Drawing
{
    public class Draw
    {
        #region Fields
        #endregion

        #region Property
        #endregion

        #region Constructor
        public Draw() { }
        #endregion

        #region Method

        public void DrawMap(Player oPlayer, Map oMap)
        {
            List<char> lMap = oMap.GetMap;
            for (int i = oMap.GetWidth; i < lMap.Count; i++)
            {
                switch (lMap[i])
                {
                    case 'v':
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 'c':
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case 'g':
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    case 'b':
                        Console.BackgroundColor = ConsoleColor.Blue;
                        break;
                    case 'w':
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 'h':
                        Console.BackgroundColor = ConsoleColor.White;
                        break;
                    case 'p':
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        break;
                    case 's':
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case ' ':
                        Console.ResetColor();
                        break;
                    case '/':
                        Console.ResetColor();
                        Console.WriteLine();
                        break;

                }
                if (i == Maths.ConvertTo1Dim(oPlayer.PosX, oPlayer.PosY, 73))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('P');
                }
                else if (Array.Exists(oMap.Object, element => element == i))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('O');

                }
                else
                {
                    if (lMap[i] != '/')
                    {
                        Console.Write(' ');
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;

            }
        }
        #endregion
    }
}