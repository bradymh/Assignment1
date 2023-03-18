using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class Assignment
    {
        private string? _name;
        public string Name { get { return _name ?? string.Empty; } set { _name = value; } }

        private string? _description;
        public string Description { get { return _description ?? string.Empty; } set { _description = value; } }

        private string? _totalpoints;
        public string TotalAvailablePoints { get { return _totalpoints ?? "100"; } set { _totalpoints = value; } }

        private string? _duedate;
        public string DueDate { get { return _duedate ?? string.Empty; } set { _duedate = value; } }

        private string? _assignmentgroup;
        public string AssignmentGroup { get { return _assignmentgroup ?? string.Empty; } set { _assignmentgroup = value; } }

        public Dictionary<Student, string> AssignmentGrades { get; private set; } = new Dictionary<Student, string>(); 

        public Assignment() { }

        public Assignment(string n, string d, string points, string date)
        {
            Name = n;
            Description = d;
            TotalAvailablePoints = points;
            DueDate = date;
        }

        public bool AddGrade(Student s, string grade)
        {
            try
            {
                AssignmentGrades.Add(s, grade);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
        public bool RemoveGrade(Student s)
        {
            try
            {
                AssignmentGrades.Remove(s);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Description}\nTotal Points: {TotalAvailablePoints}\nDue: {DueDate}\n";
        }

    }
}
