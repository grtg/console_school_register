using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister
{
    public class GradesRepository
    {
        public List<Grades> grades = new List<Grades>();
        public GradesRepository()
        {
            grades.Add(new Grades(1, 1, 7));
            grades.Add(new Grades(1, 2, 8));
            grades.Add(new Grades(1, 3, 7));
            grades.Add(new Grades(1, 4, 7));
            grades.Add(new Grades(2, 1, 9));
            grades.Add(new Grades(2, 2, 8));
            grades.Add(new Grades(2, 3, 9));
            grades.Add(new Grades(2, 4, 9));
            grades.Add(new Grades(3, 1, 9));
            grades.Add(new Grades(3, 2, 10));
            grades.Add(new Grades(3, 3, 10));
            grades.Add(new Grades(3, 4, 10));
            grades.Add(new Grades(4, 1, 10));
            grades.Add(new Grades(4, 2, 8));
            grades.Add(new Grades(4, 3, 10));
            grades.Add(new Grades(4, 4, 9));
            grades.Add(new Grades(5, 1, 7));
            grades.Add(new Grades(5, 2, 7));
            grades.Add(new Grades(5, 3, 7));
            grades.Add(new Grades(5, 4, 7));
            grades.Add(new Grades(6, 1, 8));
            grades.Add(new Grades(6, 2, 7));
            grades.Add(new Grades(6, 3, 8));
            grades.Add(new Grades(6, 4, 8));
            grades.Add(new Grades(7, 1, 10));
            grades.Add(new Grades(7, 2, 8));
            grades.Add(new Grades(7, 3, 9));
            grades.Add(new Grades(8, 1, 5));
            grades.Add(new Grades(8, 2, 5));
            grades.Add(new Grades(8, 3, 4));
            grades.Add(new Grades(9, 1, 10));
            grades.Add(new Grades(9, 2, 10));
            grades.Add(new Grades(9, 3, 10));
            grades.Add(new Grades(9, 4, 10));
            grades.Add(new Grades(10, 1, 8));
            grades.Add(new Grades(10, 2, 7));
            grades.Add(new Grades(10, 3, 8));
            grades.Add(new Grades(10, 4, 8));
            grades.Add(new Grades(11, 1, 6));
            grades.Add(new Grades(11, 2, 5));
            grades.Add(new Grades(11, 3, 6));
            grades.Add(new Grades(12, 1, 2));
            grades.Add(new Grades(12, 2, 3));
            grades.Add(new Grades(12, 3, 2));
            
        }
        public Grades RetrieveGrade(int id, int trimester)
        {
            var grade = grades.FirstOrDefault(x => x.ID == id && x.Trimester == trimester);
            return grade;
        }

        public List<Grades> RetrieveAllGradesForTerm(int trimester)
        {
            var TrimesterGrades = Retrieve();
            TrimesterGrades = TrimesterGrades.Where(grade => grade.Trimester.Equals(trimester)).ToList();
            return TrimesterGrades;
        }
        public List<Grades> RetrieveAllGradesForStudent(int id)
        {
            var StudentGrades = Retrieve();
            StudentGrades = StudentGrades.Where(grade => grade.ID.Equals(id)).ToList();
            return StudentGrades;
        }
        public List<Grades> Retrieve()
        {
            return grades;
        }
        public List<Grades> AddGrade(int id, int trimester, int grade)
        {
            grades.Add(new Grades(id, trimester, grade));
            return grades;
        }

        public void RemoveGrade(int id, int trimester)
        {
            var grades = Retrieve();
            var RemoveGrade = grades.SingleOrDefault(x => x.ID == id && x.Trimester == trimester);
            if (RemoveGrade != null)
            {
                grades.Remove(RemoveGrade);
            }
            else
            {
                Console.WriteLine($"Grade with ID {RemoveGrade.ID} does not exist.");
            }
        }

        public Grades EditGrade(int id, int trimester, int grade)
        {
            var grades = Retrieve();
            var EditGrade = grades.SingleOrDefault(x => x.ID == id && x.Trimester == trimester);
            if (EditGrade == null)
            {
                Console.WriteLine($"Grade with ID {EditGrade.ID} does not exist");
                return null;
            }

            EditGrade.Grade = grade;
            return EditGrade;
        }
    }
}