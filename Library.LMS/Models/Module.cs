using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class Module
    {
        private string? _name;
        public string Name { get { return _name ?? string.Empty ; } set { _name = value; } }

        private string? _description;
        public string Description { get { return _description ?? string.Empty;} set { _description = value; } }

        public List<ContentItem> Content { get; set; } = new List<ContentItem>();

        public Module() { }
        public Module(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Name} - {Description}";
        }

        public void AddContent(ContentItem item)
        {
            Content.Add(item);
        }
    }
}
