using Caliburn.Micro;
using System.Globalization;
using System.Windows;
using Warmer.Controls;
using Warmer.Helpers;
using Warmer.Localization;
using Warmer.Models;

namespace Warmer.ViewModels
{
    /// <summary>
    /// Represents the shell view model
    /// </summary>
    public class ShellViewModel : Screen
    {
        /// <summary>
        /// Creates a new ShellViewModel
        /// </summary>
        public ShellViewModel()
        {
            configuration_ = new Configuration();
            task_ = new WarmerTask(configuration_);
            tray_ = new TrayIcon("Warmer", Warmer.Properties.Resources.Icon);
            main_open_ = false;

            switch (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName)
            {
                case "fr":
                    locale_ = new FrenchLocale();
                    break;

                default:
                    locale_ = new EnglishLocale();
                    break;
            }

            about_ = locale_["Tray.About"];
            show_ = locale_["Tray.Show"];
            exit_ = locale_["Tray.Exit"];

            tray_.AddItem(show_);
            tray_.AddSeparator();
            tray_.AddItem(about_);
            tray_.AddSeparator();
            tray_.AddItem(exit_);

            tray_.ItemClicked += TrayIconItemClicked;
            tray_.DoubleClicked += TrayIconDoubleClicked;

            tray_.Show();
        }

        /// <summary>
        /// Opens the about window
        /// </summary>
        private void About()
        {
            if (!about_open_)
            {
                about_open_ = true;

                var manager = new WindowManager();
                var about = new AboutViewModel(locale_);

                manager.ShowDialog(about);

                about_open_ = false;
            }
        }

        /// <summary>
        /// Exits the application
        /// </summary>
        private void Exit()
        {
            // Stop the task but don't update the configuration value
            task_.Stop();
            tray_.Hide();
            Application.Current.Shutdown(0);
        }

        /// <summary>
        /// Shows the main view
        /// </summary>
        private void Show()
        {
            if (!main_open_)
            {
                main_open_ = true;

                var manager = new WindowManager();
                var main = new MainViewModel(configuration_, locale_);

                manager.ShowDialog(main);

                main_open_ = false;
            }
        }

        /// <summary>
        /// called when the tray icon is double clicked
        /// </summary>
        private void TrayIconDoubleClicked()
        {
            Show();
        }

        /// <summary>
        /// Called when a tray icon menu item is clicked
        /// </summary>
        /// <param name="item">Item clicked</param>
        private void TrayIconItemClicked(string item)
        {
            if (item == about_)
            {
                About();
            }
            else if (item == show_)
            {
                Show();
            }
            else if (item == exit_)
            {
                Exit();
            }
        }

        /// <summary>
        /// About menu item
        /// </summary>
        private string about_;

        /// <summary>
        /// If the about window is opened
        /// </summary>
        private bool about_open_;

        /// <summary>
        /// Configuration
        /// </summary>
        private Configuration configuration_;

        /// <summary>
        /// Exit menu item
        /// </summary>
        private string exit_;

        /// <summary>
        /// Locale
        /// </summary>
        private ILocale locale_;

        /// <summary>
        /// If the main view is opened
        /// </summary>
        private bool main_open_;

        /// <summary>
        /// Show menu item
        /// </summary>
        private string show_;

        /// <summary>
        /// Task
        /// </summary>
        private WarmerTask task_;

        /// <summary>
        /// Tray icon
        /// </summary>
        private TrayIcon tray_;
    }
}
