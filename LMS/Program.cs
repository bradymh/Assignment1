using Library.LMS.Models;
using Library.LMS.Services;
using Assignment2_Solution;
using System.Linq.Expressions;

namespace LMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Course> courses = new List<Course>();
            CourseService courseService = new CourseService();
            
            List<Person> students = new List<Person>();

            while (true)
            {
                Console.WriteLine("1. Courses");
                Console.WriteLine("2. Students");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter an option: ");

                string choice = Console.ReadLine() ?? string.Empty;
                              

                if (int.TryParse(choice, out int choiceInt))
                {   
                    if(choiceInt == 1)
                    {
                        while (true)
                        {
                            Console.WriteLine("1. Add course");
                            Console.WriteLine("2. Add student to course");
                            Console.WriteLine("3. Remove student from course");
                            Console.WriteLine("4. List all courses");
                            Console.WriteLine("5. Search for course");
                            Console.WriteLine("6. Update a course");
                            Console.WriteLine("7. Create an assignment");
                            Console.WriteLine("8. Change a courses modules");
                            Console.WriteLine("9. Exit");
                            Console.WriteLine("Enter an option: ");

                            string CourseChoice = Console.ReadLine() ?? string.Empty;

                            if(int.TryParse(CourseChoice, out int courseInt))
                            {
                                if(courseInt == 1)
                                {
                                    Console.WriteLine("Enter course prefix: ");
                                    string CoursePrefix = Console.ReadLine() ?? string.Empty;

                                    Console.WriteLine("Enter course name: ");
                                    string CourseName = Console.ReadLine() ?? string.Empty;

                                    Console.WriteLine("Enter description: ");
                                    string Coursedescription = Console.ReadLine() ?? string.Empty;

                                    courseService.AddCourse(new Course(CoursePrefix, CourseName, Coursedescription));
                                }
                                else if(courseInt == 2)
                                {
                                    Person AddedStudent = new Person();
                                    Console.WriteLine("Enter student name: ");
                                    string PersonName = Console.ReadLine() ?? string.Empty;
                                    foreach (var a in students)
                                    {
                                        if (a.Name == PersonName)
                                        {
                                            AddedStudent = a;
                                            break;
                                        }
                                    }

                                    Console.WriteLine("Enter course to add student to: ");
                                    
                                    string CourseName = Console.ReadLine() ?? string.Empty;
                                    Course importantCourse= new Course();
                                    importantCourse = courseService.findCourse(CourseName);
                                    courseService.AddStudent(AddedStudent, importantCourse);

                                }
                                else if(courseInt == 3)
                                {
                                    Course CourseofInterest;
                                    Console.WriteLine("Enter course name: ");

                                    string CourseName = Console.ReadLine() ?? string.Empty;
                                    CourseofInterest = courseService.findCourse(CourseName);
                                    if (CourseofInterest != null)
                                    {
                                        Console.WriteLine("Enter student name: ");
                                        string RemovedStudent = Console.ReadLine() ?? string.Empty;
                                        bool FoundStudent = false;
                                        foreach (var a in students)
                                        {
                                            if (a.Name == RemovedStudent)
                                            {
                                                courseService.removeStudent(a,CourseofInterest);
                                                FoundStudent = true;
                                                Console.WriteLine("Student removed");
                                                break;
                                            }
                                        }
                                        if (!FoundStudent) Console.WriteLine("Student not found");
                                    }
                                    else Console.WriteLine("Course not found");
                                }
                                else if(courseInt == 4)
                                {      
                                    ListNavigator<Course> list = new ListNavigator<Course>(courseService.getCourseList());
                                    var window = list.GetCurrentPage();
                                    foreach(var a in window)
                                    {
                                        Console.WriteLine(a.Value);
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("1. Start");
                                        Console.WriteLine("2. Previous Page");
                                        Console.WriteLine("3. Next Page");
                                        Console.WriteLine("4. Last Page");
                                        Console.WriteLine("5. Exit");
                                        Console.WriteLine("Enter an option: ");

                                        string ListChoice = Console.ReadLine() ?? string.Empty;

                                        if (int.TryParse(ListChoice, out int navigation))
                                        {
                                            if(navigation == 1)
                                            {
                                                window = list.GoToFirstPage();
                                                foreach (var a in window)
                                                {
                                                    Console.WriteLine(a.Value);
                                                }
                                            }
                                            else if(navigation == 2)
                                            {
                                                try
                                                {
                                                    window = list.GoBackward();
                                                    foreach (var a in window)
                                                    {
                                                        Console.WriteLine(a.Value);
                                                    }
                                                }
                                                catch(PageFaultException e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                    window = list.GetCurrentPage();
                                                    foreach (var a in window)
                                                    {
                                                        Console.WriteLine(a.Value);
                                                    }
                                                }
                                            }
                                            else if(navigation == 3)
                                            {
                                                try
                                                {
                                                    window = list.GoForward();
                                                    foreach (var a in window)
                                                    {
                                                        Console.WriteLine(a.Value);
                                                    }
                                                }
                                                catch(PageFaultException e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                    window = list.GetCurrentPage();
                                                    foreach (var a in window)
                                                    {
                                                        Console.WriteLine(a.Value);
                                                    }
                                                }
                                            }
                                            else if(navigation == 4)
                                            {
                                                window = list.GoToLastPage();
                                                foreach (var a in window)
                                                {
                                                    Console.WriteLine(a.Value);
                                                }
                                            }
                                            else if(navigation == 5)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if(courseInt == 5)
                                {
                                    Course CourseOfInterest = new Course();
                                    Console.WriteLine("Enter Course name or description: ");
                                    string CourseInfo = Console.ReadLine() ?? string.Empty;


                                    CourseOfInterest = courseService.findCourse(CourseInfo);
                                    Console.WriteLine($"{CourseOfInterest}\n {CourseOfInterest.Description}");

                                }
                                else if(courseInt == 6)
                                {
                                    Course ChangedCourse = new Course();
                                    Console.WriteLine("Enter Course name or description: ");
                                    string CourseInfo = Console.ReadLine() ?? string.Empty;

                                    ChangedCourse = courseService.findCourse(CourseInfo);

                                    Console.WriteLine("Enter new course prefix (Leave blank if no change): ");
                                    string newCode = Console.ReadLine() ?? string.Empty;
                                    if (newCode != string.Empty)
                                        ChangedCourse.CoursePrefix = newCode;

                                    Console.WriteLine("Enter new course name (Leave blank if no change): ");
                                    string newName = Console.ReadLine() ?? string.Empty;
                                    if (newName != string.Empty)
                                        ChangedCourse.Name = newName;

                                    Console.WriteLine("Enter new description (Leave blank if no change): ");
                                    string newDescription = Console.ReadLine() ?? string.Empty;
                                    if (newDescription != string.Empty)
                                        ChangedCourse.Description = newDescription;
                                }
                                else if(courseInt == 7)
                                {
                                    Console.WriteLine("Enter assignment name: ");
                                    string assignmentName = Console.ReadLine() ?? string.Empty;
                                    Console.WriteLine("Enter description: ");
                                    string assingmentDescription = Console.ReadLine() ?? string.Empty;
                                    Console.WriteLine("Enter total available points: ");
                                    string assignmentPoints = Console.ReadLine() ?? string.Empty;
                                    Console.WriteLine("Enter the due date: ");
                                    string assingmentDue = Console.ReadLine() ?? string.Empty;

                                    Assignment newAssignment = new Assignment(assignmentName, assingmentDescription, assignmentPoints, assingmentDue);


                                    Console.WriteLine("Enter course to add to: ");
                                    string courseName = Console.ReadLine() ?? string.Empty;
                                    Course CourseOfInterest = courseService.findCourse(courseName);

                                    courseService.AddAssignment(CourseOfInterest,newAssignment);

                                }
                                else if(courseInt == 8)
                                {
                                    Console.WriteLine("Enter course name: ");
                                    string courseName = Console.ReadLine() ?? string.Empty;
                                    Course CourseOfInterest = courseService.findCourse(courseName);
                                    while (true)
                                    {
                                        Console.WriteLine("1. Create module");
                                        Console.WriteLine("2. View modules");
                                        Console.WriteLine("3. Update modules");
                                        Console.WriteLine("4. Delete modules");
                                        Console.WriteLine("5. Add content to modules");
                                        Console.WriteLine("6. Exit");

                                        string Modulechoice = Console.ReadLine() ?? string.Empty;


                                        if (int.TryParse(Modulechoice, out int ModuleInt))
                                        {
                                            if (ModuleInt == 1)
                                            {
                                                Console.WriteLine("Enter name: ");
                                                string modulename = Console.ReadLine() ?? string.Empty;

                                                Console.WriteLine("Enter description: ");
                                                string moduledescription = Console.ReadLine() ?? string.Empty;

                                                courseService.AddModule(new Module(modulename, moduledescription), CourseOfInterest);
                                            }
                                            else if (ModuleInt == 2)
                                            {
                                                foreach (var m in CourseOfInterest.Modules)
                                                {
                                                    Console.WriteLine(m);
                                                }
                                            }
                                            else if (ModuleInt == 3)
                                            {
                                                int count = 1;
                                                foreach (var m in CourseOfInterest.Modules)
                                                {
                                                    Console.WriteLine($"{count}. {m}");
                                                    count++;
                                                }
                                                Console.WriteLine("Module to change: ");
                                                string changeModule = Console.ReadLine() ?? string.Empty;

                                                if (int.TryParse(changeModule, out int moduleindex))
                                                {
                                                    Module ChangingModule = CourseOfInterest.Modules.ElementAt(moduleindex - 1);

                                                    Console.WriteLine("Enter new name (Leave blank if no change): ");
                                                    string newName = Console.ReadLine() ?? string.Empty;
                                                    if (newName != string.Empty)
                                                        ChangingModule.Name = newName;

                                                    Console.WriteLine("Enter new description (Leave blank if no change): ");
                                                    string newDescription = Console.ReadLine() ?? string.Empty;
                                                    if (newDescription != string.Empty)
                                                        ChangingModule.Description = newDescription;

                                                    //change content
                                                }

                                            }
                                            else if (ModuleInt == 4)
                                            {
                                                int count = 1;
                                                foreach (var m in CourseOfInterest.Modules)
                                                {
                                                    Console.WriteLine($"{count}. {m}");
                                                    count++;
                                                }
                                                Console.WriteLine("Module to delete: ");
                                                string changeModule = Console.ReadLine() ?? string.Empty;

                                                if (int.TryParse(changeModule, out int moduleindex))
                                                {
                                                    CourseOfInterest.Modules.RemoveAt(moduleindex - 1);
                                                }
                                            }
                                            else if (ModuleInt == 5)
                                            {
                                                int count = 1;
                                                foreach (var m in CourseOfInterest.Modules)
                                                {
                                                    Console.WriteLine($"{count}. {m}");
                                                    count++;
                                                }
                                                Console.WriteLine("Module to add content to: ");
                                                string modulecontent = Console.ReadLine() ?? string.Empty;

                                                if (int.TryParse(modulecontent, out int moduleindex))
                                                {
                                                    Module ModuleOfInterest = CourseOfInterest.Modules.ElementAt(moduleindex-1);

                                                    Console.WriteLine("Content name: ");
                                                    string ContentName = Console.ReadLine() ?? string.Empty;

                                                    Console.WriteLine("Content description: ");
                                                    string ContentDescription = Console.ReadLine() ?? string.Empty;

                                                    Console.WriteLine("1. File");
                                                    Console.WriteLine("2. Page");
                                                    Console.WriteLine("3. Assignment");

                                                    string contentchoice = Console.ReadLine() ?? string.Empty;

                                                    if(int.TryParse(contentchoice, out int choiceindex))
                                                    {
                                                        if (choiceindex == 1)
                                                        {
                                                            Console.WriteLine("File path: ");
                                                            string FilePath = Console.ReadLine() ?? string.Empty;

                                                            FileItem NewFile = new FileItem(ContentName,ContentDescription,FilePath);
                                                            ModuleOfInterest.AddContent(NewFile);
                                                        }
                                                        else if(choiceindex == 2)
                                                        {
                                                            Console.WriteLine("HTML body: ");
                                                            string HTMLBody = Console.ReadLine() ?? string.Empty;

                                                            PageItem NewPage = new PageItem(ContentName,ContentDescription,HTMLBody);
                                                            ModuleOfInterest.AddContent(NewPage);
                                                        }
                                                        else if(choiceindex == 3)
                                                        {
                                                            int AssignmentCount = 1;
                                                            foreach(var a in CourseOfInterest.Assignments)
                                                            {
                                                                Console.WriteLine($"{AssignmentCount}. {a}");
                                                                AssignmentCount++;
                                                            }
                                                            Console.WriteLine("Which assignment?");
                                                            string AssignmentNumber = Console.ReadLine() ?? string.Empty;

                                                            if (int.TryParse(AssignmentNumber, out int AssignmentIndex))
                                                            {
                                                                Assignment assignment = CourseOfInterest.Assignments.ElementAt(AssignmentIndex-1);
                                                                AssignmentItem NewAssignment = new AssignmentItem(ContentName, ContentDescription, assignment);
                                                                ModuleOfInterest.AddContent(NewAssignment);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else if (ModuleInt == 6)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if(courseInt == 9)
                                {
                                    break;
                                }
                            }
                            
                        }
                    }
                    else if (choiceInt == 2)
                    {
                        while (true)
                        {
                            Console.WriteLine("1. Add a student");
                            Console.WriteLine("2. List all students");
                            Console.WriteLine("3. Search for a student");
                            Console.WriteLine("4. List all courses a student is taking");
                            Console.WriteLine("5. Update a students information");
                            Console.WriteLine("6. Exit");
                            Console.WriteLine("Enter an option:");

                            string StudentChoice = Console.ReadLine() ?? string.Empty;

                            if (int.TryParse(StudentChoice, out int StudentInt))
                            {
                                if (StudentInt == 1)
                                {
                                    Console.WriteLine("Enter student name: ");
                                    string StudentName = Console.ReadLine() ?? string.Empty;

                                    Console.WriteLine("Enter student classification: ");
                                    string Studentdescription = Console.ReadLine() ?? string.Empty;

                                    students.Add(new Person(StudentName, Studentdescription));
                                }
                                else if (StudentInt == 2)
                                {
                                    foreach (var a in students)
                                    {
                                        Console.WriteLine(a);
                                    }
                                }
                                else if (StudentInt == 3)
                                {
                                    Console.WriteLine("Enter student name: ");
                                    string StudentName = Console.ReadLine() ?? string.Empty;
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
                                else if (StudentInt == 4)
                                {
                                    Console.WriteLine("Enter student name: ");
                                    string StudentName = Console.ReadLine() ?? string.Empty;
                                    Person currentStudent = new Person();
                                    bool found = false;
                                    foreach (var a in students)
                                    {
                                        if (a.Name == StudentName)
                                        {
                                            currentStudent = a;
                                            found = true;
                                        }
                                        else found = false;
                                    }
                                    if (found)
                                    {
                                        List<Course> courses = courseService.getCourseList();
                                        foreach (var c in courses)
                                        {
                                            foreach (var s in c.Roster)
                                            {
                                                if(s == currentStudent)
                                                {
                                                    Console.WriteLine(c);
                                                }
                                            }
                                        }
                                    }
                                    else { Console.WriteLine("Student not found"); }

                                }
                                else if (StudentInt == 5)
                                {
                                    Console.WriteLine("Enter student name: ");
                                    string StudentName = Console.ReadLine() ?? string.Empty;
                                    Person changedStudent = new Person();
                                    bool found = false;
                                    foreach (var a in students)
                                    {
                                        if (a.Name == StudentName)
                                        {
                                            changedStudent = a;
                                            found = true;
                                        }
                                        else found = false;
                                    }
                                    if (!found)
                                    {
                                        Console.WriteLine("Student not found");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter new name (Leave blank if no change): ");
                                        string newName = Console.ReadLine() ?? string.Empty;
                                        if(newName != string.Empty)
                                            changedStudent.Name = newName;

                                        Console.WriteLine("Enter new classification (Leave blank if no change): ");
                                        string newClass = Console.ReadLine() ?? string.Empty;
                                        if(newClass != string.Empty)
                                            changedStudent.Classification = newClass;

                                    }
                                }
                                else if (StudentInt == 6)
                                {
                                    break;
                                }
                            }

                        }
                    }
                    else if (choiceInt == 3) 
                    {
                        break;
                    }
                    
                }
            }
        }
    }
}
