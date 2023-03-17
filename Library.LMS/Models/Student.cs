using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class Student : Person
    {
        public Student() : base() { }

        public Student(string n, string c) : base(n,c) { }

        private int _gpa;
        public int GPA { get { return _gpa; } set { _gpa = value; } }

        public Dictionary<Course, string> CourseGrades { get; set; } = new Dictionary<Course, string>();

        public bool AddGrade(Course c, string grade)
        {
            try
            {
                CourseGrades.Add(c, grade);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
        public bool RemoveGrade(Course c)
        {
            try
            {
                CourseGrades.Remove(c);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public int CalculateGPA()
        {
            int sumgrades = 0, sumcredits = 0;
            foreach(var a in CourseGrades)
            {
                int grade = int.Parse(a.Value); 
                sumgrades += a.Key.CreditHours * grade;
                sumcredits += a.Key.CreditHours;
            }
            return sumgrades/sumcredits;
        }
    }
}
