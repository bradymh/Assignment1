using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Components
{
    public class Assignment
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        private string _description;
        public string Description { get { return _description; } set { _description = value; } }

        private string _totalpoints;
        public string TotalAvailablePoints { get { return _totalpoints; } set { _totalpoints = value; } }

        private string _duedate;
        public string DueDate { get { return _duedate; } set { _duedate = value; } }

        public Assignment() { }

        public override string ToString()
        {
            return $"{Name} - {Description}\nTotal Points: {TotalAvailablePoints}\nDue: {DueDate}\n";
        }

    }
}
