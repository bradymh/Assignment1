using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class AssignmentItem : ContentItem
    {
        private Assignment _assignmentpath = new Assignment();
        public Assignment AssignmentPath { get { return _assignmentpath; } set { _assignmentpath = value; } } 

        public AssignmentItem() { }
        public AssignmentItem(string name,string description, Assignment assignment) : base(name, description)
        {
            AssignmentPath = assignment;
        }
        public override string ToString()
        {
            return base.ToString() + "\n" + AssignmentPath.ToString();
        }
    }
}
