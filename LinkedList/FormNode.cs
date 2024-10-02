using GeometrischeForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class FormNode
    {
        public Form Content { get; set; }
        public FormNode Next { get; set; }

        public FormNode(Form content, FormNode next = null)
        {
            this.Content = content;
            this.Next = next;
        }
    }
}
