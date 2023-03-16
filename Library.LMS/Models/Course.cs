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
        public int CreditHours { get { return _credithours ?? 1; } set { _credithours = value; } }

        public List<Person> Roster { get; set; } = new List<Person>();
        
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();

        public List<Module> Modules { get; set; } = new List<Module>();

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
        }

        public Course(string c, string n, string d)
        {
            CourseId = NewId();
            CoursePrefix = c;
            CourseCode();
            Name = n;
            Description = d;
        }

        public void AddStudent(Person student)
        {
            Roster.Add(student);
        }

        public void AddAssignment(Assignment assignment)
        {
            Assignments.Add(assignment);
        }

        public void AddModule(Module module)
        {
            Modules.Add(module);
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
    }
}