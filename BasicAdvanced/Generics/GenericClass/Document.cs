using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Document: IDocument
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
