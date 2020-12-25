using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoLibrary
{
    public class TodoModel
    {
        public int Tag { get; set; }
        public string Color { get; set; }
        public string TodoText { get; set; }
        public int Priority { get; set; }
        public int isChecked { get; set; }

    }
}
