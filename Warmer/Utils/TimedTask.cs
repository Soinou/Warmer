using System.Timers;

namespace Warmer.Utils
{
    /// <summary>
    /// Task using a timer to run periodically
    /// </summary>
    public abstract class TimedTask : DisposableBase
    {
        /// <summary>
        /// Creates a new TimedTask
        /// </summary>
        public TimedTask()
        {
            timer_ = new Timer();

            timer_.Interval = 1000;
            timer_.Elapsed += OnElapsed;
        }

        /// <summary>
        /// get/set the interval between calls to the Run method (In milliseconds)
        /// </summary>
        public double Interval
        {
            get
            {
                return timer_.Interval;
            }
            set
            {
                timer_.Interval = value;
            }
        }

        /// <summary>
        /// Gets the state of the task
        /// </summary>
        public bool Running
        {
            get
            {
                return timer_.Enabled;
            }
        }

        /// <summary>
        /// Called when the task is triggered and needs to do actual work
        /// </summary>
        public abstract void Run();

        /// <summary>
        /// Starts the timer
        /// </summary>
        public void Start()
        {
            if (!timer_.Enabled)
            {
                OnStart();
                timer_.Start();
            }
        }

        /// <summary>
        /// Stops the timer
        /// </summary>
        public void Stop()
        {
            if (timer_.Enabled)
            {
                OnStop();
                timer_.Stop();
            }
        }

        /// <inheritdoc />
        protected override void OnFinalize()
        {
            timer_.Dispose();
        }

        /// <summary>
        /// Called when the task is started
        /// </summary>
        protected abstract void OnStart();

        /// <summary>
        /// Called when the task is stopped
        /// </summary>
        protected abstract void OnStop();

        /// <summary>
        /// Called by the timer each Interval milliseconds
        /// </summary>
        /// <param name="sender">Sender (Ignored)</param>
        /// <param name="e">Arguments (Ignored)</param>
        private void OnElapsed(object sender, ElapsedEventArgs e)
        {
            Run();
        }

        /// <summary>
        /// Internal timer
        /// </summary>
        private Timer timer_;
    }
}
