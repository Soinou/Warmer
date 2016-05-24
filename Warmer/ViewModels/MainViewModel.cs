using Caliburn.Micro;
using Warmer.Localization;
using Warmer.Models;

namespace Warmer.ViewModels
{
    /// <summary>
    /// Represents the main view model
    /// </summary>
    internal class MainViewModel : Screen
    {
        /// <summary>
        /// Creates a new MainViewModel
        /// </summary>
        /// <param name="configuration">Configuration</param>
        /// <param name="locale">Locale</param>
        public MainViewModel(Configuration configuration, ILocale locale)
        {
            configuration_ = configuration;
            locale_ = locale;
        }

        /// <summary>
        /// Gets/sets the display name
        /// </summary>
        public override string DisplayName
        {
            get
            {
                return "Warmer";
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets/sets the task interval
        /// </summary>
        public int Interval
        {
            get
            {
                return configuration_.Interval;
            }
            set
            {
                if (configuration_.Interval != value)
                {
                    configuration_.Interval = value;
                    NotifyOfPropertyChange(() => Interval);
                    NotifyOfPropertyChange(() => IntervalText);
                }
            }
        }

        /// <summary>
        /// Gets the interval label text
        /// </summary>
        public string IntervalText
        {
            get
            {
                return string.Format(locale_["Main.Interval"], Interval);
            }
        }

        /// <summary>
        /// Interval tooltip
        /// </summary>
        public string IntervalTooltip
        {
            get
            {
                return locale_["Main.IntervalTooltip"];
            }
        }

        /// <summary>
        /// Gets the off label text
        /// </summary>
        public string OffLabel
        {
            get
            {
                return locale_["Main.Off"];
            }
        }

        /// <summary>
        /// Gets the on label text
        /// </summary>
        public string OnLabel
        {
            get
            {
                return locale_["Main.On"];
            }
        }

        /// <summary>
        /// Gets/sets the task state
        /// </summary>
        public bool State
        {
            get
            {
                return configuration_.State;
            }
            set
            {
                if (configuration_.State != value)
                {
                    configuration_.State = value;
                    NotifyOfPropertyChange(() => State);
                }
            }
        }

        /// <summary>
        /// State tooltip
        /// </summary>
        public string StateTooltip
        {
            get
            {
                return locale_["Main.StateTooltip"];
            }
        }

        /// <summary>
        /// Gets/sets the temperature
        /// </summary>
        public int Temperature
        {
            get
            {
                return configuration_.Temperature;
            }
            set
            {
                if (configuration_.Temperature != value)
                {
                    configuration_.Temperature = value;
                    NotifyOfPropertyChange(() => Temperature);
                    NotifyOfPropertyChange(() => TemperatureText);
                }
            }
        }

        /// <summary>
        /// Gets the temperature text
        /// </summary>
        public string TemperatureText
        {
            get
            {
                return string.Format(locale_["Main.Temperature"], Temperature); ;
            }
        }

        /// <summary>
        /// Temperature tooltip
        /// </summary>
        public string TemperatureTooltip
        {
            get
            {
                return locale_["Main.TemperatureTooltip"];
            }
        }

        /// <summary>
        /// Configuration
        /// </summary>
        private Configuration configuration_;

        /// <summary>
        /// Locale
        /// </summary>
        private ILocale locale_;
    }
}
