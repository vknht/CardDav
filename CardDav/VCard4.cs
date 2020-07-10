using CardDav.Components;
using CardDav.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardDav
{
    /// <summary>
    /// Implements RFC 6352 (https://tools.ietf.org/html/rfc6352)
    /// </summary>
    public class VCard4 : VCardBase
    {
        private readonly IDictionary<string, ISet<string>> _dicCache = new Dictionary<string, ISet<string>>();
        private const string NickName = "NickName";
        private const string Category = "Category";

        public VCard4()
            : this(Guid.NewGuid())
        {
        }

        public VCard4(Guid guid)
        {
            if (guid == Guid.Empty)
            {
                throw new ArgumentException("Guid must not be Guid.Empty!", nameof(guid));
            }

            Guid = guid;
        }

        public override string Version => "4.0";

        public string FormattedName { get; set; }
        public NameComponent Name { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? Anniversary { get; set; }
        public GenderEnum? Gender { get; set; }
        public AddressComponent Address { get; set; }
        public TelephoneCollection TelephoneCollection { get; } = new TelephoneCollection();
        public string Email { get; set; }
        public string Title { get; set; }
        public string Role { get; set; }
        public string Org { get; set; }
        public string Note { get; set; }
        public Guid Guid { get; set; }
        public string Url { get; set; }

        public VCard4 AddNickName(string value)
        {
            DictionaryHelper.AddValue(_dicCache, NickName, value);
            return this;
        }

        public VCard4 RemoveNickName(string value)
        {
            DictionaryHelper.RemoveValue(_dicCache, NickName, value);
            return this;
        }

        public VCard4 AddCategory(string value)
        {
            DictionaryHelper.AddValue(_dicCache, Category, value);
            return this;
        }

        public VCard4 RemoveCategory(string value)
        {
            DictionaryHelper.RemoveValue(_dicCache, Category, value);
            return this;
        }

        public bool ContainsNickNameValue(string value)
        {
            return ContainsValue(NickName, value);
        }

        public bool ContainsCategoryValue(string value)
        {
            return ContainsValue(Category, value);
        }

        private bool ContainsValue(string key, string value)
        {
            if (!_dicCache.ContainsKey(key))
            {
                return false;
            }

            return _dicCache[key].Contains(value);
        }

        protected override void GetFoldedAndEscapedString(StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine(FoldingUnfoldingHelper.Fold($"FN{Constants.CardDavConstants.COLON}{EscapeUnescapeHelper.Escape(FormattedName)}"));

            if (Name != null)
            {
                stringBuilder.AppendLine(Name.ToString());
            }

            var tmpNickName = String.Join(Constants.CardDavConstants.COMMA, DictionaryHelper.GetValuesOrEmpty(_dicCache, NickName).Select(EscapeUnescapeHelper.Escape));
            if (!String.IsNullOrEmpty(tmpNickName))
            {
                stringBuilder.AppendLine(FoldingUnfoldingHelper.Fold($"NICKNAME{Constants.CardDavConstants.COLON}{tmpNickName}"));
            }

            if (Birthday.HasValue)
            {
                stringBuilder.AppendLine(FoldingUnfoldingHelper.Fold($"BDAY{Constants.CardDavConstants.COLON}{EscapeUnescapeHelper.Escape(Birthday.Value.ToString(Constants.CardDavConstants.DATE_FORMAT))}"));
            }

            if (Anniversary.HasValue)
            {
                stringBuilder.AppendLine(FoldingUnfoldingHelper.Fold($"ANNIVERSARY{Constants.CardDavConstants.COLON}{EscapeUnescapeHelper.Escape(Anniversary.Value.ToString(Constants.CardDavConstants.DATE_FORMAT))}"));
            }

            if (Gender.HasValue)
            {
                stringBuilder.AppendLine(FoldingUnfoldingHelper.Fold($"GENDER{Constants.CardDavConstants.COLON}{EscapeUnescapeHelper.Escape(Gender.Value.ToString().Substring(0, 1))}"));
            }

            if (Address != null)
            {
                stringBuilder.AppendLine(Address.ToString());
            }

            if (TelephoneCollection.Any())
            {
                foreach (var telephone in TelephoneCollection)
                {
                    stringBuilder.AppendLine(telephone.ToString());
                }
            }

            if (!String.IsNullOrEmpty(Email))
            {
                stringBuilder.AppendLine(FoldingUnfoldingHelper.Fold($"EMAIL{Constants.CardDavConstants.COLON}{EscapeUnescapeHelper.Escape(Email)}"));
            }

            if (!String.IsNullOrEmpty(Title))
            {
                stringBuilder.AppendLine(FoldingUnfoldingHelper.Fold($"TITLE{Constants.CardDavConstants.COLON}{EscapeUnescapeHelper.Escape(Title)}"));
            }

            if (!String.IsNullOrEmpty(Role))
            {
                stringBuilder.AppendLine(FoldingUnfoldingHelper.Fold($"ROLE{Constants.CardDavConstants.COLON}{EscapeUnescapeHelper.Escape(Role)}"));
            }

            if (!String.IsNullOrEmpty(Org))
            {
                stringBuilder.AppendLine(FoldingUnfoldingHelper.Fold($"ORG{Constants.CardDavConstants.COLON}{EscapeUnescapeHelper.Escape(Org)}"));
            }

            var tmpCategory = String.Join(Constants.CardDavConstants.COMMA, DictionaryHelper.GetValuesOrEmpty(_dicCache, Category).Select(EscapeUnescapeHelper.Escape));
            if (!String.IsNullOrEmpty(tmpCategory))
            {
                stringBuilder.AppendLine(FoldingUnfoldingHelper.Fold($"CATEGORIES{Constants.CardDavConstants.COLON}{tmpCategory}"));
            }

            if (!String.IsNullOrEmpty(Note))
            {
                stringBuilder.AppendLine(FoldingUnfoldingHelper.Fold($"NOTE{Constants.CardDavConstants.COLON}{EscapeUnescapeHelper.Escape(Note)}"));
            }

            stringBuilder.AppendLine(FoldingUnfoldingHelper.Fold($"UID{Constants.CardDavConstants.COLON}urn{Constants.CardDavConstants.COLON}uuid{Constants.CardDavConstants.COLON}{EscapeUnescapeHelper.Escape(Guid.ToString())}"));

            if (!String.IsNullOrEmpty(Url))
            {
                stringBuilder.AppendLine(FoldingUnfoldingHelper.Fold($"URL{Constants.CardDavConstants.COLON}{EscapeUnescapeHelper.Escape(Url)}"));
            }
        }
    }
}
