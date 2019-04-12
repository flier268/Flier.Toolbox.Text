using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flier.Toolbox.Text
{
    public class FastReplace
    {
        private readonly Dictionary<char, List<KeyValuePair<string, string>>> Dictionary_Head;

        /// <summary>
        /// Replace a lot of string
        /// </summary>
        /// <param name="Dictionary"></param>
        public FastReplace(Dictionary<string, string> Dictionary)
        {
            Dictionary_Head = Dictionary.GroupBy(x => x.Key.First()).ToDictionary(x => x.Key, x => x.ToList());
        }
        public string ReplaceAll(string source)
        {
            StringBuilder sb = new StringBuilder(source.Length);
            char[] key = Dictionary_Head.Keys.ToArray();
            int indexPass, indexNow = 0;
            indexPass = indexNow;
            indexNow = source.IndexOfAny(key, indexNow);
            int i;
            while (indexNow != -1)
            {
                sb.Append(source.Substring(indexPass, indexNow - indexPass));
                var _dic = Dictionary_Head[source[indexNow]];
                bool replaced = false;
                foreach (var a in _dic)
                {
                    if (indexNow + a.Key.Length > source.Length)
                        continue;
                    bool equal = true;
                    for (i = 0; i < a.Key.Length; i++)
                        if (source[indexNow + i] != a.Key[i])
                        {
                            equal = false;
                            break;
                        }
                    if (!equal)
                        continue;
                    sb.Append(a.Value);
                    indexNow += a.Key.Length;
                    replaced = true;
                    break;
                }
                if (!replaced)
                {
                    sb.Append(source.Substring(indexNow, 1));
                    indexNow++;
                }
                indexPass = indexNow;
                indexNow = source.IndexOfAny(key, indexNow);
            }
            sb.Append(source.Substring(indexPass, source.Length - indexPass));
            return sb.ToString();
        }
    }
}
