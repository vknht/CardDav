using CardDav.Helpers;
using System.Text;

namespace CardDav
{
    public abstract class VCardBase
    {
        protected VCardBase()
        {
        }

        public abstract string Version { get; }

        protected abstract void GetFoldedAndEscapedString(StringBuilder stringBuilder);

        protected string FoldAndEscape(string input)
        {
            return FoldingUnfoldingHelper.Fold(EscapeUnescapeHelper.Escape(input));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("BEGIN:VCARD");
            sb.AppendLine($"VERSION:{Version}");

            GetFoldedAndEscapedString(sb);

            sb.AppendLine("END:VCARD");

            return sb.ToString();
        }
    }
}
