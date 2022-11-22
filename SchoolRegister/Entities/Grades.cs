using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolRegister;

namespace SchoolRegister
{
    public class Grades
    {
        public int ID { get; set; }
        public int Trimester { get; set; }
        public int Grade { get; set; }
        public Grades()
        {

        }
        public Grades(int id, int trimester, int grade)
        {
            ID = id;
            Trimester = trimester;
            Grade = grade;
        }
    }
}