using CardDav.Helpers;
using System;
using System.Collections.Generic;

namespace CardDav.Components
{
    public class TelephoneComponent
    {
        public string Number { get; set; }
        public TelephoneEnum Type { get; set; }

        public override string ToString()
        {
            var tmpLst = new List<string>()
            {
                "TEL",
                "VALUE=text",
            };

            return FoldingUnfoldingHelper.Fold($"{String.Join(Constants.CardDavConstants.SEMICOLON, tmpLst)}{Constants.CardDavConstants.SEMICOLON}TYPE={Type.ToString()}{Constants.CardDavConstants.COLON}{EscapeUnescapeHelper.Escape(Number)}");
        }
    }
}
