using CardDav.Helpers;
using System;
using System.Collections.Generic;

namespace CardDav.Components
{
    public class AddressComponent
    {
        private readonly IDictionary<string, ISet<string>> _dicCache = new Dictionary<string, ISet<string>>();

        private const string PostOfficeBox = "PostOfficeBox";
        private const string ExtendedAddress = "ExtendedAddress";
        private const string Street = "Street";
        private const string Locality = "Locality";
        private const string Region = "Region";
        private const string PostalCode = "PostalCode";
        private const string CountryName = "CountryName";

        public GenericEnum? Type { get; set; }

        public AddressComponent AddPostOfficeBox(string value)
        {
            DictionaryHelper.AddValue(_dicCache, PostOfficeBox, value);
            return this;
        }

        public AddressComponent RemovePostOfficeBox(string value)
        {
            DictionaryHelper.RemoveValue(_dicCache, PostOfficeBox, value);
            return this;
        }

        public AddressComponent AddExtendedAddress(string value)
        {
            DictionaryHelper.AddValue(_dicCache, ExtendedAddress, value);
            return this;
        }

        public AddressComponent RemoveExtendedAddress(string value)
        {
            DictionaryHelper.RemoveValue(_dicCache, ExtendedAddress, value);
            return this;
        }

        public AddressComponent AddStreet(string value)
        {
            DictionaryHelper.AddValue(_dicCache, Street, value);
            return this;
        }

        public AddressComponent RemoveStreet(string value)
        {
            DictionaryHelper.RemoveValue(_dicCache, Street, value);
            return this;
        }

        public AddressComponent AddLocality(string value)
        {
            DictionaryHelper.AddValue(_dicCache, Locality, value);
            return this;
        }

        public AddressComponent RemoveLocality(string value)
        {
            DictionaryHelper.RemoveValue(_dicCache, Locality, value);
            return this;
        }

        public AddressComponent AddRegion(string value)
        {
            DictionaryHelper.AddValue(_dicCache, Region, value);
            return this;
        }

        public AddressComponent RemoveRegion(string value)
        {
            DictionaryHelper.RemoveValue(_dicCache, Region, value);
            return this;
        }

        public AddressComponent AddPostalCode(string value)
        {
            DictionaryHelper.AddValue(_dicCache, PostalCode, value);
            return this;
        }

        public AddressComponent RemovePostalCode(string value)
        {
            DictionaryHelper.RemoveValue(_dicCache, PostalCode, value);
            return this;
        }

        public AddressComponent AddCountryName(string value)
        {
            DictionaryHelper.AddValue(_dicCache, CountryName, value);
            return this;
        }

        public AddressComponent RemoveCountryName(string value)
        {
            DictionaryHelper.RemoveValue(_dicCache, CountryName, value);
            return this;
        }

        private string JoinAndEscape(IEnumerable<string> lst)
        {
            return EscapeUnescapeHelper.Escape(String.Join(Constants.CardDavConstants.COMMA, lst));
        }

        public override string ToString()
        {
            var tmpLst = new List<string>
            {
                JoinAndEscape(GetValuesOrEmpty(PostOfficeBox)),
                JoinAndEscape(GetValuesOrEmpty(ExtendedAddress)),
                JoinAndEscape(GetValuesOrEmpty(Street)),
                JoinAndEscape(GetValuesOrEmpty(Locality)),
                JoinAndEscape(GetValuesOrEmpty(Region)),
                JoinAndEscape(GetValuesOrEmpty(PostalCode)),
                JoinAndEscape(GetValuesOrEmpty(CountryName))
            };

            var tmpType = Type.HasValue ? Type.ToString() : nameof(GenericEnum.Home) + Constants.CardDavConstants.COMMA + nameof(GenericEnum.Work);

            var tmpLstParam = new List<string>()
            {
                "ADR",
                $"TYPE={tmpType}"
            };

            return FoldingUnfoldingHelper.Fold($"{String.Join(Constants.CardDavConstants.SEMICOLON, tmpLstParam)}{Constants.CardDavConstants.COLON}{String.Join(Constants.CardDavConstants.SEMICOLON, tmpLst)}");
        }

        private IEnumerable<string> GetValuesOrEmpty(string propertyName)
        {
            return DictionaryHelper.GetValuesOrEmpty(_dicCache, propertyName);
        }
    }
}
