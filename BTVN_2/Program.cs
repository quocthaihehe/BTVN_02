using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<Student> students = new List<Student>();
            // thông tin của 5 học sinh
            students.Add(new Student(1, "An",    16));
            students.Add(new Student(2, "Bình",  19));
            students.Add(new Student(3, "Cường", 15));
            students.Add(new Student(4, "Đức",   18));
            students.Add(new Student(5, "Anh",   17));

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("======= Menu ======");
                Console.WriteLine("1. In danh sách học sinh");
                Console.WriteLine("2. Tìm và in ra danh sách học sinh 15 - 18 tuổi");
                Console.WriteLine("3. Tìm và in ra học sinh có tên bắt đầu bằng chữ 'A'");
                Console.WriteLine("4. Tính tổng tuổi các học sinh trong danh sách");
                Console.WriteLine("5. Tìm và in ra học sinh có tuổi lớn nhất");
                Console.WriteLine("6. Sắp xếp danh sách học sinh theo tuổi tăng dần và in ra danh sách sau khi sắp xếp");
                Console.WriteLine("0. Thoát");
                Console.Write("Nhập lựa chọn của bạn: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        InDanhSachHs(students);
                        break;
                    case "2":
                        TimHs15Den18Tuoi(students);
                        break;
                    case "3":
                        TimHsTenBatDauBangA(students);
                        break;
                    case "4":
                        TinhTongTuoiHs(students);
                        break;
                    case "5":
                        TimHsCoTuoiLonNhat(students);
                        break;
                    case "6":
                        SapXepHsTheoTuoiTangDan(students);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
            Console.ReadKey();
        }
        static void InDanhSachHs(List<Student> students)
        {
            Console.WriteLine("==== Danh sách toàn bộ học sinh ====");
            foreach (var student in students)
            {
                student.xuat();
            }
        }

        static void TimHs15Den18Tuoi(List<Student> students)
        {
            Console.WriteLine("==== Danh sách học sinh 15 - 18 tuổi ====");
            var timhs = students.Where(s => s.Age >= 15 && s.Age <= 18).ToList();
            InDanhSachHs(timhs);
        }

        static void TimHsTenBatDauBangA(List<Student> students)
        {
            Console.WriteLine("==== Danh sách học sinh có tên bắt đầu bằng chữ 'A' ====");
            var timhs = students.Where(s => s.Name.StartsWith("A")).ToList();
            InDanhSachHs(timhs);
        }

        static void TinhTongTuoiHs(List<Student> students)
        {
            Console.WriteLine("==== Tính tổng tuổi các học sinh trong danh sách ====");
            int tongTuoi = students.Sum(s => s.Age);
            Console.WriteLine("==== Tổng tuổi các học sinh trong danh sách: {0}", tongTuoi);
        }

        static void TimHsCoTuoiLonNhat(List<Student> students)
        {
            Console.WriteLine("==== Tìm và in ra học sinh có tuổi lớn nhất ====");
            int maxTuoi = students.Max(s => s.Age);
            var timhs = students.Where(s => s.Age == maxTuoi).ToList();
            InDanhSachHs(timhs);
        }

        static void SapXepHsTheoTuoiTangDan(List<Student> students)
        {
            Console.WriteLine("==== Sắp xếp danh sách học sinh theo tuổi tăng dần ====");
            var sapxepHs = students.OrderBy(s => s.Age).ToList();
            InDanhSachHs(sapxepHs);
        }
    }
}