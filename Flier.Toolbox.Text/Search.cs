namespace Flier.Toolbox.Text
{
    public class Search
    {
        public static int[] SearchText(string Text, string pattern)
        {
            return Boyer_Moore_MagicLen.boyerMooreMagicLen(Text.ToCharArray(), pattern.ToCharArray());
        }
        public static int[] SearchTextFromLast(string Text, string pattern)
        {
            return Boyer_Moore_MagicLen.boyerMooreMagicLenRev(Text.ToCharArray(), pattern.ToCharArray());
        }
    }
}
