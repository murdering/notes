using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var dm = new DocumentManager<Document>();
            dm.AddDocument(new Document { Title = "Leo Dai", Content = "Handsome!" });
            dm.AddDocument(new Document { Title = "James Bonds", Content = "Very handsome!" });
            dm.DisplayAllDocument();

            while (dm.IsDocumentAvaliable)
            {
                Document doc = dm.GetDocument();
                Console.WriteLine(doc.Content);
            }

            Console.ReadLine();
        }
    }
}
