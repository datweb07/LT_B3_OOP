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

        public static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.Y, 2) +
                             Math.Pow(p2.Y - p1.Y, 2) +
                             Math.Pow(p2.Z - p1.Z, 2));
        }

        //public double Distance(Point other)
        //{
        //    return Math.Sqrt(Math.Pow(other.X - this.X, 2) +
        //                     Math.Pow(other.Y - this.Y, 2) +
        //                     Math.Pow(other.Z - this.Z, 2));
        //}
    }
}
