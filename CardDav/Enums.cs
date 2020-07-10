namespace CardDav
{
    public enum GenericEnum
    {
        Home = 0, //home
        Work, //work
        Preferred //pref
    }

    public enum GenderEnum
    {
        Unknown = 0,
        Male,
        Female,
        Other,
        NoneOrNotApplicable,
    }

    public enum TelephoneEnum
    {
        /// <summary>
        /// Indicates a voice telephone number.
        /// </summary>
        Voice = 0, // voice
        /// <summary>
        /// Indicates that the telephone number supports text messages (SMS).
        /// </summary>
        Text, // text
        /// <summary>
        /// Indicates a facsimile telephone number.
        /// </summary>
        Fax, // fax
        /// <summary>
        /// Indicates a cellular or mobile telephone number.
        /// </summary>
        Cell, //cell
        /// <summary>
        /// Indicates a video conferencing telephone number.
        /// </summary>
        Video, //video
        /// <summary>
        /// Indicates a paging device telephone number.
        /// </summary>
        Pager, //pager
        /// <summary>
        /// Indicates a telecommunication device for people with hearing or speech difficulties.
        /// </summary>
        TextPhone, //textphone
        Home, //home
        Work, //work
    }
}
