using SchoolRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Repositories
{
    public class StudentsRepository
    {
        public List<Students> students = new List<Students>();

        public StudentsRepository()
        {
            students.Add(new Students(1, "Sam"));
            students.Add(new Students(2, "Alex"));
            students.Add(new Students(3, "Chris"));
            students.Add(new Students(4, "Amber"));
            students.Add(new Students(5, "Lucas"));
            students.Add(new Students(6, "Robert"));
            students.Add(new Students(7, "Amelie"));
            students.Add(new Students(8, "Ben"));
            students.Add(new Students(9, "Ellen"));
            students.Add(new Students(10, "Simon"));
            students.Add(new Students(11, "Lea"));
            students.Add(new Students(12, "Patrick"));
        }
        public Students Retrieve(string name)
        {
            var student = students.FirstOrDefault(x => x.Name == name);
            return student;
        }

        public List<Students> AddNewStudent(string name)
        {
            int id = students.Count + 1;
            students.Add(new Students(id, name));
            return students;
        }

        public List<Students> Retrieve()
        {
            return students;
        }

        public void RemoveStudent(string name)
        {
            var students = Retrieve();
            var DeleteStudent = students.SingleOrDefault(x => x.Name == name);
            if (DeleteStudent != null)
            {
                students.Remove(DeleteStudent);
            }
            else
            {
                Console.WriteLine($"Student {DeleteStudent.Name} does not exist.");
            }
        }

        public Students EditStudent(int id, string name)
        {
            var students = Retrieve();
            var EditStudent = students.SingleOrDefault(x => x.ID == id);
            if (EditStudent == null)
            {
                Console.WriteLine($"Student with ID {EditStudent.ID} does not exist");
                return null;
            }

            EditStudent.Name = name;
            return EditStudent;
        }
    }
}