using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class Person
    {
        private string? _name;
        public string Name { get { return _name ?? string.Empty; } set { _name = value; } }

        private string? _classification;
        public string Classification { get { return _classification ?? string.Empty; } set { _classification = value; } }

        public Dictionary<Assignment, string> Grades { get; set; } = new Dictionary<Assignment, string>();

        public bool AddGrade(Assignment a, string grade)
        {
            try
            {
                Grades.Add(a, grade);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
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

    }
}
