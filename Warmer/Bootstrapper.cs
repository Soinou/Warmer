using Caliburn.Micro;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Warmer.ViewModels;

namespace Warmer
{
    /// <summary>
    /// Bootstrapper
    /// </summary>
    public class Bootstrapper : BootstrapperBase, IDisposable
    {
        /// <summary>
        /// Creates a new Bootstrapper
        /// </summary>
        public Bootstrapper()
        {
            Initialize();

            Application.DispatcherUnhandledException += OnDispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Cleans resources used by this object
        /// </summary>
        /// <param name="disposing">If the GC is finalizing this object</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed_)
            {
                if (disposing)
                {
                    if (mutex_ != null)
                    {
                        mutex_.ReleaseMutex();
                        mutex_.Close();
                        mutex_ = null;
                    }
                }

                disposed_ = true;
            }
        }

        /// <summary>
        /// Exits the application
        /// </summary>
        /// <param name="exit_code"></param>
        protected void Exit(int exit_code = 0)
        {
            Application.Shutdown(exit_code);
        }

        /// <inheritdoc />
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            bool mutex_created = false;
            mutex_ = new Mutex(true, "Warmer-e76116e8-a4d2-4b02-9f1d-c37215674ef6", out mutex_created);

            if (!mutex_created)
            {
                mutex_ = null;
                Application.Shutdown(1);
            }
            else
            {
                DisplayRootViewFor<ShellViewModel>();
            }
        }

        /// <summary>
        /// If the resources have been freed already
        /// </summary>
        protected bool disposed_;

        /// <summary>
        /// Mutex
        /// </summary>
        protected Mutex mutex_;

        /// <summary>
        /// Called when the application dispatcher has an unhandled exception
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        private void OnDispatcherUnhandledException(object sender,
            DispatcherUnhandledExceptionEventArgs e)
        {
            ShowException(e.Exception);
            e.Handled = true;
        }

        /// <summary>
        /// Called when an unhandled exception is thrown
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ShowException((Exception)e.ExceptionObject);
        }

        /// <summary>
        /// Called when the task scheduler has an unhandled exception
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        private void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            ShowException(e.Exception);
            e.SetObserved();
        }

        /// <summary>
        /// Shows an exception message to the user
        /// </summary>
        /// <param name="exception">Exception message</param>
        private void ShowException(Exception exception)
        {
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
            }

            var manager = new WindowManager();

            manager.ShowDialog(new ExceptionViewModel(exception));

            Application.Shutdown(1);
        }
    }
}
