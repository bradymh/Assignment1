using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class FileItem : ContentItem
    {
        private string? _filepath;
        public string FilePath { get { return _filepath ?? string.Empty; } set { _filepath = value; } }

        public FileItem() { }
        public FileItem(string name, string description, string filepath) : base(name, description) 
        {
            FilePath = filepath;
        }

        public override string ToString()
        {
            return base.ToString() + $" - {FilePath}";
        }
    }
}
