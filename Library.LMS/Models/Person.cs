using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class Person
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        private string _classification;
        public string Classification { get { return _classification; } set { _classification = value; } }

        //grades
        
        public Person() { }

    }
}
