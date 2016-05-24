using System.Collections.Generic;

namespace Warmer.Localization
{
    /// <summary>
    /// Base implementation of the ILocale interface
    /// </summary>
    internal abstract class LocaleBase : ILocale
    {
        /// <summary>
        /// Creates a new LocaleBase
        /// </summary>
        public LocaleBase()
        {
            strings_ = new Dictionary<string, string>();

            Load(strings_);
        }

        /// <inheritdoc />
        public string this[string key]
        {
            get
            {
                string value = null;

                if (!strings_.TryGetValue(key, out value))
                {
                    return "Missing translation for '" + key + "'";
                }
                else
                {
                    return value;
                }
            }
        }

        /// <summary>
        /// Loads the strings
        /// </summary>
        /// <param name="strings">Strings dictionary</param>
        protected abstract void Load(IDictionary<string, string> strings);

        /// <summary>
        /// Strings dictionary
        /// </summary>
        private IDictionary<string, string> strings_;
    }
}
