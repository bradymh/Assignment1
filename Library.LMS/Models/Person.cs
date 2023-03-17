using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class Person
    {
        private static int currentid=1;
        private int id;
        public int Id { get { return id; } private set { id = value; } }

        private string? _name;
        public string Name { get { return _name ?? string.Empty; } set { _name = value; } }

        private string? _classification;
        public string Classification { get { return _classification ?? string.Empty; } set { _classification = value; } }

        public Person() 
        {
            Id = NewId();
        }
        public Person(string n, string c)
        {
            Name = n;
            Classification = c;
            Id = NewId();
        }

        public override string ToString()
        {
            return $"{Name} - {Id}";
        }

        private int NewId()
        {
            return currentid++;
        }
    }
}
