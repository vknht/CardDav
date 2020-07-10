using System;
using static CardDav.Constants.CardDavConstants;

namespace CardDav.Helpers
{
    internal static class EscapeUnescapeHelper
    {
        public static string Escape(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return input;
            }

            return input
                .Replace(BACK_SLASH, BACK_SLASH + BACK_SLASH)
                .Replace(NEW_LINE, BACK_SLASH + LETTER_N)
                .Replace(COMMA, BACK_SLASH + COMMA)
                .Replace(SEMICOLON, BACK_SLASH + SEMICOLON)
                ;
        }

        public static string Unescape(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return input;
            }

            return input
                .Replace(BACK_SLASH + SEMICOLON, SEMICOLON)
                .Replace(BACK_SLASH + COMMA, COMMA)
                .Replace(BACK_SLASH + LETTER_N, NEW_LINE)
                .Replace(BACK_SLASH + BACK_SLASH, BACK_SLASH);
        }
    }
}
