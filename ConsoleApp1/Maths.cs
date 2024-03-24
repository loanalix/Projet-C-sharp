using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class Maths
    {
        public static int[] ConvertCoordTo2D(int iWidth, int pos)
        {
            int[] coord = new int[2];
            coord[0] = pos / iWidth;
            coord[1] = pos % iWidth;
            return coord;
        }
        public static int ConvertTo1Dim(int x, int y, int width)
        {
            return y * width + x;
        }
    }
}
