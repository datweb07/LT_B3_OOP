namespace LT_B3_OOP
{
    public class Point
    {
        private float x;
        private float y;
        private float z;

        public static int Counter = 0;
        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float Z
        {
            get { return z; }
            set { z = value; }
        }

        public Point(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            Counter++;
        }

        public static double Distance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) +
                             Math.Pow(b.Y - a.Y, 2) +
                             Math.Pow(b.Z - a.Z, 2));
        }
    }
}
