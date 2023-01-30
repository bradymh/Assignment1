using Library.LMS.Models;

namespace LMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Course> courses = new List<Course>();
            List<Person> students = new List<Person>();

            while (true)
            {
                Console.WriteLine("1. Add a course");
                Console.WriteLine("2. Add a student");
                Console.WriteLine("3. Add a student to course");
                Console.WriteLine("4. Remove a student from a course's roster");
                Console.WriteLine("5. List all courses");
                Console.WriteLine("6. Search for courses by name or description");
                Console.WriteLine("7. List all students");
                Console.WriteLine("8. Search for a student by name");
                Console.WriteLine("9. List all courses a student is taking");
                Console.WriteLine("10. Update a course's information");
                Console.WriteLine("11. Update a student's information");
                Console.WriteLine("12. Create an assignment and add it to a course");
                Console.WriteLine("13. Exit");
                Console.WriteLine("Enter an option: ");

                string choice = Console.ReadLine() ?? string.Empty;
                              

                if (int.TryParse(choice, out int choiceInt))
                {   
                    if(choiceInt == 1)
                    {
                        Console.WriteLine("Enter course code: ");
                        string CourseCode = Console.ReadLine() ?? string.Empty;

                        Console.WriteLine("Enter course name: ");
                        string CourseName = Console.ReadLine() ?? string.Empty;

                        Console.WriteLine("Enter description: ");
                        string Coursedescription = Console.ReadLine() ?? string.Empty;

                        if(CourseCode == string.Empty || CourseName == string.Empty || Coursedescription == string.Empty)
                        {
                            Console.WriteLine("Invalid entry");
                        }
                        courses.Add(new Course(CourseCode,CourseName,Coursedescription));
                    }
                    if (choiceInt == 2)
                    {
                        Console.WriteLine("Enter student name: ");
                        string StudentName = Console.ReadLine();

                        Console.WriteLine("Enter student classification: ");
                        string Studentdescription = Console.ReadLine();

                        students.Add(new Person(StudentName, Studentdescription));
                    }
                    if (choiceInt == 3) 
                    {
                        Person AddedStudent = new Person();
                        Console.WriteLine("Enter student name: ");
                        string PersonName = Console.ReadLine();
                        foreach(var a in students)
                        {
                            if(a.Name == PersonName)
                            {
                                AddedStudent= a;
                                break;
                            }
                        }

                        Console.WriteLine("Enter course to add student to: ");
                        string CourseName = Console.ReadLine();
                        foreach (var a in courses)
                        {
                            if (a.Name == CourseName)
                            {
                                a.AddStudent(AddedStudent);
                                break;
                            }
                        }                        
                    }
                    if (choiceInt == 4)
                    {
                        Course CourseofInterest;
                        Console.WriteLine("Enter course name: ");
                        string CourseName = Console.ReadLine();
                        bool FoundCourse = false;
                        foreach (var a in courses)
                        {
                            if (a.Name == CourseName)
                            {
                                CourseofInterest = a;
                                FoundCourse = true;
                                break;
                            }
                        }
                        if (FoundCourse)
                        {
                            Console.WriteLine("Enter student name: ");
                            string RemovedStudent = Console.ReadLine();
                            bool FoundStudent = false;
                            foreach (var a in students)
                            {
                                if (a.Name == RemovedStudent)
                                {
                                    students.Remove(a);
                                    FoundStudent = true;
                                    Console.WriteLine("Student removed");
                                    break;
                                }
                            }
                            if (!FoundStudent) Console.WriteLine("Student not found");
                        }
                        else Console.WriteLine("Course not found");
                    }
                    if (choiceInt == 5)
                    {
                        foreach (var a in courses)
                        {
                            Console.WriteLine(a);
                        }
                    }
                    if (choiceInt == 6)
                    {
                        Course CourseOfInterest = new Course();
                        Console.WriteLine("Enter Course name or description: ");
                        string CourseInfo = Console.ReadLine();
                        bool found = false;
                        foreach(var a in courses)
                        {
                            if(a.Name == CourseInfo)
                            {
                                CourseOfInterest = a;
                                found = true;
                            }
                            else if(a.Description == CourseInfo)
                            {
                                CourseOfInterest = a;
                                found = true;
                            }
                        }
                        if (found)
                        {
                            Console.WriteLine($"{CourseOfInterest}\n{CourseOfInterest.Description}");
                        }
                        else Console.WriteLine("Course not found");
                    }
                    if (choiceInt == 7)
                    {
                        foreach (var a in students) 
                        { 
                            Console.WriteLine(a); 
                        }
                    }
                    if (choiceInt == 8)
                    {
                        Console.WriteLine("Enter student name: ");
                        string StudentName = Console.ReadLine();
                        bool found = false;
                        foreach (var a in students)
                        {
                            if (a.Name == StudentName)
                            {
                                Console.WriteLine(a);
                                found = true;
                            }
                            else found = false;
                        }
                        if (!found)
                        {
                            Console.WriteLine("Student not found");
                        }
                    }
                    if (choiceInt == 9)
                    {

                    }
                    if (choiceInt == 10)
                    {

                    }
                    if (choiceInt == 11)
                    {

                    }
                    if (choiceInt == 12)
                    {

                    }
                    if (choiceInt == 13)
                    {
                        break;
                    }

                }
            }
        }
    }
}
