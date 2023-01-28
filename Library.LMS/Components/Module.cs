﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Components
{
    public class Module
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        private string _description;
        public string Description { get { return _description;} set { _description = value; } }

        List<ContentItem> Content = new List<ContentItem>();

        public Module() { }

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
