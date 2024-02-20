using System.Collections.Generic;

namespace Colosoft.Serialization.IO
{
    public class SerializationContext
    {
        internal const int InvalidCookie = -1;
        private readonly Dictionary<object, int> cookieList = new Dictionary<object, int>();
        private readonly Dictionary<int, object> graphList = new Dictionary<int, object>();

        private string cacheContext = string.Empty;

        public string CacheContext
        {
            get { return this.cacheContext; }
            set { this.cacheContext = value; }
        }

        public int GetCookie(object graph)
        {
            if (this.cookieList.ContainsKey(graph))
            {
                return this.cookieList[graph];
            }

            return -1;
        }

        public object GetObject(int key)
        {
            if (key > -1 && key < this.graphList.Count)
            {
                return this.graphList[key];
            }

            return null;
        }

        public int RememberObject(object graph)
        {
            int count = this.graphList.Count;
            this.graphList.Add(count, graph);
            this.cookieList.Add(graph, count);
            return count;
        }
    }
}
