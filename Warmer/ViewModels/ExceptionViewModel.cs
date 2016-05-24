using System;
using System.Text;

namespace Warmer.ViewModels
{
    public interface IExceptionViewModelFactory
    {
        ExceptionViewModel Create(Exception exception);

        void Release(ExceptionViewModel view_model);
    }

    public class ExceptionViewModel : Caliburn.Micro.Screen
    {
        public ExceptionViewModel(Exception exception)
        {
            DisplayName = "Warmer - Whoops!";

            exception_ = exception;
        }

        public string ExceptionStackTrace
        {
            get
            {
                StringBuilder builder = new StringBuilder();

                builder.AppendLine("Error message: " + exception_.Message);
                builder.Append(exception_.StackTrace);

                return builder.ToString();
            }
        }

        public string Message
        {
            get
            {
                StringBuilder builder = new StringBuilder();

                builder.AppendLine("Seems like an error has occured in the application.");
                builder.AppendLine("Please contact the application author and send him the"
                    + " content of the text area below");

                return builder.ToString();
            }
        }

        /// <summary>
        /// Called when the user presses the close button
        /// </summary>
        public void Shutdown()
        {
            TryClose(true);
        }

        protected Exception exception_;
    }
}
