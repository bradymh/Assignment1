using Library.LMS.Models;

namespace Library.LMS.Models
{
    public class Course
    {
        private string? _code;
        public string Code { get { return _code ?? string.Empty; } set { _code = value; } }

        private string? _name;
        public string Name { get { return _name ?? string.Empty;} set { _name = value; } }

        private string? _description;
        public string Description { get { return _description ?? string.Empty;} set { _description = value; } }

        public List<Person> Roster { get; set; } = new List<Person>();
        
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();

        public List<Module> Modules { get; set; } = new List<Module>();

        public Course() { }
        public Course(string c, string n, string d)
        {
            Code = c;
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

    }
}