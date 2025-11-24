using BTVN_2B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN_2B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<Student> studentList = new List<Student>();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("========== MENU ===========");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách sinh viên");
                Console.WriteLine("3. Xuất ra thông tin sinh viên thuộc khoa 'CNTT'");
                Console.WriteLine("4. Xuất ra danh sách sinh viên có điểm trung bình trên 5.0");
                Console.WriteLine("5. Sắp xếp danh sách sinh viên theo điểm trung bình tăng dần");
                Console.WriteLine("6. Xuất ra danh sách sinh viên có điểm trung bình >= 5 và thuộc khoa 'CNTT'");
                Console.WriteLine("7. Xuất ra danh sách sinh viên có điểm trung bình cao nhất thuộc khoa 'CNTT'");
                Console.WriteLine("8. Thống kê số lượng sinh viên theo xếp loại");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn một tùy chọn (0-8): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "2":
                        Console.WriteLine("Danh sách sinh viên:");
                        foreach (var stu in studentList)
                        {
                            stu.Output();
                        }
                        break;
                    case "3":
                        DisplayStudentsByFaculty(studentList, "CNTT");
                        break;
                    case "4":
                        DisplayStudentsAboveAverage(studentList, 5);
                        break;
                    case "5":
                        SortStudentsByAverageScore(studentList);
                        break;
                    case "6":
                        DisplayStudentsByFacultyAndScore(studentList, "CNTT", 5);
                        break;
                    case "7":
                        DisplayStudentsWithHighestAverageScoreByFaculty(studentList, "CNTT");
                        break;
                    case "8":
                        CountStudentsByClassification(studentList);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
        }


        //Case 1: them sinh vien
        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("==== Nhập thông tin sinh viên ====");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("------- Thêm sinh viên thành công! -------");
            Console.WriteLine("\n");
        }
        //Case 2: xuat danh sach sinh vien
        static void DisplayStudents(List<Student> studentList)
        {
            Console.WriteLine("-------- Danh sách chi tiết thông tin sinh viên -------");
            foreach (Student student in studentList)
            {
                student.Output();
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine("\n");
        }

        // Case 3: xuat danh sach sinh vien theo khoa
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("==== Danh sách sinh viên khoa {0}", faculty);
            var students = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));
            DisplayStudents(studentList);
            Console.WriteLine("\n");
        }

        //Case 4: xuat danh sach sinh vien co diem trung binh tren 5.0
        static void DisplayStudentsAboveAverage(List<Student> studentList, float minDTB)
        {
            Console.WriteLine("==== Danh sách sinh viên có điểm trung bình trên {0} ====", minDTB);
            var students = studentList.Where(s => s.AverageScore > minDTB);
            DisplayStudents(studentList);
            Console.WriteLine("\n");
        }

        //Case 5: sap xep danh sach sinh vien theo diem trung binh tang dan
        static void SortStudentsByAverageScore(List<Student> studentList)
        {
            Console.WriteLine("==== Danh sách sinh viên sắp xếp theo điểm trung bình tăng dần ====");
            var sortedStudents = studentList.OrderBy(s => s.AverageScore).ToList();
            DisplayStudents(sortedStudents);
            Console.WriteLine("\n");
        }

        //Case 6: ds sinh vien co DiemTB >= 5 va thuoc khoa CNTT
        static void DisplayStudentsByFacultyAndScore(List<Student> studentList, string faculty, float minDTB)
        {
            Console.WriteLine("==== Danh sách sinh viên có điểm TB >= {0} và thuộc khoa {1}", minDTB, faculty);
            var students = studentList.Where(s => s.AverageScore >= minDTB && s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudents(students);
            Console.WriteLine("\n");
        }

        //Case 7: xuat ds sinh vien co DTB cao nhat va thuoc khoa CNTT
        static void DisplayStudentsWithHighestAverageScoreByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("==== Danh sách sinh viên có điểm TB cao nhất thuộc khoa {0} ====", faculty);
            var maxDTB = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).Max(s => s.AverageScore);
            var topStudents = studentList.Where(s => s.AverageScore == maxDTB && s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudents(topStudents);
            Console.WriteLine("\n");
        }

        //Case 8: cho biet so luong cua tung xep loai trong danh sach. Biet rang xep loai chia theo thang diem 10
        //Xuat sac (DTB >= 9.0), Gioi (8 <= DTB < 9.0),Kha (7.0 <= DTB < 8.0), Trung Binh (5.0 <= DTB < 7), Yeu (4 <= DTB < 5.0), Kem (DTB < 4.0)
        static void CountStudentsByClassification(List<Student> studentList)
        {
            int xs = studentList.Count(s => s.AverageScore >= 9.0f);
            int g = studentList.Count(s => s.AverageScore >= 8.0f && s.AverageScore < 9.0f);
            int k = studentList.Count(s => s.AverageScore >= 7.0f && s.AverageScore < 8.0f);
            int tb = studentList.Count(s => s.AverageScore >= 5.0f && s.AverageScore < 7.0f);
            int y = studentList.Count(s => s.AverageScore >= 4.0f && s.AverageScore < 5.0f);
            int kem = studentList.Count(s => s.AverageScore < 4.0f);
            Console.WriteLine("==== Số lượng sinh viên theo xếp loại ====");
            Console.WriteLine("Xuất sắc: {0}", xs);
            Console.WriteLine("Giỏi: {0}", g);
            Console.WriteLine("Khá: {0}", k);
            Console.WriteLine("Trung bình: {0}", tb);
            Console.WriteLine("Yếu: {0}", y);
            Console.WriteLine("Kém: {0}", kem);
            Console.WriteLine("---------------------------");
            Console.WriteLine("\n");
        }
    }
}
