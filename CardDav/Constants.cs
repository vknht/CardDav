using System;
using System.Collections.Generic;
using System.Text;

namespace CardDav
{
    internal static class Constants
    {
        public static class CardDavConstants
        {
            public static readonly string NEW_LINE = new String(new[] { '\u000D', '\u000A' });
            public static readonly string WHITE_SPACE = new String(new[] { '\u0020' });
            public static readonly string HORIZONTAL_TAB = new String(new[] { '\u0009' });
            public static readonly string BACK_SLASH = new String(new[] { '\u005C' });
            public static readonly string COMMA = new String(new[] { '\u002C' });
            public static readonly string SEMICOLON = new String(new[] { '\u003B' });
            public static readonly string LETTER_N = new String(new[] { '\u006E' });
            public static readonly string COLON = new String(new[] { '\u003A' });
            public const string DATE_FORMAT = "yyyyMMdd";
            public const int MAX_LINE_LENGTH = 75;
        }
    }
}
