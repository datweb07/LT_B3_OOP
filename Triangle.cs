namespace LT_B3_OOP
{
    public class Triangle
    {
        private Point p1;
        private Point p2;
        private Point p3;
        public Point P1
        {
            get { return p1; }
            set { p1 = value; }
        }
        public Point P2
        {
            get { return p2; }
            set { p2 = value; }
        }
        public Point P3
        {
            get { return p3; }
            set { p3 = value; }
        }
        public Triangle(Point point1, Point point2, Point point3)
        {
            this.p1 = point1;
            this.p2 = point2;
            this.p3 = point3;
        }

        public static List<Point> Generate()
        {
            Random random = new Random();
            List<Point> points = new List<Point>();
            for (int i = 0; i < 50; i++)
            {
                if (random.Next(2) == 1) // true or false
                {
                    float x = (float)(random.NextDouble() * 100);
                    float y = (float)(random.NextDouble() * 100);
                    float z = (float)(random.NextDouble() * 100);
                    points.Add(new Point(x, y, z));
                }
            }
            return points;
        }

        //public static List<Point> Generate()
        //{
        //    for (int i = 0; i < 50; i++)
        //    {
        //        List<Point> points = new List<Point>();

        //    }
        //}

        public double Circumference()
        {
            return Point.Distance(p1, p2) + Point.Distance(p2, p3) + Point.Distance(p3, p1);
        }

        public double Area()
        {
            double a = Point.Distance(p1, p2);
            double b = Point.Distance(p2, p3);
            double c = Point.Distance(p3, p1);

            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public double Angle()
        {
            double a = Point.Distance(p1, p2);
            double b = Point.Distance(p1, p3);
            double c = Point.Distance(p2, p3);

            
            return 0;
        }



    }
}
