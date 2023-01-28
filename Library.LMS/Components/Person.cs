using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Components
{
    public class Person
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        private string _classification;
        public string Classification { get { return _classification; } set { _classification = value; } }

        //grades
        public Dictionary<Assignment, string> Grades = new Dictionary<Assignment, string>();

        public void AddGrade(Assignment a, string grade)
        {
            try
            {
                Grades.Add(a, grade);
            }
            catch 
            {
                Console.WriteLine("Assignment already exists");
            }
        }

        public Person() { }
        public Person(string n, string c)
        {
            Name = n;
            Classification = c;
        }

        public override string ToString()
        {
            return $"{Name} - {Classification}";
        }

        public void DisplayGrades()
        {
            foreach(var a in Grades)
            {
                Console.Write(a.Key);
                Console.WriteLine($"Grade: {a.Value}");
            }
        }

    }
}
