using Library.LMS.Models;

namespace Library.LMS.Models
{
    public class Course
    {
        private static int currentid = 1;

        private string? _courseprefix;
        public string CoursePrefix { private get { return _courseprefix ?? string.Empty; } set { _courseprefix = value; CourseCode(); } }

        private string? _courseid;
        private string CourseId { get { return _courseid ?? string.Empty; } set { _courseid = value; } }

        private string? _code;
        public string Code { get { return _code ?? string.Empty; } private set { _code = value; } }

        private string? _name;
        public string Name { get { return _name ?? string.Empty;} set { _name = value; } }

        private string? _description;
        public string Description { get { return _description ?? string.Empty;} set { _description = value; } }

        private int? _credithours;
        public int CreditHours { get { return _credithours ?? 1; } set { if (value < 0) _credithours = 1; else _credithours = value; } }

        public List<string> Announcments { get; set; } = new List<string>();

        public List<Person> Roster { get; set; } = new List<Person>();
        
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();

        public List<Module> Modules { get; set; } = new List<Module>();

        public Dictionary<Student, int> StudentGrades { get; set; } = new Dictionary<Student, int>();

        public Course() { }

        public Course(Course previousCourse)
        {
            Code = previousCourse.Code;
            Name = previousCourse.Name;
            Description = previousCourse.Description;
            CreditHours = previousCourse.CreditHours;
            Roster = previousCourse.Roster;
            Assignments = previousCourse.Assignments;
            Modules = previousCourse.Modules;
            Announcments = previousCourse.Announcments;
            StudentGrades = previousCourse.StudentGrades;
        }

        public Course(string c, string n, string d, int hours)
        {
            CourseId = NewId();
            CoursePrefix = c;
            CourseCode();
            Name = n;
            Description = d;
            CreditHours = hours;
        }

        public override string ToString()
        {
            return $"{Name} - {Code}";
        }

        private string NewId()
        {
            return $"{currentid++}";
        }

        private void CourseCode()
        {
            Code = CoursePrefix + CourseId;
        }

        public int CalculateStudentGrade(Student s)
        {
            int sumgrades = 0, sumweights = 0;
            foreach (var a in this.Assignments)
            {
                int grade = 0;
                int points = int.Parse(a.TotalAvailablePoints);
                a.AssignmentGrades.TryGetValue(s, out string? value);
                if (value != null)
                {
                    grade = int.Parse(value);
                }
                sumgrades += grade * points;
                sumweights += points;
            }

            if (StudentGrades.ContainsKey(s))
            {
                StudentGrades[s] = sumgrades / sumweights;
            }
            else
            {
                StudentGrades.Add(s, sumgrades / sumweights);
            }

            if (s.CourseGrades.ContainsKey(this))
            {
                s.CourseGrades[this] = sumgrades / sumweights;
            }
            else
            {
                s.CourseGrades.Add(this, sumgrades / sumweights);
            }
            s.CalculateGPA();
            return sumgrades/sumweights;
        }
    }
}