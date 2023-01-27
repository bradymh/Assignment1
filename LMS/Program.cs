using Library.LMS.Components;

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