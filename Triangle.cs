namespace LT_B3_OOP
{
    public class Triangle
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public Triangle(Point a, Point b, Point c)
        {
            // Kiểm tra điều kiện tạo thành tam giác trước khi khởi tạo
            if (!IsValidTriangle(a, b, c))
            {
                throw new ArgumentException("Ba điểm không thể tạo thành tam giác hợp lệ!");
            }

            A = a;
            B = b;
            C = c;
        }

        public static bool IsValidTriangle(Point a, Point b, Point c)
        {
            double ab = Point.Distance(a, b);
            double bc = Point.Distance(b, c);
            double ca = Point.Distance(c, a);

            if (ab == 0 || bc == 0 || ca == 0)
            {
                return false;
            }

            // Tổng 2 cạnh phải lớn hơn cạnh thứ 3
            if (ab + bc <= ca || bc + ca <= ab || ca + ab <= bc)
            {
                return false;
            }

            return true;
        }

        public bool IsValid()
        {
            return IsValidTriangle(A, B, C);
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
            if (!IsValid())
            {
                throw new InvalidOperationException("Không thể tính chu vi cho tam giác không hợp lệ!");
            }

            return Point.Distance(A, B) + Point.Distance(B, C) + Point.Distance(C, A);
        }

        public double DienTich()
        {
            if (!IsValid())
            {
                throw new InvalidOperationException("Không thể tính diện tích cho tam giác không hợp lệ!");
            }

            double ab = Point.Distance(A, B);
            double bc = Point.Distance(B, C);
            double ca = Point.Distance(C, A);
            double nuaChuVi = (ab + bc + ca) / 2;

            double dienTich = nuaChuVi * (nuaChuVi - ab) * (nuaChuVi - bc) * (nuaChuVi - ca);

            // Kiểm tra để tránh căn bậc hai của số âm (có thể xảy ra do sai số làm tròn)
            if (dienTich < 0)
            {
                return 0;
            }

            return Math.Sqrt(dienTich);
        }

        public void Angle()
        {
            if (!IsValid())
            {
                Console.WriteLine("Không thể tính góc cho tam giác không hợp lệ!");
                return;
            }

            double ab = Point.Distance(A, B);
            double bc = Point.Distance(B, C);
            double ac = Point.Distance(C, A);

            double angleA = Math.Acos(Math.Max(-1, Math.Min(1, (ab * ab + ac * ac - bc * bc) / (2 * ab * ac)))) * 180 / Math.PI;
            double angleB = Math.Acos(Math.Max(-1, Math.Min(1, (bc * bc + ab * ab - ac * ac) / (2 * bc * ab)))) * 180 / Math.PI;
            double angleC = 180 - angleA - angleB;

            Console.WriteLine($"Góc A: {angleA:F2} độ");
            Console.WriteLine($"Góc B: {angleB:F2} độ");
            Console.WriteLine($"Góc C: {angleC:F2} độ");
        }

        //// Phương thức tạo tam giác từ danh sách điểm với kiểm tra
        //public static List<Triangle> CreateTrianglesFromPoints(List<Point> points)
        //{
        //    List<Triangle> triangles = new List<Triangle>();

        //    for (int i = 0; i < points.Count - 2; i++)
        //    {
        //        for (int j = i + 1; j < points.Count - 1; j++)
        //        {
        //            for (int k = j + 1; k < points.Count; k++)
        //            {
        //                try
        //                {
        //                    Triangle triangle = new Triangle(points[i], points[j], points[k]);
        //                    triangles.Add(triangle);
        //                }
        //                catch (ArgumentException)
        //                {
        //                    // Bỏ qua các tam giác không hợp lệ
        //                    continue;
        //                }
        //            }
        //        }
        //    }

        //    return triangles;
        //}
    }
}