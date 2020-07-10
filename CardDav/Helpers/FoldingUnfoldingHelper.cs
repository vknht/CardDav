using System;
using static CardDav.Constants.CardDavConstants;

namespace CardDav.Helpers
{
    internal static class FoldingUnfoldingHelper
    {
        public static string Fold(string input)
        {
            return Fold(input, false);
        }

        public static string Fold(string input, bool useHorizontalTab)
        {
            if (String.IsNullOrEmpty(input))
            {
                return input;
            }

            if (input.Length <= MAX_LINE_LENGTH)
            {
                return input;
            }

            var count = (input.Length / MAX_LINE_LENGTH);

            string result = null;
            var stringToInsert = NEW_LINE + (useHorizontalTab ? HORIZONTAL_TAB : WHITE_SPACE);


            for (int i = count; i > 0; i--)
            {
                result = input.Insert(MAX_LINE_LENGTH * i, stringToInsert);
            }

            if (result.EndsWith(stringToInsert))
            {
                return result.Substring(0, result.Length - stringToInsert.Length);
            }

            return result;
        }

        public static string Unfold(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return input;
            }

            if (input.Contains(NEW_LINE + HORIZONTAL_TAB))
            {
                return input.Replace(NEW_LINE + HORIZONTAL_TAB, String.Empty);
            }
            else if (input.Contains(NEW_LINE + WHITE_SPACE))
            {
                return input.Replace(NEW_LINE + WHITE_SPACE, String.Empty);
            }

            return input;
        }
    }
}
