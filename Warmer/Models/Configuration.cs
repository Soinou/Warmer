using System.IO;
using Warmer.Utils;

namespace Warmer.Models
{
    /// <summary>
    /// Represents the application configuration
    /// </summary>
    internal class Configuration
    {
        /// <summary>
        /// Creates a new Configuration
        /// </summary>
        public Configuration()
        {
            Load();
        }

        /// <summary>
        /// Gets/sets the interval
        /// </summary>
        public int Interval
        {
            get
            {
                return interval_;
            }
            set
            {
                interval_ = value;
                IntervalChanged?.Invoke(interval_);
                Save();
            }
        }

        /// <summary>
        /// Gets/sets the state
        /// </summary>
        public bool State
        {
            get
            {
                return state_;
            }
            set
            {
                state_ = value;
                StateChanged?.Invoke(state_);
                Save();
            }
        }

        /// <summary>
        /// Gets/sets the temperature
        /// </summary>
        public int Temperature
        {
            get
            {
                return temperature_;
            }
            set
            {
                temperature_ = value;
                TemperatureChanged?.Invoke(temperature_);
                Save();
            }
        }

        /// <summary>
        /// Loads the configuration from the disk
        /// </summary>
        public void Load()
        {
            if (File.Exists(kFilePath))
            {
                using (var stream = new FileStream(kFilePath, FileMode.Open))
                using (var reader = new BinaryReader(stream))
                {
                    state_ = reader.ReadBoolean();
                    temperature_ = reader.ReadInt32();
                    interval_ = reader.ReadInt32();
                }
            }
            else
            {
                state_ = true;
                temperature_ = 4500;
                interval_ = 1000;

                Save();
            }
        }

        /// <summary>
        /// Saves the configuration to the disk
        /// </summary>
        public void Save()
        {
            using (var stream = new FileStream(kFilePath, FileMode.OpenOrCreate))
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(state_);
                writer.Write(temperature_);
                writer.Write(interval_);
            }
        }

        /// <summary>
        /// Triggered when the interval value is changed
        /// </summary>
        public event DataEventHandler<int> IntervalChanged;

        /// <summary>
        /// Triggered when the state value is changed
        /// </summary>
        public event DataEventHandler<bool> StateChanged;

        /// <summary>
        /// Triggered when the temperature value is changed
        /// </summary>
        public event DataEventHandler<int> TemperatureChanged;

        /// <summary>
        /// configuration file
        /// </summary>
        private const string kFilePath = "Configuration.db";

        /// <summary>
        /// Interval
        /// </summary>
        private int interval_;

        /// <summary>
        /// State
        /// </summary>
        private bool state_;

        /// <summary>
        /// Temperature
        /// </summary>
        private int temperature_;
    }
}
