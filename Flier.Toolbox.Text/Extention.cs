using System.Collections.Generic;

namespace Flier.Toolbox.Text
{
    public static class Extention
    {   
        public static int[] IndexOfAll(this string Text,string pattern)
        {
            return Boyer_Moore_MagicLen.boyerMooreMagicLen(Text.ToCharArray(), pattern.ToCharArray());
        }
        public static int[] IndexOfAll(this char[] Text, char[] pattern)
        {   
            return Boyer_Moore_MagicLen.boyerMooreMagicLen(Text, pattern);
        }
        public static int[] LastIndexOfAll(this string Text, string pattern)
        {
            return Boyer_Moore_MagicLen.boyerMooreMagicLenRev(Text.ToCharArray(), pattern.ToCharArray());
        }
        public static int[] LastIndexOfAll(this char[] Text, char[] pattern)
        {
            return Boyer_Moore_MagicLen.boyerMooreMagicLenRev(Text, pattern);
        }

        internal static int getOrDefault(this Dictionary<char, int> Dictionary, char Key, int DefaultValue)
        {
            if (Dictionary.ContainsKey(Key))
                return Dictionary[Key];
            else
                return DefaultValue;
        }
    }
}
