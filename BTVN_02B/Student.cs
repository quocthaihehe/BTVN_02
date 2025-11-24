using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN_2B
{
    class Student
    {
        private string studentID;
        private string fullName;
        private float averageScore;
        private string faculty;

        public string StudentID { get => studentID; set => studentID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public float AverageScore { get => averageScore; set => averageScore = value; }
        public string Faculty { get => faculty; set => faculty = value; }

        public Student()
        {

        }
        public Student(string studentID, string fullName, float averageScore, string faculty)
        {
            this.studentID = studentID;
            this.fullName = fullName;
            this.averageScore = averageScore;
            this.faculty = faculty;
        }

        public void Input()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập mã số sinh viên: ");
            studentID = Console.ReadLine();
            Console.Write("Nhập họ tên sinh viên: ");
            fullName = Console.ReadLine();
            Console.Write("Nhập điểm trung bình: ");
            averageScore = float.Parse(Console.ReadLine());
            Console.Write("Nhập khoa của sinh viên: ");
            faculty = Console.ReadLine();
        }
        public void Output()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("MSSV:{0} Họ Tên:{1} Khoa:{2} Điểm TB:{3}", this.StudentID, this.fullName, this.faculty, this.averageScore);

        }
    }
}
