namespace LT_B3_OOP
{
    public class Triangle
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }

        public static List<Point> Generate()
        {
            List<Point> points = new List<Point>();
            Random rand = new Random();
            for (int i = 0; i < 50; i++)
            {
                int random = rand.Next(0, 2);

                if (random == 0)
                {
                    continue;
                }
                else
                {
                    float x = rand.Next(-10, 10);
                    float y = rand.Next(-10, 10);
                    float z = rand.Next(-10, 10);
                    points.Add(new Point(x, y, z));
                }
            }
            return points;
        }

        public double ChuVi()
        {
            return Point.Distance(A, B) + Point.Distance(B, C) + Point.Distance(C, A);
        }

        public double DienTich()
        {
            double ab = Point.Distance(A, B);
            double bc = Point.Distance(B, C);
            double ca = Point.Distance(C, A);

            double nuaChuVi = (ab + bc + ca) / 2;

            return Math.Sqrt(nuaChuVi * (nuaChuVi - ab) * (nuaChuVi - bc) * (nuaChuVi - ca));
        }

        public void Angle()
        {
            double ab = Point.Distance(A, B);
            double bc = Point.Distance(B, C);
            double ac = Point.Distance(C, A);
            
            double angleA = Math.Acos((ab * ab + ac * ac - bc * bc) / (2 * ab * ac)) * 180 / Math.PI;
            double angleB = Math.Acos((bc * bc + ab * ab - ac * ac) / (2 * bc * ab)) * 180 / Math.PI;
            double angleC = 180 - angleA - angleB;

            Console.WriteLine($"Góc A: {angleA} độ");
            Console.WriteLine($"Góc B: {angleB} độ");
            Console.WriteLine($"Góc C: {angleC} độ");
        }
    }
}
