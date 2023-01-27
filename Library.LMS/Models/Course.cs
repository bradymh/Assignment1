namespace Library.LMS.Models
{
    public class Course
    {
        private string _code;
        public string Code { get { return _code; } set { _code = value; } }

        private string _name;
        public string Name { get { return _name;} set { _name = value; } }

        private string _description;
        public string Description { get { return _description;} set { _description = value; } }

        List<Person> Roster = new List<Person>();

        List<Assignment> Assignments = new List<Assignment>();

        List<Module> Modules = new List<Module>();

        public Course() { }

        public void AddStudent()
        {

        }

    }
}