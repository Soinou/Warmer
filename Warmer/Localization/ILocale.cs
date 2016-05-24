namespace Warmer.Localization
{
    /// <summary>
    /// Represents the application locale
    /// </summary>
    internal interface ILocale
    {
        /// <summary>
        /// Gets a localized string by its key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Localized string</returns>
        string this[string key]
        {
            get;
        }
    }
}
