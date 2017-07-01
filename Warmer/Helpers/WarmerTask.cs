using System;
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
        /// Configuration
        /// </summary>
        private Configuration configuration_;

        /// <summary>
        /// Temperature helper
        /// </summary>
        private TemperatureHelper helper_;

        /// <summary>
        /// Boolean to fix the idle/screen plug/unplug update problem
        ///
        /// Yes, that's incredibly hacky
        /// </summary>
        private bool idle_fix_;

        /// <summary>
        /// Creates a new WarmerTask
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public WarmerTask(Configuration configuration)
        {
            helper_ = new TemperatureHelper();
            configuration_ = configuration;
            idle_fix_ = false;

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
            // Yes, I don't know why, but it works
            idle_fix_ = !idle_fix_;
            helper_.Set(configuration_.Temperature + (idle_fix_ ? 1 : 0));
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
            Console.WriteLine("[" + DateTime.Now.ToLocalTime() + "] updating interval to " + interval);

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
            Console.WriteLine("[" + DateTime.Now.ToLocalTime() + "] updating temperature to " + temperature);

            if (Running)
            {
                helper_.Set(temperature);
            }
        }
    }
}
