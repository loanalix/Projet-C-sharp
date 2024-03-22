namespace Tools
{
    public class Utils
    {

        public Utils() { }

        public int ConvertTo1Dim(int x, int y, int width)
        {
            return y * width + x;
        }

        public int MoveUpOrLeft()
        {
            return -1;
        }
        public int MoveDownOrRight()
        {
            return 1;
        }
    }
}
