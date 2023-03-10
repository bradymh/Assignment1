using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class PageItem : ContentItem
    {
        private string? _htmlbody;
        public string HTMLBody { get { return _htmlbody ?? string.Empty; } set { _htmlbody = value; } }

        public PageItem() { }
    }
}
