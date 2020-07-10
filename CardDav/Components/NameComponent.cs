using CardDav.Helpers;
using System;
using System.Collections.Generic;

namespace CardDav.Components
{
    public class NameComponent
    {
        private readonly IDictionary<string, ISet<string>> _dicCache = new Dictionary<string, ISet<string>>();
        private const string SurName = "SurName";
        private const string GivenName = "GivenName";
        private const string AdditionalName = "AdditionalName";
        private const string HonorificPrefix = "HonorificPrefix";
        private const string HonorificSuffix = "HonorificSuffix";

        public NameComponent AddSurName(string value)
        {
            AddValue(SurName, value);
            return this;
        }

        public NameComponent AddGivenName(string value)
        {
            AddValue(GivenName, value);
            return this;
        }

        public NameComponent AddAdditionalName(string value)
        {
            AddValue(AdditionalName, value);
            return this;
        }

        public NameComponent AddHonorificPrefix(string value)
        {
            AddValue(HonorificPrefix, value);
            return this;
        }

        public NameComponent AddHonorificSuffix(string value)
        {
            AddValue(HonorificSuffix, value);
            return this;
        }

        public NameComponent RemoveSurName(string value)
        {
            RemoveValue(SurName, value);
            return this;
        }

        public NameComponent RemoveGivenName(string value)
        {
            RemoveValue(GivenName, value);
            return this;
        }

        public NameComponent RemoveAdditionalName(string value)
        {
            RemoveValue(AdditionalName, value);
            return this;
        }

        public NameComponent RemoveHonorificPrefix(string value)
        {
            RemoveValue(HonorificPrefix, value);
            return this;
        }

        public NameComponent RemoveHonorificSuffix(string value)
        {
            RemoveValue(HonorificSuffix, value);
            return this;
        }

        private void AddValue(string propertyName, string value)
        {
            DictionaryHelper.AddValue(_dicCache, propertyName, value);
        }

        private void RemoveValue(string propertyName, string value)
        {
            DictionaryHelper.RemoveValue(_dicCache, propertyName, value);
        }

        private IEnumerable<string> GetValuesOrEmpty(string propertyName)
        {
            return DictionaryHelper.GetValuesOrEmpty(_dicCache, propertyName);
        }

        private string JoinAndEscape(IEnumerable<string> lst)
        {
            return EscapeUnescapeHelper.Escape(String.Join(Constants.CardDavConstants.COMMA, lst));
        }

        public override string ToString()
        {
            var tmpLst = new List<string>
            {
                JoinAndEscape(GetValuesOrEmpty(SurName)),
                JoinAndEscape(GetValuesOrEmpty(GivenName)),
                JoinAndEscape(GetValuesOrEmpty(AdditionalName)),
                JoinAndEscape(GetValuesOrEmpty(HonorificPrefix)),
                JoinAndEscape(GetValuesOrEmpty(HonorificSuffix))
            };

            return FoldingUnfoldingHelper.Fold($"N{Constants.CardDavConstants.COLON}{String.Join(Constants.CardDavConstants.SEMICOLON, tmpLst)}");
        }
    }
}
