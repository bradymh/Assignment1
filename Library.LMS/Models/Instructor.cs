using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class Instructor : Person
    {
        public Instructor() : base() { }
        public Instructor(string n, string c) : base(n, c) { }
    }
}
