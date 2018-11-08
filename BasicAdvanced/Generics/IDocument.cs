using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public interface IDocument
    {
        string Title { get; set; }
        string Content { get; set; }
    }
}
