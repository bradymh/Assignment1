using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class ContentItem
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        private string _description;
        public string Description { get { return _description; } set { _description = value; } }

        private string _path;
        public string Path { get { return _path; } set { _path = value; } }

        public ContentItem() { }
    }
}
