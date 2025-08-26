using System.Text;

namespace LT_B3_OOP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            List<Point> points = Triangle.Generate();

            Console.WriteLine($"Số lượng Point được tạo ra: {Point.Counter}");
            for (int i = 0; i < points.Count; i++)
            {
                Console.WriteLine($"Điểm [{i + 1}]: ({points[i].X}, {points[i].Y}, {points[i].Z})");
            }

            if (Point.Counter < 3)
            {
                Console.WriteLine("Không đủ điểm để tạo tam giác.");
                return;
            }

            

            Random random = new Random();
            Point[] threePoints = new Point[3];
            int[] index = new int[3];
            int count = 0;

            while (count < 3)
            {
                int randomIndex = random.Next(points.Count);
                bool duplicate = false;
                for (int i = 0; i < count; i++)
                {
                    if (index[i] == randomIndex)
                    {
                        duplicate = true;
                        break;
                    }
                }
                if (!duplicate)
                {
                    index[count] = randomIndex;
                    threePoints[count] = points[randomIndex];
                    count++;
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine("3 điểm được chọn ngẫu nhiên:");
            for (int i = 0; i < threePoints.Length; i++)
            {
                Console.WriteLine($"Điểm [{index[i] + 1}]: ({threePoints[i].X}, {threePoints[i].Y}, {threePoints[i].Z})");
            }
            Console.WriteLine("--------------------------------\n");

            // Tạo tam giác từ 3 điểm đã chọn nếu hợp lệ
            if (Triangle.IsValidTriangle(threePoints[0], threePoints[1], threePoints[2]))
            {
                Triangle triangle = new Triangle(threePoints[0], threePoints[1], threePoints[2]);
                Console.WriteLine("Ba điểm tạo thành một tam giác hợp lệ.");
                Console.WriteLine(triangle.IsValid());
                Console.WriteLine($"Chu vi tam giác: {triangle.ChuVi()}");
                Console.WriteLine($"Diện tích tam giác: {triangle.DienTich()}");
                triangle.Angle();
                Console.WriteLine("--------------------------------\n");

                Console.WriteLine("Độ dài các cạnh của tam giác:");
                Console.WriteLine($"Độ dài cạnh AB [{index[0] + 1}] - [{index[1] + 1}]: {Point.Distance(threePoints[0], threePoints[1])}");
                Console.WriteLine($"Độ dài cạnh BC [{index[1] + 1}] - [{index[2] + 1}]: {Point.Distance(threePoints[1], threePoints[2])}");
                Console.WriteLine($"Độ dài cạnh CA [{index[2] + 1}] - [{index[0] + 1}]: {Point.Distance(threePoints[2], threePoints[0])}");
            }
            else
            {
                Console.WriteLine("Ba điểm được chọn không tạo thành một tam giác hợp lệ.");
            }

            Console.ReadKey();
        }
    }
}
/*
Một lớp Point trong không gian 3 chiều có ba tọa độ float x, y, z. 
Câu 1: Khai báo lớp Point ở trên cùng với các method getter, setter, constructor cần thiết
Câu 2: Bổ sung một biến thành viên có tên là Counter ở mức truy cập là public và là thành viên tĩnh (static). Điều chỉnh constructor để đảm bảo rằng biến Counter cho phép đếm số lượng các Point được tạo ra
Câu 3: Thêm phương thức tính khoảng cách giữa hai Point

Một lớp tam giác Triangle được cấu tạo từ 3 Point. 
Câu 4: Khai báo lớp Triangle cùng với method getter, setter, constructor tương ứng
Câu 5: Bổ sung một phương thức khởi tạo (không phải constructor) tên là Generate để tạo ra một list các Point. 
Việc khởi tọa này được thực thi bên trong một vòng lặp (lặp khoảng 50 lần). 
Bên trong sử dụng một biến ngẫu nhiên có giá trị true false để đảm bảo rằng số lượng điểm được sinh ra không được kiểm soát. 
Các điểm được sinh ra có thể được bổ sung vào trong 1 list
Câu 6: Cho biết số lượng Point được tạo ra thông qua biến Counter (không truy cập vào method length của list)
Câu 7: Bổ sung method tính chu vi cho lớp Triangle
Câu 8: Bổ sung method tính diện tích 
Câu 9: Bổ sung method xác định độ lớn các góc của tam giác
Câu 10: Trong hàm main, chọn random 3 Point trong list của method Generate để tạo thành một tam giác bất kỳ. Sau đó gọi các phương thức đã xây dựng trong lớp Triangle (7 -> 8 -> 9). Đồng thời in ra độ dài các cạnh của tam giác (thông qua method khoảng cách của lớp Point)
 */