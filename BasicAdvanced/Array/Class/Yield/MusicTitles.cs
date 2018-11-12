using System;
using System.Collections.Generic;
using System.Text;

namespace Array.Class
{
    public class MusicTitles
    {
        private string[] names = { "我就是这样的人", "沙漠骆驼", "春风十里", "南山南" };

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < names.Length; i++)
            {
                yield return names[i];
            }
        }

        public IEnumerable<string> Reverse()
        {
            for (int i = names.Length - 1; i >= 0; i--)
            {
                yield return names[i];
            }
        }

        public IEnumerable<string> SubTitle(int index, int length)
        {
            for (int i = index; i < index + length; i++)
            {
                yield return names[i];
            }
        }
    }
}