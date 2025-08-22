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

        // Câu 5: Generate random list of Points
        public static List<Point> Generate()
        {
            List<Point> points = new List<Point>();
            Random rand = new Random();
            for (int i = 0; i < 50; i++)
            {
                if (rand.Next(2) == 1) // true/false randomly
                {
                    float x = (float)(rand.NextDouble() * 100);
                    float y = (float)(rand.NextDouble() * 100);
                    float z = (float)(rand.NextDouble() * 100);
                    points.Add(new Point(x, y, z));
                }
            }
            return points;
        }

        // Câu 7: Circumference
        public double Circumference()
        {
            return Point.Distance(A, B) + Point.Distance(B, C) + Point.Distance(C, A);
        }

        // Câu 8: Area using Heron's formula
        public double Area()
        {
            double ab = Point.Distance(A, B);
            double bc = Point.Distance(B, C);
            double ca = Point.Distance(C, A);
            double s = (ab + bc + ca) / 2;
            return Math.Sqrt(s * (s - ab) * (s - bc) * (s - ca));
        }

        // Câu 9: Print all angles
        public void Angle()
        {
            double angleA = Angle(A, B, C);
            double angleB = Angle(B, C, A);
            double angleC = Angle(C, A, B);
            Console.WriteLine($"Góc tại A: {angleA} độ");
            Console.WriteLine($"Góc tại B: {angleB} độ");
            Console.WriteLine($"Góc tại C: {angleC} độ");
        }

        // Câu 9: Angle at vertex a, with b and c as other two points
        public double Angle(Point a, Point b, Point c)
        {
            // Vector ab and ac
            double[] ab = { b.X - a.X, b.Y - a.Y, b.Z - a.Z };
            double[] ac = { c.X - a.X, c.Y - a.Y, c.Z - a.Z };
            double dot = ab[0] * ac[0] + ab[1] * ac[1] + ab[2] * ac[2];
            double magAB = Math.Sqrt(ab[0] * ab[0] + ab[1] * ab[1] + ab[2] * ab[2]);
            double magAC = Math.Sqrt(ac[0] * ac[0] + ac[1] * ac[1] + ac[2] * ac[2]);
            if (magAB == 0 || magAC == 0) return 0;
            double cosTheta = dot / (magAB * magAC);
            cosTheta = Math.Max(-1, Math.Min(1, cosTheta)); // Clamp
            double angleRad = Math.Acos(cosTheta);
            return Math.Round(angleRad * 180 / Math.PI, 2);
        }
    }
}
