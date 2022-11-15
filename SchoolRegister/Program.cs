using System;
using System.Diagnostics.Metrics;
using SchoolRegister;
using SchoolRegister.Repositories;


namespace SchoolRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var StudentsRepository = new StudentsRepository();
            var GradesRepository = new GradesRepository();

            while (true)
            {
                try
                {
                    Console.WriteLine("Welcome to School Register! Please select an action from the following menu:");
                    Console.WriteLine("1 - see grades, 2 - edit grades, 3 - see the list of students, 4 - edit the list of students");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            SeeGradesMenu(GradesRepository);
                            break;
                        case 2:
                            EditGradesMenu(GradesRepository);
                            break;
                        case 3:
                            SeeStudentList(StudentsRepository);
                            break;
                        case 4:
                            EditStudentList(StudentsRepository);
                            break;
                        default:
                            Console.WriteLine("Unavailable option.");
                            break;
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error occured: {e.Message}");
                }
            }
        }

        public static void EditStudentList(StudentsRepository StudentsRepository)
        {
            Console.WriteLine("Please select an action from the following list:");
            Console.WriteLine("1 - add a student, 2 - remove a student, 3 - edit a student's name");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    AddStudent(StudentsRepository);
                    break;
                case 2:
                    RemoveStudent(StudentsRepository);
                    break;
                case 3:
                    EditStudentName(StudentsRepository);
                    break;
                default:
                    Console.WriteLine("Unavailable option.");
                    break;
            }
        }

        public static List<Students> AddStudent(StudentsRepository StudentsRepository)
        {
            Console.WriteLine("Enter a student's name:");
            string name = Console.ReadLine();
            StudentsRepository.AddNewStudent(name);
            var students = StudentsRepository.Retrieve();
            return students;
        }

        public static List<Students> RemoveStudent(StudentsRepository StudentsRepository)
        {
            Console.WriteLine("Enter a student's name:");
            string name = Console.ReadLine();
            StudentsRepository.RemoveStudent(name);
            var students = StudentsRepository.Retrieve();
            return students;
        }

        public static List<Students> EditStudentName(StudentsRepository StudentsRepository)
        {
            Console.WriteLine("Enter a student's ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a student's name:");
            string name = Console.ReadLine();
            StudentsRepository.EditStudent(id, name);
            var students = StudentsRepository.Retrieve();
            return students;
        }

        public static void SeeStudentList(StudentsRepository StudentsRepository)
        {
            var AllStudents = StudentsRepository.Retrieve();
            foreach (var student in AllStudents)
            {
                Console.WriteLine($"Student's ID - {student.ID}, student's name - {student.Name}");
            }
        }

        public static void SeeGradesMenu(GradesRepository GradesRepository)
        {
            Console.WriteLine("Please select an action from the following list:");
            Console.WriteLine("1 - see all trimester grades, 2 - see a student's grades of all trimesters, 3 - see a student's grades of one trimester");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    AllStudentsTrimester(GradesRepository);
                    break;
                case 2:
                    OneStudentGrades(GradesRepository);
                    break;
                case 3:
                    OneGrade(GradesRepository);
                    break;
                default:
                    Console.WriteLine("Unavailable option");
                    break;
            }
        }

        public static void EditGradesMenu(GradesRepository GradesRepository)
        {
            Console.WriteLine("Please select an action from the following menu:");
            Console.WriteLine("1 - edit a grade, 2 - add a grade, 3 - remove a grade");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    EditGrade(GradesRepository);
                    break;
                case 2:
                    AddGrade(GradesRepository);
                    break;
                case 3:
                    RemoveGrade(GradesRepository);
                    break;
                default:
                    Console.WriteLine("Unavailable option");
                    break;
            }
        }

        public static List<Grades> EditGrade(GradesRepository GradesRepository)
        {
            Console.WriteLine("Enter a student's ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a trimester number (1-3) (4 - annual grade):");
            int trimester = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Edit a grade:");
            int grade = Convert.ToInt32(Console.ReadLine());
            GradesRepository.EditGrade(id, trimester, grade);
            var grades = GradesRepository.Retrieve();
            return grades;
        }

        public static List<Grades> AddGrade(GradesRepository GradesRepository)
        {
            Console.WriteLine("Enter a student's ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a trimester number (1 - 3) (4 - annual grade):");
            int trimester = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a new grade:");
            int grade = Convert.ToInt32(Console.ReadLine());
            GradesRepository.AddGrade(id, trimester, grade);
            var grades = GradesRepository.Retrieve();
            return grades;
        }

        public static List<Grades> RemoveGrade(GradesRepository GradesRepository)
        {
            Console.WriteLine("Enter a student's ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a trimester number (1 - 3) (4 - annual grade):");
            int trimester = Convert.ToInt32(Console.ReadLine());
            GradesRepository.RemoveGrade(id, trimester);
            var grades = GradesRepository.Retrieve();
            return grades;
        }

        public static void AllStudentsTrimester(GradesRepository GradesRepository)
        {
            Console.WriteLine("Please select a trimester:");
            Console.WriteLine("1 - trimester 1, 2 - trimester 2, 3 - trimester 3, 4 - annual grade");
            int trimester = Convert.ToInt32(Console.ReadLine());
            var GradesByTrimester = GradesRepository.RetrieveAllGradesForTerm(trimester);

            foreach (var grade in GradesByTrimester)
            {
                Console.WriteLine($"Student's ID - {grade.ID}; trimester grade - {grade.Grade}");
            }
        }

        public static void OneStudentGrades(GradesRepository GradesRepository)
        {
            Console.WriteLine("Enter a student's ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            var GradesForStudent = GradesRepository.RetrieveAllGradesForStudent(id);

            foreach (var grade in GradesForStudent)
            {
                if (grade.Trimester != 4)
                {
                    Console.WriteLine($"Trimester number - {grade.Trimester}; grade - {grade.Grade}");
                }
                else
                {
                    Console.WriteLine($"Annual grade - {grade.Grade}");
                }
            }
        }

        public static void OneGrade(GradesRepository GradesRepository)
        {
            Console.WriteLine("Enter a student's ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a trimester number (1 - 3) (4 - annual grade):");
            int trimester = Convert.ToInt32(Console.ReadLine());
            var grade = GradesRepository.RetrieveGrade(id, trimester);
            if (grade.Trimester != 4)
            {
                Console.WriteLine($"Student's grade is {grade.Grade} for trimester {grade.Trimester}.");
            }
            else
            {
                Console.WriteLine($"Student's annual grade is {grade.Grade}.");
            }
        }
    }

}
