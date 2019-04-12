/*
 Convert Code from https://github.com/magiclen/boyer-moore-magiclen
 */
using System;
using System.Collections.Generic;

namespace Flier.Toolbox.Text
{
    internal class Boyer_Moore_MagicLen
    {
        /// <summary>
        /// Boyer-Moore-MagicLen演算法(正向)。77/253
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        internal static int[] boyerMooreMagicLen(char[] text, char[] pattern)
        {
            int textLength = text.Length;
            int patternLength = pattern.Length;

            if (textLength == 0 || patternLength == 0 || textLength < patternLength)
            {
                return new int[0];
            }

            int patternLengthDec = patternLength - 1;
            Dictionary<char, int> badCharShiftMap = new Dictionary<char, int>(patternLengthDec);

            for (int i = 0; i < patternLengthDec; ++i)
            {
                if (!badCharShiftMap.ContainsKey(pattern[i]))
                    badCharShiftMap.Add(pattern[i], patternLengthDec - i);
            }

            char lastPatternChar = pattern[patternLengthDec];

            int shift = 0;

            int endIndex = textLength - patternLength;
            List<int> resultList = new List<int>();

            bool outer_break = false, outer_continue = false;
            while (true)
            {
                outer_continue = false;
                for (int i = patternLengthDec; i >= 0; --i)
                {
                    if (text[shift + i] != pattern[i])
                    {
                        int p = shift + patternLength;
                        if (p == textLength)
                        {
                            outer_break = true;
                            break;
                        }
                        int s1 = badCharShiftMap.getOrDefault(text[shift + patternLengthDec], patternLength);
                        char c = text[p];
                        int s2 = c == lastPatternChar ? 1 : (badCharShiftMap.getOrDefault(c, patternLength) + 1);
                        shift += Math.Max(s1, s2);
                        if (shift > endIndex)
                        {
                            outer_break = true;
                            break;
                        }
                        outer_continue = true;
                        break;
                    }
                }
                if (outer_break)
                    break;
                if (outer_continue)
                    continue;
                resultList.Add(shift);

                if (shift == endIndex)
                {
                    break;
                }

                int s12 = badCharShiftMap.getOrDefault(text[shift + patternLengthDec], patternLength);
                char c2 = text[shift + patternLength];
                int s22 = c2 == lastPatternChar ? 1 : (badCharShiftMap.getOrDefault(c2, patternLength) + 1);
                shift += Math.Max(s12, s22);
                if (shift > endIndex)
                {
                    break;
                }
            }

            return resultList.ToArray();
        }

        /// <summary>
        /// Boyer-Moore-MagicLen演算法(反向)。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        internal static int[] boyerMooreMagicLenRev(char[] text, char[] pattern)
        {
            int textLength = text.Length;
            int patternLength = pattern.Length;

            if (textLength == 0 || patternLength == 0 || textLength < patternLength)
            {
                return new int[0];
            }

            int patternLengthDec = patternLength - 1;

            Dictionary<char, int> badCharShiftMap = new Dictionary<char, int>(patternLengthDec);

            for (int i = patternLengthDec; i >= 1; --i)
            {
                if (!badCharShiftMap.ContainsKey(pattern[i]))
                    badCharShiftMap.Add(pattern[i], i);
            }

            char firstPatternChar = pattern[0];

            int shift = textLength - 1;

            int startIndex = patternLengthDec;

            List<int> resultList = new List<int>();

            bool outer_break = false, outer_continue = false;
            while (true)
            {
                outer_continue = false;
                for (int i = 0; i < patternLength; ++i)
                {
                    if (text[shift - patternLengthDec + i] != pattern[i])
                    {
                        int p = shift - patternLength;
                        if (p < 0)
                        {
                            outer_break = true;
                            break;
                        }
                        int s1 = badCharShiftMap.getOrDefault(text[shift - patternLengthDec], patternLength);
                        char c = text[p];
                        int s2 = c == firstPatternChar ? 1 : (badCharShiftMap.getOrDefault(c, patternLength) + 1);
                        shift -= Math.Max(s1, s2);
                        if (shift < startIndex)
                        {
                            outer_break = true;
                            break;
                        }
                        outer_continue = true;
                        break;
                    }
                }
                if (outer_break)
                    break;
                if (outer_continue)
                    continue;
                resultList.Add(shift - patternLengthDec);

                if (shift == startIndex)
                {
                    break;
                }

                int s12 = badCharShiftMap.getOrDefault(text[shift - patternLengthDec], patternLength);
                char c2 = text[shift - patternLength];
                int s22 = c2 == firstPatternChar ? 1 : (badCharShiftMap.getOrDefault(c2, patternLength) + 1);
                shift -= Math.Max(s12, s22);
                if (shift < startIndex)
                {
                    break;
                }
            }
            return resultList.ToArray();
        }
    }
}
