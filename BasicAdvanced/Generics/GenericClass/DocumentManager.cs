using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class DocumentManager<TDocument> where TDocument : IDocument
    {
        private readonly Queue<TDocument> documentQueue = new Queue<TDocument>();

        public void AddDocument(TDocument doc)
        {
            lock (this)
            {
                documentQueue.Enqueue(doc);
            }
        }

        public bool IsDocumentAvaliable => documentQueue.Count > 0;

        public TDocument GetDocument()
        {
            TDocument doc = default(TDocument);

            lock (this)
            {
                doc = documentQueue.Dequeue();
            }

            return doc;
        }

        public void DisplayAllDocument()
        {
            foreach (var doc in documentQueue)
            {
                Console.WriteLine(doc.Title);
            }
        }
    }
}