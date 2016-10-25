using System.Collections.Generic;

namespace Warmer.Localization
{
    /// <summary>
    /// Represents the french locale
    /// </summary>
    internal class FrenchLocale : LocaleBase
    {
        /// <inheritdoc />
        protected override void Load(IDictionary<string, string> strings)
        {
            strings["About.Contact"] = "Contact: abricot.soinou@gmail.com";
            strings["About.Bugs"] = "Reporter les problèmes sur https://github.com/Soinou/Warmer/issues";
            strings["Tray.Show"] = "Afficher";
            strings["Tray.Exit"] = "Quitter";
            strings["Tray.About"] = "À propos";
            strings["Main.On"] = "Activé";
            strings["Main.Off"] = "Désactivé";
            strings["Main.Temperature"] = "Température ({0}K)";
            strings["Main.Interval"] = "Intervalle ({0}ms)";
            strings["Main.StateTooltip"] = "Active/Désactive le chauffage de l'écran";
            strings["Main.TemperatureTooltip"] = "'Température' de l'écran (Plus bas veut dire plus rouge, plus haut veut dire moins rouge)";
            strings["Main.IntervalTooltip"] = "Intervalle entre deux mises à jour du gamma de l'écran (Changez si vous avez des problèmes avec d'autres applications modifiant le gamma de l'écran)";
            strings["Restart.Title"] = "Warmer - Info";
            strings["Restart.Message"] = "Vous devriez maintenant pouvoir utiliser une température d'écran inférieure à 3300K après avoir redémarré votre ordinateur.";
            strings["Extend.Message"] = "étendre l'intervalle de température";
        }
    }
}
