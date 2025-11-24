using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN_2
{
    class Student
    {
        private int id;
        private string name;
        private int age;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }


        public Student(int Id, string name, int age)
        {
            this.Id = Id;
            this.name = name;
            this.age = age;
        }

        public void xuat()
        {
            Console.WriteLine("MSSV: {0}, Họ Tên: {1}, Tuổi: {2}", this.id, this.name, this.age);
        }
    }
}
