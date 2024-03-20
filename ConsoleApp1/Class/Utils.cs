using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Utils
    {

        public static int ConvertTo1Dim(int x, int y, int width)
        {
            return y * width + x;
        }

        public static int MoveUpOrLeft()
        {
            return -1;
        }
        public static int MoveDownOrRight()
        {
            return 1;
        }
    }
}
