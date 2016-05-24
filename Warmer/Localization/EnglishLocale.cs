using System.Collections.Generic;

namespace Warmer.Localization
{
    /// <summary>
    /// Represents the english locale
    /// </summary>
    internal class EnglishLocale : LocaleBase
    {
        /// <inheritdoc />
        protected override void Load(IDictionary<string, string> strings)
        {
            strings["About.Contact"] = "Contact: abricot.soinou@gmail.com";
            strings["About.Bugs"] = "Report bugs on https://github.com/Soinou/Warmer/issues";
            strings["Tray.Show"] = "Show";
            strings["Tray.Exit"] = "Exit";
            strings["Tray.About"] = "About";
            strings["Main.On"] = "On";
            strings["Main.Off"] = "Off";
            strings["Main.Temperature"] = "Temperature ({0}K)";
            strings["Main.Interval"] = "Interval ({0}ms)";
            strings["Main.StateTooltip"] = "Enables/Disables the screen warming";
            strings["Main.TemperatureTooltip"] = "Screen 'temperature' (Lower means more red, higher means less red)";
            strings["Main.IntervalTooltip"] = "Interval between two screen gamma updates (Change if you have problems with other applications changing your screen gamma)";
        }
    }
}
