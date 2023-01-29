using Library.LMS.Components;

namespace LMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Course> courses = new List<Course>();
            List<Person> students = new List<Person>();

            //Person student = new Person();
            //student.Name= "Test";
            //student.Classification = "Junior";
            //Assignment assignment1 = new Assignment();
            //assignment1.DueDate = "1/2/22";
            //assignment1.Name = "TestAssign";
            //assignment1.TotalAvailablePoints = "100";
            //assignment1.Description = "Description";



            //student.AddGrade(assignment1, "100");

            //Console.WriteLine(student);
            //assignment1.Name= "NewName";

            //Console.WriteLine(student);

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
                        string CourseCode = Console.ReadLine();

                        Console.WriteLine("Enter course name: ");
                        string CourseName = Console.ReadLine();

                        Console.WriteLine("Enter description: ");
                        string Coursedescription = Console.ReadLine();

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
                        foreach (var a in courses)
                        {
                            if (a.Name == CourseName)
                            {
                                CourseofInterest = a;
                                break;
                            }
                        }
                        Console.WriteLine("Enter student name: ");
                        string StudentName = Console.ReadLine();
                        foreach (var a in students)
                        {
                            if (a.Name == StudentName)
                            {
                                students.Remove(a);
                                break;
                            }
                        }
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

                        foreach(var a in courses)
                        {
                            if(a.Name == CourseInfo)
                            {
                                CourseOfInterest = a;
                            }
                            else if(a.Description == CourseInfo)
                            {
                                CourseOfInterest = a;
                            }
                        }
                        Console.WriteLine($"{CourseOfInterest}\n{CourseOfInterest.Description}");
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
