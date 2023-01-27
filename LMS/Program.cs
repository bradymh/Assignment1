using Library.LMS.Components;

namespace LMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Course> courses = new List<Course>();
            List<Person> students = new List<Person>();

            Person student = new Person();
            student.Name= "Test";
            student.Classification = "Junior";
            Assignment assignment1 = new Assignment();
            assignment1.DueDate = "1/2/22";
            assignment1.Name = "TestAssign";
            assignment1.TotalAvailablePoints = "100";
            assignment1.Description = "Description";



            student.AddGrade(assignment1, "100");

            Console.WriteLine(student);


            while (true)
            {
                Console.WriteLine("1. Exit");
                Console.WriteLine("Enter choice: ");
                string choice = Console.ReadLine() ?? string.Empty;

                

                if (int.TryParse(choice, out int choiceInt))
                {   if(choiceInt == 1)
                    {
                        break;
                    }

                }
            }
        }
    }
}