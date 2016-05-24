using Warmer.Models;
using Warmer.Utils;

namespace Warmer.Helpers
{
    /// <summary>
    /// Represents a task warming up the screen
    /// </summary>
    internal class WarmerTask : TimedTask
    {
        /// <summary>
        /// Creates a new WarmerTask
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public WarmerTask(Configuration configuration)
        {
            helper_ = new TemperatureHelper();
            configuration_ = configuration;

            configuration_.TemperatureChanged += OnTemperatureChanged;
            configuration_.StateChanged += OnStateChanged;
            configuration_.IntervalChanged += OnIntervalChanged;

            Interval = configuration_.Interval;

            if (configuration.State)
            {
                Start();
            }
        }

        /// <summary>
        /// Runs the task
        /// </summary>
        public override void Run()
        {
            helper_.Set(configuration_.Temperature);
        }

        /// <summary>
        /// Called when the task is started
        /// </summary>
        protected override void OnStart()
        {
            helper_.Set(configuration_.Temperature);
        }

        /// <summary>
        /// Called when the task is stopped
        /// </summary>
        protected override void OnStop()
        {
            helper_.Reset();
        }

        /// <summary>
        /// Called when the interval is changed
        /// </summary>
        /// <param name="interval">New interval</param>
        private void OnIntervalChanged(int interval)
        {
            Interval = interval;
        }

        /// <summary>
        /// Called when the state is changed
        /// </summary>
        /// <param name="state">New state</param>
        private void OnStateChanged(bool state)
        {
            if (state)
            {
                Start();
            }
            else
            {
                Stop();
            }
        }

        /// <summary>
        /// Called when the temperature value has changed
        /// </summary>
        /// <param name="temperature">New temperature</param>
        private void OnTemperatureChanged(int temperature)
        {
            if (Running)
            {
                helper_.Set(temperature);
            }
        }

        /// <summary>
        /// Configuration
        /// </summary>
        private Configuration configuration_;

        /// <summary>
        /// Temperature helper
        /// </summary>
        private TemperatureHelper helper_;
    }
}
