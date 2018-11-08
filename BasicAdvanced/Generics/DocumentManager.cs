using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class DocumentManager<T>
    {
        private readonly Queue<T> documentQueue = new Queue<T>();

        public void AddDocument(T doc)
        {
            lock (this)
            {
                documentQueue.Enqueue(doc);
            }
        }

        public bool IsDocumentAvaliable => documentQueue.Count > 0;

        public T GetDocument()
        {
            T doc = default(T);

            lock (this)
            {
                doc = documentQueue.Dequeue();
            }

            return doc;
        }
    }
}